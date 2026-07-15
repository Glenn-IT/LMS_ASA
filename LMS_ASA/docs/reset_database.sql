-- ============================================================
-- LMS_ASA fresh-start reset script
-- Clears all borrower/loan/payment/activity data, keeps admin
-- accounts in tbl_Users. Run against your dev DB only.
-- ============================================================

-- 1) Preview what will be KEPT — verify this looks right before running the DELETEs below.
SELECT UserID, Username, Role FROM dbo.tbl_Users WHERE Role = 'Admin';

BEGIN TRANSACTION;

-- Child-most tables first (respect FKs)
DELETE FROM dbo.tbl_Payments;
DELETE FROM dbo.tbl_LoanApplications;
DELETE FROM dbo.tbl_Loans;
DELETE FROM dbo.tbl_ActivityLogs;
DELETE FROM dbo.tbl_Borrowers;

-- Keep admin accounts only (adjust the Role value if yours differs, e.g. 'admin')
DELETE FROM dbo.tbl_Users WHERE Role <> 'Admin';

-- Reset identity counters so new records start from 1 again
DBCC CHECKIDENT ('dbo.tbl_Payments', RESEED, 0);
DBCC CHECKIDENT ('dbo.tbl_LoanApplications', RESEED, 0);
DBCC CHECKIDENT ('dbo.tbl_Loans', RESEED, 0);
DBCC CHECKIDENT ('dbo.tbl_ActivityLogs', RESEED, 0);
DBCC CHECKIDENT ('dbo.tbl_Borrowers', RESEED, 0);
-- tbl_Users is NOT reseeded since admin rows remain with their existing IDs.

-- 2) Sanity check before committing
SELECT 'tbl_Users' AS TableName, COUNT(*) AS RecordCount FROM dbo.tbl_Users
UNION ALL SELECT 'tbl_Borrowers', COUNT(*) FROM dbo.tbl_Borrowers
UNION ALL SELECT 'tbl_Loans', COUNT(*) FROM dbo.tbl_Loans
UNION ALL SELECT 'tbl_LoanApplications', COUNT(*) FROM dbo.tbl_LoanApplications
UNION ALL SELECT 'tbl_Payments', COUNT(*) FROM dbo.tbl_Payments
UNION ALL SELECT 'tbl_ActivityLogs', COUNT(*) FROM dbo.tbl_ActivityLogs;

-- If the counts above look right, run:
-- COMMIT;
-- Otherwise, run:
-- ROLLBACK;
