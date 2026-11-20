```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                              | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------------------ |----------:|----------:|----------:|----------:|----------:|
| &#39;Insert 5 Product Ado&#39;              |  45.59 ms | 149.84 ms |  99.11 ms | 14.963 ms | 827.91 KB |
| &#39;Insert 5 Product Ado SqlBulkCopy&#39;  |  28.54 ms |  61.79 ms |  40.87 ms | 17.113 ms | 826.23 KB |
| &#39;Insert 5 Product Dapper&#39;           |  39.96 ms | 123.07 ms |  81.40 ms | 14.995 ms | 841.21 KB |
| &#39;Insert 5 Product Ef Core 6&#39;        | 114.61 ms | 503.41 ms | 332.97 ms |  9.076 ms | 906.63 KB |
| &#39;Insert 5 Product Ef 6&#39;             |  79.63 ms | 327.37 ms | 216.54 ms | 11.049 ms | 1137.8 KB |
| &#39;Insert 5 Product EntitySpaces2026&#39; |  31.05 ms |  80.75 ms |  53.41 ms | 14.062 ms | 868.64 KB |
