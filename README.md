# C# File Integrity Checker <p align="right">
  <img width="200" height="200" alt="folder-lock-icon-file-protection-data-security-privacy-concept-safe-confidential-information-modern-flat-design-vector-83123834" src="https://github.com/user-attachments/assets/27754a08-47f6-4c08-bf9c-cba673b5836c" />
</p>


A simple cybersecurity tool written in C# that uses SHA-256 hashing to detect whether a file has been modified.

## Features

* Generates a SHA-256 hash for a file
* Saves the original hash
* Compares a file against its saved hash
* Detects changes to the file
* Runs through the command line
* Uses built-in C# libraries

## Requirements

* .NET SDK
* Windows, macOS, or Linux

## How to Run

1. Open the project folder in a terminal.
2. Run:

```bash
dotnet run
```

3. Enter the full path of the file you want to check.
4. Choose an option:

```text
1. Save this hash as the original
2. Compare with a saved hash
```

### Example

If you first save the original hash, the program creates a `.hash` file next to the original file.

If the file is later changed, the program compares the new SHA-256 hash with the original.

Example:

```text
Original SHA-256 Hash:
A1B2C3D4...

Checking file integrity...

STATUS: WARNING!
The file has been modified!
```

If the file has not changed:

```text
STATUS: FILE UNCHANGED ✓
```

## Technologies Used

* C#
* .NET
* SHA-256
* System.IO
* System.Security.Cryptography

## What I Learned

* How hashing works in cybersecurity
* How SHA-256 is used to check file integrity
* How to read and write files in C#
* How to work with file paths
* How to use C# classes and methods
* How to build a simple cybersecurity tool

## Cybersecurity Purpose

File integrity checking is used to detect unexpected changes to files.

This project demonstrates a basic version of this concept by creating a SHA-256 fingerprint of a file and comparing it against a previously saved fingerprint.

## Disclaimer

This project only checks whether the contents of a file have changed. It does not determine whether a file is safe or contains malware.
