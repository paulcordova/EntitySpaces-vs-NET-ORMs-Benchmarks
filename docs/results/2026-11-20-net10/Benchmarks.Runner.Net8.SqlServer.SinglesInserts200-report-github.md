```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                | Mean     | Error     | StdDev    | Median    | Gen0      | Gen1      | Allocated |
|-------------------------------------- |---------:|----------:|----------:|----------:|----------:|----------:|----------:|
| &#39;Insert 200 Products Ado&#39;             | 198.8 ms | 211.70 ms | 140.03 ms | 150.90 ms |         - |         - |   2.63 MB |
| &#39;Insert 200 Products SqlBulkCopy&#39;     | 106.0 ms |  99.28 ms |  65.67 ms |  94.10 ms |         - |         - |   1.91 MB |
| &#39;Insert 200 Products Dapper&#39;          | 165.1 ms | 186.50 ms | 123.36 ms | 128.27 ms | 1000.0000 |         - |   2.47 MB |
| &#39;Insert 200 Products Ef Core&#39;         | 179.6 ms | 436.91 ms | 288.99 ms |  92.48 ms | 1000.0000 |         - |   5.09 MB |
| &#39;Insert 200 Products Ef 6&#39;            | 258.1 ms | 425.27 ms | 281.29 ms | 171.37 ms | 2000.0000 | 1000.0000 |  13.61 MB |
| &#39;Insert 200 Product EntitySpaces2026&#39; | 337.5 ms | 144.02 ms |  95.26 ms | 303.33 ms | 1000.0000 |         - |   3.91 MB |
