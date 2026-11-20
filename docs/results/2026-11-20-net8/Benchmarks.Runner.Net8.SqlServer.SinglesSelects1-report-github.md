```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                          | Mean      | Error     | StdDev    | Median    | Allocated |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 1 Product Ado&#39;          |  12.98 ms |  57.84 ms |  38.26 ms | 0.6136 ms |  10.59 KB |
| &#39;Select 1 Product Dapper&#39;       |  22.52 ms | 103.70 ms |  68.59 ms | 0.5685 ms |  10.31 KB |
| &#39;Select 1 Product Ef Core 6&#39;    | 109.77 ms | 518.48 ms | 342.94 ms | 1.0390 ms |  27.47 KB |
| &#39;Select 1 Product Ef 6&#39;         |  79.37 ms | 372.27 ms | 246.23 ms | 1.3764 ms |  58.23 KB |
| &#39;Select 1 Product EntitySpaces&#39; |  14.53 ms |  65.14 ms |  43.09 ms | 0.6650 ms |  32.98 KB |
