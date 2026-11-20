# Benchmark run — 2026-11-20 (.NET 8 baseline)

Raw BenchmarkDotNet output captured **before** the migration to .NET 10 / EntitySpaces 2026.11.
It is the "before" side of the migration-impact comparison in the top-level README and the
historical record of the EntitySpaces 2026.8 entity generation.

## Environment

| Item | Value |
|---|---|
| Machine | AMD Ryzen 5 PRO 4650U — 6 physical / 12 logical cores, 2.10 GHz |
| OS | Windows 10 22H2 (10.0.19045.6466) |
| Runtime | .NET 8.0.34, X64 RyuJIT (x86-64-v3) |
| Database | SQL Server Express, local instance `VANHALEN\SQLEXPRESS`, database `CamparationEntityDapper` |
| Run | 2026-11-20, 13:12–13:18 (local time, UTC-3) |

## Versions under test

| Component | Version |
|---|---|
| EntitySpaces | `EntitySpaces.ORM.SqlServer.NET` 2026.8.0 (entities generated with EntitySpaces Studio 2026.8.0020.0) |
| Dapper | 2.1.79 |
| EF Core | `Microsoft.EntityFrameworkCore.SqlServer` 8.0.30 |
| EF6 | `EntityFramework` 6.5.2 |
| ADO.NET | `System.Data.SqlClient` 4.8.6 (transitive) — see defect 2 |
| BenchmarkDotNet | 0.15.8 |

## Configuration

Every benchmark class uses `SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)`
with `MemoryDiagnoser`. Sixteen scenarios across 18 classes: single-table reads, single-table
writes, and graph reads/writes (address → customer → product → product page).

## Files

| File | Content |
|---|---|
| `*-report-github.md` | Tables as published by BenchmarkDotNet (Mean, Error, StdDev, Median, Allocated), one per class |
| `*-report.csv` | Full statistics per benchmark, machine-readable |
| `bdn-logs.zip` | Console logs for the 18 classes: outlier hints, `MinIterationTime` warnings, per-class timings |

## Known defects in this baseline

1. **`SinglesSelects50` measures a 1-row read for EntitySpaces** (`SelectSingleProducts(1)` instead
   of `50`), so the `Select 50 Product EntitySpaces` cell is not comparable. It was fixed after this
   snapshot; the raw data is kept as-is because this folder is a historical record.
2. **Driver mismatch.** ADO.NET and Dapper run on `System.Data.SqlClient` 4.8.6 while EntitySpaces
   and EF Core run on `Microsoft.Data.SqlClient` 7.x. Later runs unify the driver to
   `Microsoft.Data.SqlClient`; EF6 remains on `System.Data.SqlClient` because that is what EF6 uses
   internally.
3. **EF Core labels read "Ef Core 6"** although the package under test is 8.0.30 (historical label,
   renamed in later runs).

## Regenerating the tables from these artifacts

```powershell
pwsh tools/parse-bdn-artifacts.ps1 -Artifacts <path-to-BenchmarkDotNet.Artifacts> -Out <output-dir>
```

The parser reads the Markdown tables that BenchmarkDotNet writes both to `results/*-report-github.md`
and to the console log of each class, normalises times to milliseconds and memory to kilobytes, and
emits `measurements-all.csv` / `measurements-latest.csv` for downstream pivoting.
