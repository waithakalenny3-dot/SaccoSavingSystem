# Sacco Savings System

A Windows Forms desktop application for managing a SACCO (Savings and Credit Cooperative Society) savings and loan system. Built with VB.NET (.NET 8) and SQLite.

## Features

- **Member Management** — Register and manage SACCO members
- **Savings Accounts** — Open accounts, record deposits and withdrawals
- **Loans** — Loan application, calculation, and repayment tracking
- **User Authentication** — Secure login with password hashing
- **Reports** — Generate savings and loan reports
- **Backup** — Database backup and restore functionality
- **Local Database** — SQLite file-based database (no external server required)

## Project Structure

```
SaccoManager/
├── BLL/                        # Business Logic Layer
│   ├── Models/                 # Data models (Account, Member, Loan, User, etc.)
│   └── Services/               # Business services (Auth, LoanCalculator, Backup, etc.)
├── DAL/                        # Data Access Layer
│   ├── Repositories            # Data repositories for each entity
│   └── Db.vb                   # Database connection helper
├── UI/                         # Windows Forms user interface
│   ├── frmLogin.vb             # Login form
│   ├── frmMain.vb              # Main dashboard
│   ├── frmMembers.vb           # Member management
│   ├── frmAccounts.vb          # Savings accounts
│   ├── frmLoans.vb             # Loan management
│   ├── frmSavings.vb           # Savings transactions
│   ├── frmUsers.vb             # User management
│   ├── frmReports.vb           # Reports
│   └── frmBackup.vb            # Backup/Restore
├── Database/
│   └── sacco_schema.sql        # SQL schema
├── Program.vb                  # Application entry point
├── SaccoManager.vbproj         # Project file
├── .gitignore                  # Git exclusions
└── README.md                   # This file
```

## Tech Stack

| Layer | Technology |
|-------|------------|
| Language | VB.NET |
| Framework | .NET 8 (Windows Forms) |
| Database | SQLite (Microsoft.Data.Sqlite) |
| ORM/Data Access | ADO.NET (raw SQL via repositories) |
| Password Hashing | BCrypt |
| UI | Windows Forms |

## Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community edition works)
- .NET 8 Desktop Runtime

### Running the Project

1. **Clone the repository**
   ```bash
   git clone https://github.com/waithakalenny3-dot/SaccoSavingSystem.git
   cd SaccoSavingSystem/src/SaccoManager
   ```

2. **Open in Visual Studio**
   - Double-click `SaccoManager.vbproj` to open in Visual Studio
   - Or: File → Open → Project/Solution → select `SaccoManager.vbproj`

3. **Build and Run**
   - Press `F5` or click **Start** in Visual Studio
   - The SQLite database (`sacco.db`) will be created automatically on first run

4. **Default Login**
   - Check `DatabaseInitializer.vb` in the BLL/Services folder for default credentials

## Database Schema

See `Database/sacco_schema.sql` for the full SQL schema including tables for:
- `members` — SACCO member profiles
- `accounts` — Savings accounts
- `savings_transactions` — Deposits and withdrawals
- `loans` — Loan records
- `loan_repayments` — Loan repayment schedule
- `users` — System users with hashed passwords

## Git Exclusions

The following are **not** committed to GitHub (see `.gitignore`):
- `bin/` — Compiled output
- `obj/` — Build intermediates
- `.vs/` — Visual Studio IDE files
- `*.user` — User-specific project settings
- `*.db` / `*.sqlite` — Local database files

## License

MIT

---

**Sacco Savings System © 2026**
