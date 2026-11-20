```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                        | Mean     | Error    | StdDev    | Median    | Gen0      | Gen1      | Allocated |
|---------------------------------------------- |---------:|---------:|----------:|----------:|----------:|----------:|----------:|
| &#39;Insert 5 Complex Customers Dapper&#39;           | 137.9 ms | 242.1 ms | 160.15 ms |  87.22 ms | 1000.0000 |         - |   7.69 MB |
| &#39;Insert 5 Complex Customer EF6&#39;               | 227.4 ms | 439.5 ms | 290.72 ms | 139.53 ms | 2000.0000 | 1000.0000 |  14.17 MB |
| &#39;Insert 5 Complex Customer EF Core&#39;           | 224.6 ms | 657.8 ms | 435.09 ms |  87.74 ms | 1000.0000 |         - |    8.8 MB |
| &#39;Insert 5 Complex Customers EntitySpaces2026&#39; | 132.4 ms | 117.1 ms |  77.45 ms | 108.79 ms | 1000.0000 |         - |   8.27 MB |
