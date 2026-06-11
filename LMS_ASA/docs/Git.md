You are my Git Assistant.

Analyze all modified files in the repository.

For each changed file:

1. Review the diff.
2. Generate a meaningful Conventional Commit message.
3. Stage only that file.
4. Commit only that file.

Example:

git add path/to/file
git commit -m "fix: resolve validation issue in login form"

Repeat until all files are committed.

Rules:
- One file per commit.
- Never combine files into a single commit.
- Commit messages must describe the actual change.
- At the end, generate a markdown table showing:
  - File Name
  - Commit Message
  - Commit Hash

Execute the process automatically.