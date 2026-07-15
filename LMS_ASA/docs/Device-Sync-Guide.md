# Syncing Another Device With This Repo

**Author:** Glenn
**Last Updated:** 2026-07-16
> Steps for updating a second machine that already has this repo cloned — pulling the latest code and fixing up its local database so both devices behave the same way.

---

## 1. Pull the latest code

```
git pull origin master
```

This picks up commit `424dae3` ("Ensure transactional integrity in Delete method"), which fixes `BorrowerRepository.Delete()` so it removes **both** the `tbl_Borrowers` row and the matching `tbl_Users` login row in one transaction. The old version only deleted the borrower row and silently left the login account behind.

**Then rebuild** (or just re-run from Visual Studio / `dotnet build`). Pulling the source alone does nothing — the app runs from the compiled binary, so an old build will keep exhibiting the bug even after `git pull`.

---

## 2. Check `config.txt` exists

Each device needs its own `config.txt` next to the `.exe` (in `bin\Debug\net8.0-windows\`) — it is not committed to git. See [`DB_Connection_Pattern.md`](DB_Connection_Pattern.md) if it's missing. Copy `config.txt.example`, fill in that device's SQL Server instance name, and confirm the `Initial Catalog` points at the right database.

---

## 3. Clean up orphaned login accounts

If borrowers were ever added and deleted on that device **before** it had the fix from step 1, its database will have the same corruption we found and fixed here: `tbl_Users` rows with `Role = 'Borrower'` and no matching `tbl_Borrowers` record. These block re-adding a borrower with the same generated UID, and throw:

```
Save failed: Violation of UNIQUE KEY constraint 'UQ_tbl_User_...'.
Cannot insert duplicate key in object 'dbo.tbl_Users'. The duplicate key value is (brwXXXX).
```

Run [`cleanup_orphaned_users.sql`](cleanup_orphaned_users.sql) against that device's database (SSMS, Azure Data Studio, or `sqlcmd`):

```
sqlcmd -S ".\SQLEXPRESS" -d LMS_DB -E -i cleanup_orphaned_users.sql
```

It previews the rows it will remove first — read the preview, then uncomment `COMMIT;` (or `ROLLBACK;` to back out) at the bottom before it takes effect. Safe to run any time; it only ever targets Borrower-role logins with no linked borrower record.

---

## 4. (Optional) Full data reset instead

If you'd rather wipe all test borrowers/loans/payments on that device and start clean — rather than just removing orphans — use [`reset_database.sql`](reset_database.sql) instead of step 3. It clears every borrower/loan/payment/activity row and keeps only `Role = 'Admin'` accounts in `tbl_Users`. Same preview-then-`COMMIT`/`ROLLBACK` pattern.

---

## Quick checklist

- [ ] `git pull origin master`
- [ ] Rebuild the project
- [ ] `config.txt` present next to the `.exe` with the correct connection string
- [ ] Run `cleanup_orphaned_users.sql` (or `reset_database.sql` for a full wipe) against that device's DB
- [ ] Launch the app and confirm adding/deleting a borrower works without the duplicate-key error
