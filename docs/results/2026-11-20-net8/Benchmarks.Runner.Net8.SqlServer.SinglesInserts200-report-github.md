```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                | Mean     | Error     | StdDev    | Median   | Gen0      | Gen1      | Allocated |
|-------------------------------------- |---------:|----------:|----------:|---------:|----------:|----------:|----------:|
| &#39;Insert 200 Products Ado&#39;             | 232.9 ms | 154.64 ms | 102.28 ms | 195.5 ms |         - |         - |   2.63 MB |
| &#39;Insert 200 Products SqlBulkCopy&#39;     | 134.7 ms |  81.27 ms |  53.76 ms | 107.5 ms |         - |         - |    1.9 MB |
| &#39;Insert 200 Products Dapper&#39;          | 214.1 ms | 131.25 ms |  86.81 ms | 177.6 ms | 1000.0000 |         - |   2.67 MB |
| &#39;Insert 200 Products Ef Core 6&#39;       | 221.1 ms | 506.25 ms | 334.85 ms | 112.0 ms |         - |         - |   5.55 MB |
| &#39;Insert 200 Products Ef 6&#39;            | 246.0 ms | 311.26 ms | 205.88 ms | 182.2 ms | 2000.0000 | 1000.0000 |  13.55 MB |
| &#39;Insert 200 Product EntitySpaces2026&#39; | 334.7 ms | 100.19 ms |  66.27 ms | 314.3 ms | 1000.0000 |         - |   4.62 MB |
