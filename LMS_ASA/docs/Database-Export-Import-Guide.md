# Exporting `LMS_DB` From This Device And Importing It On Another

**Author:** Glenn
**Last Updated:** 2026-07-20
> Steps for copying the actual database contents (borrowers, users, loans, payments — not just schema) from this machine to another device via SSMS, so both devices have the same real data instead of just the same code.

This is different from [`Device-Sync-Guide.md`](Device-Sync-Guide.md), which only fixes up a device's *existing* database (orphaned rows) after a code pull. Use **this** guide when you want the other device's database to become an exact copy of this one.

---

## 1. Export on this device (source)

In SSMS, connected to `.\SQLEXPRESS`:

1. Expand **Databases** → right-click **LMS_DB**.
2. **Tasks → Export Data-tier Application...**
3. Click through the wizard, save the output as `LMS_DB.bacpac` somewhere easy to find (e.g. Desktop).
4. Wait for it to finish — SSMS shows a progress dialog, then "Success".

A `.bacpac` is a single portable file containing both schema and data. It's the simplest option when both devices run SQL Server / SQL Express (any recent version) and don't need to preserve exact file paths.

> **Alternative — native backup (`.bak`)**: Tasks → Back Up... → Backup type `Full` → add a destination file. Slightly faster for large databases and preserves more SQL Server–specific detail, but restoring it on another device requires matching (or relocating) the `.mdf`/`.ldf` file paths in the Restore dialog's **Files** page. Prefer the `.bacpac` route above unless you have a reason to need a native backup.

---

## 2. Move the file to the other device

Copy `LMS_DB.bacpac` to the other device — USB drive, shared folder, cloud storage, whatever's convenient. This file can contain real borrower PII (names, contact numbers, emails, ID images' file paths), so don't leave it somewhere publicly accessible or commit it into the git repo.

---

## 3. Import on the other device (target)

In SSMS on the target device, connected to its local SQL Server instance:

1. If a database named `LMS_DB` **already exists** there and you want to replace it entirely:
   - Right-click it → **Delete** → check "Close existing connections" → OK.
   - (If you'd rather keep it as a backup, rename it first: right-click → Rename.)
2. Right-click **Databases** → **Import Data-tier Application...**
3. Point the wizard at the `LMS_DB.bacpac` file you copied over.
4. Keep the target database name as `LMS_DB` (so it matches `config.txt` on that device — see step 4).
5. Finish the wizard and wait for "Success".

---

## 4. Verify `config.txt` on the target device

The app doesn't read the SSMS connection — it reads `config.txt` next to the `.exe` (`bin\Debug\net8.0-windows\config.txt`, not committed to git). Confirm it points at the restored database:

```
Data Source=.\SQLEXPRESS;Initial Catalog=LMS_DB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;
```

Adjust `Data Source` if that device's SQL Server instance name differs. See [`DB_Connection_Pattern.md`](DB_Connection_Pattern.md) if `config.txt` is missing entirely.

---

## 5. Sanity check

Launch the app on the target device and confirm:

- The borrower list shows the same borrowers as this device.
- Login with an existing account (e.g. `brw0001` / `Password@1`) works.
- Adding a new borrower succeeds without a duplicate-key error (the transactional insert fix from commit `76ff598` should already be in place if you followed [`Device-Sync-Guide.md`](Device-Sync-Guide.md) first).

---

## Quick checklist

- [ ] SSMS → LMS_DB → Tasks → Export Data-tier Application → save `.bacpac`
- [ ] Copy the `.bacpac` to the target device
- [ ] Drop/rename the target's existing `LMS_DB` if present
- [ ] SSMS on target → Import Data-tier Application → restore as `LMS_DB`
- [ ] Confirm `config.txt` on target points at `LMS_DB`
- [ ] Launch app, confirm borrower data and login match
