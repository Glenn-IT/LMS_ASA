-- ============================================================
-- LMS_ASA orphaned-user cleanup script
-- Removes tbl_Users login rows with Role = 'Borrower' that have
-- no matching tbl_Borrowers record.
--
-- Why this happens: an older version of BorrowerRepository.Delete()
-- only deleted the tbl_Borrowers row and left the tbl_Users login
-- behind. Fixed in commit 424dae3 ("Ensure transactional integrity
-- in Delete method"). Any device that deleted borrowers before
-- pulling that commit will have leftover orphaned accounts here,
-- which then collide with GetNextUID() and block re-adding a
-- borrower with the same UID (e.g. "Save failed: Violation of
-- UNIQUE KEY constraint ... duplicate key value is (brwXXXX)").
--
-- Safe to run any time: it only ever targets Borrower-role users
-- that are not linked to any tbl_Borrowers row.
-- ============================================================

-- 1) Preview what will be DELETED — check this looks right first.
SELECT UserID, Username, Role, CreatedAt
FROM dbo.tbl_Users u
WHERE u.Role = 'Borrower'
  AND NOT EXISTS (SELECT 1 FROM dbo.tbl_Borrowers b WHERE b.UserID = u.UserID);

BEGIN TRANSACTION;

DELETE u
FROM dbo.tbl_Users u
WHERE u.Role = 'Borrower'
  AND NOT EXISTS (SELECT 1 FROM dbo.tbl_Borrowers b WHERE b.UserID = u.UserID);

-- 2) Sanity check before committing
SELECT UserID, Username, Role FROM dbo.tbl_Users ORDER BY UserID;

-- If the result above looks right, run:
-- COMMIT;
-- Otherwise, run:
-- ROLLBACK;
