# Version Control — LMS ASA Philippines

## Rollout Schedule

| Version | Feature | Forms Unlocked | Forms Still Gated |
|---------|---------|----------------|-------------------|
| v1.00 | Login + Forgot Password | Form1 (LoginForm), ForgotPasswordForm | All others |
| v1.01 | Admin: Dashboard | AdminDashboardForm | v1.02–v1.11 forms |
| v1.02 | Admin: Borrower List + Add New Borrower | BorrowerListForm, NewBorrowerForm | v1.03–v1.11 forms |
| v1.03 | Admin: Borrower Accounts + Edit Account | BorrowerAccountsForm, EditAccountForm | v1.04–v1.11 forms |
| v1.04 | Admin: View Loan Applications | ViewLoanApplicationForm | v1.05–v1.11 forms |
| v1.05 | Admin: Loan List + New Loan | LoanListForm, NewLoanForm | v1.06–v1.11 forms |
| v1.06 | Admin: Payment List + New Payment | PaymentListForm, NewPaymentForm | v1.07–v1.11 forms |
| v1.07 | Admin: Account Settings | AdminAccountSettingsForm | v1.08–v1.11 forms |
| v1.08 | Borrower: Dashboard | BorrowerDashboardForm | v1.09–v1.11 forms |
| v1.09 | Borrower: File a Loan Application | LoanApplicationForm | v1.10–v1.11 forms |
| v1.10 | Borrower: Track Loan | TrackLoanForm | v1.11 forms |
| v1.11 | Borrower: My Account (Full System) | MyAccountForm | None |

---

## Under Construction Strategy

Every form not yet presented in the current version has a **gate block** at the top of its `Form_Load` event handler:

```vb
' GATE — remove this block when unlocking for vX.XX
Dim gate As New UnderConstructionForm()
gate.ShowDialog()
Me.Close()
Return
' END GATE
```

When any gated form loads, it immediately shows `UnderConstructionForm` as a modal dialog (blocking), then closes itself. The caller form remains open.

`UnderConstructionForm` has a module-level constant `CURRENT_VERSION` that is updated each version:

```vb
Public Const CURRENT_VERSION As String = "v1.00"
```

The Under Construction screen shows:
- 🚧 hard-hat emoji
- Current version label (orange)
- "Under Construction" title (white, bold)
- Description: "This feature is not yet available in the current presentation version."
- "← Go Back" button that closes the dialog only (not the caller)

---

## Git Commands Per Version

```bash
# 1. Remove the GATE block from the Form_Load of the unlocked form(s)
# 2. Update CURRENT_VERSION in UnderConstructionForm.vb

# Stage and commit
git add <UnlockedForm.vb> UnderConstructionForm.vb
git commit -m "feat: implement vX.XX - unlock [Feature Name]"

# Tag and push
git tag vX.XX
git push origin master
git push origin vX.XX
```

---

## How Git Tags Work

Each version is permanently snapshotted with a Git tag. A tag is a named pointer to an exact commit — it never moves, so you can always check out the state of the project as it was for any presentation.

```bash
# Check out a specific version
git checkout v1.01

# Return to latest
git checkout master
```

---

## GitHub Release Tags

| Version | Tag Name | Commit Hash |
|---------|----------|-------------|
| v1.00 | v1.00 | |
| v1.01 | v1.01 | |
| v1.02 | v1.02 | |
| v1.03 | v1.03 | |
| v1.04 | v1.04 | |
| v1.05 | v1.05 | |
| v1.06 | v1.06 | |
| v1.07 | v1.07 | |
| v1.08 | v1.08 | |
| v1.09 | v1.09 | |
| v1.10 | v1.10 | |
| v1.11 | v1.11 | |

To fill in commit hashes after all versions are done:

```bash
git tag | sort | xargs -I{} git log -1 --format="{} %H" {}
```

---

## When a Prof or Client Requests Changes After a Presentation

```bash
# Fix on master first
git checkout master
git add .
git commit -m "feat: update [form] per feedback"
git push origin master

# Delete old tag and re-create it pointing to the new commit
git tag -d vX.XX
git push origin :refs/tags/vX.XX
git tag vX.XX
git push origin vX.XX
```
