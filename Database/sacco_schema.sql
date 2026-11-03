-- =====================================================================
-- Sacco Savings and Loan Management System - Database schema (SQLite)
-- 6 related tables, normalised to Third Normal Form (3NF).
-- Money amounts are stored as TEXT holding decimal strings (SQLite has
-- no exact decimal type; Microsoft.Data.Sqlite maps Decimal to TEXT).
-- Dates are stored as TEXT in ISO order (yyyy-MM-dd[ HH:mm:ss]).
-- =====================================================================

CREATE TABLE IF NOT EXISTS Users (
    UserID       INTEGER PRIMARY KEY AUTOINCREMENT,
    Username     TEXT    NOT NULL UNIQUE COLLATE NOCASE,
    PasswordHash TEXT    NOT NULL,                 -- SHA256 hex, never plain text
    Salt         TEXT    NOT NULL,                 -- random 32-byte hex salt
    FullName     TEXT    NOT NULL,
    Role         TEXT    NOT NULL CHECK (Role IN ('Administrator','Teller'))
);

CREATE TABLE IF NOT EXISTS Members (
    MemberID  INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberNo  TEXT    NOT NULL UNIQUE,
    FullName  TEXT    NOT NULL,
    Phone     TEXT    NOT NULL,
    Email     TEXT,                                 -- optional
    JoinDate  TEXT    NOT NULL,                     -- yyyy-MM-dd
    Status    TEXT    NOT NULL DEFAULT 'Active' CHECK (Status IN ('Active','Dormant','Closed'))
);

CREATE TABLE IF NOT EXISTS AccountTypes (
    TypeID     INTEGER PRIMARY KEY AUTOINCREMENT,
    TypeName   TEXT    NOT NULL UNIQUE,
    MinBalance TEXT    NOT NULL DEFAULT '0'          -- minimum balance the account may hold
);

CREATE TABLE IF NOT EXISTS Accounts (
    AccountID     INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberID      INTEGER NOT NULL REFERENCES Members(MemberID)     ON DELETE CASCADE,
    TypeID        INTEGER NOT NULL REFERENCES AccountTypes(TypeID),
    AccountNumber TEXT    NOT NULL UNIQUE,              -- generated as AC00001, AC00002, ...
    Balance       TEXT    NOT NULL DEFAULT '0'
);

CREATE TABLE IF NOT EXISTS Transactions (
    TransID   INTEGER PRIMARY KEY AUTOINCREMENT,
    AccountID INTEGER NOT NULL REFERENCES Accounts(AccountID) ON DELETE CASCADE,
    UserID    INTEGER NOT NULL REFERENCES Users(UserID),      -- teller who posted it
    TransDate TEXT    NOT NULL,                               -- yyyy-MM-dd HH:mm:ss
    TransType TEXT    NOT NULL CHECK (TransType IN ('Deposit','Withdrawal')),
    Amount    TEXT    NOT NULL,
    Note      TEXT
);

CREATE TABLE IF NOT EXISTS Loans (
    LoanID       INTEGER PRIMARY KEY AUTOINCREMENT,
    MemberID     INTEGER NOT NULL REFERENCES Members(MemberID) ON DELETE CASCADE,
    UserID       INTEGER NOT NULL REFERENCES Users(UserID),    -- officer who issued it
    LoanDate     TEXT    NOT NULL,                             -- yyyy-MM-dd
    Principal    TEXT    NOT NULL,
    InterestRate REAL    NOT NULL,                             -- annual %, e.g. 12.5
    TermMonths   INTEGER NOT NULL,
    TotalDue     TEXT    NOT NULL,                             -- principal + simple interest
    Installment  TEXT    NOT NULL,                             -- TotalDue / TermMonths
    AmountPaid   TEXT    NOT NULL DEFAULT '0',
    Status       TEXT    NOT NULL DEFAULT 'Active' CHECK (Status IN ('Active','Cleared','Defaulted'))
);

CREATE INDEX IF NOT EXISTS idx_members_name  ON Members(FullName);
CREATE INDEX IF NOT EXISTS idx_trans_date    ON Transactions(TransDate);
CREATE INDEX IF NOT EXISTS idx_trans_account ON Transactions(AccountID);
CREATE INDEX IF NOT EXISTS idx_loans_member  ON Loans(MemberID);
