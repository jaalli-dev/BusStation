# Lunch Break Manager

```sh
# Run in terminal from solution root
dotnet run --project LunchBreakManagerCLI

# With input file
dotnet run --project LunchBreakManagerCLI -- -filename assets/testdata1.csv
```

### Solution structure

> LunchBreakManagerCLI - Console application

> LunchBreakManagerCore - Business logic module

> LunchBreakManagerCore.Tests - Test module

### Description

LunchBreakManagerCLI is a simple interactive CLI application that calculates simple statistics based on employees 
lunch times. More specifically, the greatest number of employees that are having a break at the same time and all 
respective time periods.

### Remarks

1. Core is usable independently
2. Core is structured into replaceable services
3. CLI could easily be replaced with any other UI
4. No input validation
5. CLI Context is effectively container for globals
