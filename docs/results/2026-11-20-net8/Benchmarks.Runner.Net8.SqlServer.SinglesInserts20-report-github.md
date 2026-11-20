```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                               | Mean      | Error     | StdDev    | Median   | Gen0      | Allocated  |
|------------------------------------- |----------:|----------:|----------:|---------:|----------:|-----------:|
| &#39;Insert 20 Products Ado&#39;             |  60.95 ms | 152.89 ms | 101.13 ms | 29.85 ms |         - | 1005.21 KB |
| &#39;Insert 20 Products SqlBulkCopy&#39;     |  39.29 ms |  62.90 ms |  41.61 ms | 24.04 ms |         - |  912.97 KB |
| &#39;Insert 20 Products Dapper&#39;          |  69.98 ms | 120.50 ms |  79.70 ms | 47.09 ms |         - | 1036.09 KB |
| &#39;Insert 20 Products Ef Core 6&#39;       | 133.17 ms | 498.03 ms | 329.42 ms | 27.92 ms |         - | 1268.24 KB |
| &#39;Insert 20 Products Ef 6&#39;            |  98.87 ms | 326.75 ms | 216.13 ms | 31.38 ms | 1000.0000 | 2122.76 KB |
| &#39;Insert 20 Product EntitySpaces2026&#39; |  67.83 ms |  76.97 ms |  50.91 ms | 52.53 ms |         - |  1170.4 KB |
