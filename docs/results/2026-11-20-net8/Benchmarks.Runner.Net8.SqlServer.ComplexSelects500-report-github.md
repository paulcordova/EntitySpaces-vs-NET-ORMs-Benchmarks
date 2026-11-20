```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                        | Mean       | Error      | StdDev      | Median    | Gen0      | Gen1      | Allocated |
|---------------------------------------------- |-----------:|-----------:|------------:|----------:|----------:|----------:|----------:|
| &#39;Select 500 Complex Address Dapper&#39;           |   471.0 ms |   198.3 ms |   131.19 ms | 425.22 ms | 2000.0000 | 1000.0000 |  12.42 MB |
| &#39;Select 500 Complex Address EF Core&#39;          | 1,472.8 ms | 2,582.4 ms | 1,708.10 ms | 880.27 ms | 5000.0000 | 1000.0000 |  27.72 MB |
| &#39;Select 500 Complex Address EF6&#39;              |   111.5 ms |   463.6 ms |   306.67 ms |  14.16 ms | 1000.0000 |         - |   2.18 MB |
| &#39;Select 500 Complex Address EntitySpaces2026&#39; |   152.0 ms |   133.7 ms |    88.45 ms | 125.06 ms | 2000.0000 | 1000.0000 |  14.69 MB |
