-- ============================================================
-- v4.00 demo seed: adds 5 sample tbl_Loans rows for the Loan List
-- screen (View-only in this version). Cycles across whatever
-- borrowers already exist in tbl_Borrowers, so run it after at
-- least one borrower has been added. Safe to re-run; each run
-- appends 5 more rows continuing the LN-#### numbering.
-- ============================================================

SET NOCOUNT ON;

DECLARE @BorrowerCount INT = (SELECT COUNT(*) FROM dbo.tbl_Borrowers);
IF @BorrowerCount = 0
BEGIN
    RAISERROR('No borrowers found — add at least one borrower before seeding demo loans.', 16, 1);
    RETURN;
END

DECLARE @NextNum INT = (
    SELECT ISNULL(MAX(TRY_CAST(RIGHT(LoanReferenceID, 4) AS INT)), 0) + 1
    FROM dbo.tbl_Loans
);

;WITH Numbered AS (
    SELECT BorrowerID, ROW_NUMBER() OVER (ORDER BY BorrowerID) AS rn
    FROM dbo.tbl_Borrowers
),
Demo (n, LoanType, Principal, Rate, Term, Status, DaysAgoRelease, DaysFromReleaseToDue) AS (
    SELECT 0, 'Personal Loan',      25000, 3.5, 12, 'Pending',  10,  365
    UNION ALL SELECT 1, 'Business Loan',     150000, 4.0, 24, 'Approved', 30,  730
    UNION ALL SELECT 2, 'Salary Loan',        10000, 2.5,  6, 'Active',   60,  180
    UNION ALL SELECT 3, 'Emergency Loan',      5000, 5.0,  3, 'Overdue',  95,   90
    UNION ALL SELECT 4, 'Agricultural Loan',  80000, 3.0, 18, 'Closed',  400,  540
)
INSERT INTO dbo.tbl_Loans
    (BorrowerID, LoanReferenceID, LoanType, PrincipalAmount, InterestRate, TotalPayable, Term, ReleaseDate, DueDate, Status, CreatedAt)
SELECT
    num.BorrowerID,
    'LN-' + RIGHT('0000' + CAST(@NextNum + d.n AS VARCHAR(4)), 4),
    d.LoanType,
    d.Principal,
    d.Rate,
    d.Principal * (1 + d.Rate / 100.0),
    d.Term,
    DATEADD(DAY, -d.DaysAgoRelease, GETDATE()),
    DATEADD(DAY, d.DaysFromReleaseToDue - d.DaysAgoRelease, GETDATE()),
    d.Status,
    GETDATE()
FROM Demo d
JOIN Numbered num ON num.rn = (d.n % @BorrowerCount) + 1;

SELECT LoanID, LoanReferenceID, BorrowerID, LoanType, PrincipalAmount, Status FROM dbo.tbl_Loans ORDER BY LoanID;
