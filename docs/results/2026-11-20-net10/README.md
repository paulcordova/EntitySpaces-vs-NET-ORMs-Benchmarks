# Benchmark run — 2026-11-20 (.NET 10, EntitySpaces 2026.11)

Raw BenchmarkDotNet output for the current stack: **.NET 10 LTS**, EntitySpaces 2026.11, EF Core 10,
Dapper 2.1.100 and `Microsoft.Data.SqlClient` 7.1.2. This is the run the top-level README quotes.

## Environment

| Item | Value |
|---|---|
| Machine | AMD Ryzen 5 PRO 4650U — 6 physical / 12 logical cores, 2.10 GHz |
| OS | Windows 10 22H2 (10.0.19045.6466) |
| Runtime | .NET 10.0.15, X64 RyuJIT (x86-64-v3) |
| SDK | .NET 10.0.404 (pinned in `global.json`) |
| Database | SQL Server 2016 SP2 Express (13.0.5026.0), instance `VANHALEN\SQLEXPRESS`, database `CamparationEntityDapper` |
| Run | 2026-11-20, 18:53–19:06 (local time, UTC-3) |

## Versions under test

| Component | Version |
|---|---|
| EntitySpaces | `EntitySpaces.ORM.SqlServer.NET` 2026.11.0 (entities generated with EntitySpaces Studio 2026.11.0001.0) |
| Dapper | 2.1.100 |
| EF Core | `Microsoft.EntityFrameworkCore.SqlServer` 10.0.15 |
| EF6 | `EntityFramework` 6.5.2 |
| SQL client | `Microsoft.Data.SqlClient` 7.1.2 (ADO.NET, Dapper, EF Core and EntitySpaces); EF6 keeps `System.Data.SqlClient` |
| BenchmarkDotNet | 0.15.8 |

## Configuration

`SimpleJob(RunStrategy.ColdStart, iterationCount: 10, warmupCount: 3)` with `MemoryDiagnoser`, per
class. Eighteen classes: single-table reads and writes, graph reads and writes, plus two
EntitySpaces isolation runs.

## What is different from the .NET 8 baseline

The baseline in [`../2026-11-20-net8/`](../2026-11-20-net8) was captured with .NET 8, EF Core 8,
EntitySpaces 2026.8 and a mixed SQL client driver. Three things changed besides the runtime:

1. **The driver is unified.** ADO.NET and Dapper used to run on the `System.Data.SqlClient` 4.8.6
   that EF6 pulls transitively while EntitySpaces and EF Core used `Microsoft.Data.SqlClient`; every
   stack except EF6 now uses `Microsoft.Data.SqlClient` 7.1.2.
2. **Two graph-read implementations were fixed.** EF6's `Include("...")` and `AsNoTracking()` were
   binding to the EF Core extensions (the file imports both namespaces), so EF6 loaded addresses
   without customers; EntitySpaces grouped by the entity `Id`, which is not part of the projection,
   collapsing 500 addresses into one. `--validate` exposed both; `migration-vs-net8.csv` reflects the
   corrected queries.
3. **The EntitySpaces 50-row read was fixed** (`SelectSingleProducts(1)` → `(50)`), so that cell is
   comparable now.

## Files

| File | Content |
|---|---|
| `*-report-github.md` | Tables as published by BenchmarkDotNet (Mean, Error, StdDev, Median, Allocated), one per class |
| `*-report.csv` | Full statistics per benchmark, machine-readable |
| `bdn-logs.zip` | Console logs, including the four graph classes that were re-run after the fix |
| `migration-vs-net8.csv` | Median and allocation deltas against the .NET 8 baseline, per benchmark |

## Regenerating the tables

```powershell
pwsh tools/parse-bdn-artifacts.ps1 -Artifacts <path-to-BenchmarkDotNet.Artifacts> -Out <output-dir>
```
