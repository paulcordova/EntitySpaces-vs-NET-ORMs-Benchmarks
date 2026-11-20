```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                      | Mean      | Error     | StdDev    | Median   | Allocated |
|-------------------------------------------- |----------:|----------:|----------:|---------:|----------:|
| &#39;Select 5 Complex Address Dapper&#39;           |  26.17 ms | 117.43 ms |  77.67 ms | 1.579 ms |  140.7 KB |
| &#39;Select 5 Complex Address EF Core&#39;          | 120.65 ms | 533.30 ms | 352.75 ms | 4.169 ms | 440.81 KB |
| &#39;Select 5 Complex Address EF6&#39;              |  82.02 ms | 366.45 ms | 242.38 ms | 4.150 ms | 334.38 KB |
| &#39;Select 5 Complex Address EntitySpaces2026&#39; |  23.82 ms | 103.71 ms |  68.60 ms | 1.990 ms | 225.14 KB |
