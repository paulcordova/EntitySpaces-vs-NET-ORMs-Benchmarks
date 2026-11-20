```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                      | Mean      | Error     | StdDev    | Median    | Allocated |
|-------------------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 1 Complex Address Dapper&#39;           |  29.26 ms | 135.64 ms |  89.72 ms | 0.7454 ms |  38.89 KB |
| &#39;Select 1 Complex Address EF Core&#39;          | 122.06 ms | 545.87 ms | 361.06 ms | 2.6559 ms | 210.16 KB |
| &#39;Select 1 Complex Address EF6&#39;              |  82.32 ms | 372.41 ms | 246.33 ms | 4.4518 ms | 310.55 KB |
| &#39;Select 1 Complex Address EntitySpaces2026&#39; |  23.93 ms | 108.52 ms |  71.78 ms | 1.0267 ms | 127.83 KB |
