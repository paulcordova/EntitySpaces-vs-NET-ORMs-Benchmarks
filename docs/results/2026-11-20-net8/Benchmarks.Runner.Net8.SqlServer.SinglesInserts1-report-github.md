```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                              | Mean      | Error     | StdDev    | Median   | Allocated |
|------------------------------------ |----------:|----------:|----------:|---------:|----------:|
| &#39;Insert 1 Product Ado&#39;              |  48.44 ms | 195.94 ms | 129.60 ms | 7.078 ms | 782.51 KB |
| &#39;Insert 1 Product Ado SqlBulkCopy&#39;  |  24.46 ms |  83.97 ms |  55.54 ms | 7.015 ms | 803.65 KB |
| &#39;Insert 1 Product Dapper&#39;           |  30.89 ms | 124.07 ms |  82.07 ms | 4.508 ms | 782.52 KB |
| &#39;Insert 1 Product Ef Core 6&#39;        | 114.12 ms | 516.01 ms | 341.31 ms | 5.935 ms | 811.29 KB |
| &#39;Insert 1 Product Ef 6&#39;             |  76.61 ms | 332.27 ms | 219.78 ms | 6.011 ms | 876.66 KB |
| &#39;Insert 1 Product EntitySpaces2026&#39; |  21.80 ms |  80.46 ms |  53.22 ms | 5.034 ms | 784.79 KB |
