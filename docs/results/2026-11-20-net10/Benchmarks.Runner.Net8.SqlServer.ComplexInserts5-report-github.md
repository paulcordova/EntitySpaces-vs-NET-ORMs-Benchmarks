```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                        | Mean     | Error    | StdDev    | Median    | Gen0      | Gen1      | Allocated |
|---------------------------------------------- |---------:|---------:|----------:|----------:|----------:|----------:|----------:|
| &#39;Insert 5 Complex Customers Dapper&#39;           | 144.8 ms | 349.8 ms | 231.37 ms |  73.54 ms | 1000.0000 |         - |   6.76 MB |
| &#39;Insert 5 Complex Customer EF6&#39;               | 240.1 ms | 581.8 ms | 384.84 ms | 122.26 ms | 2000.0000 | 1000.0000 |  13.63 MB |
| &#39;Insert 5 Complex Customer EF Core&#39;           | 230.7 ms | 644.5 ms | 426.28 ms | 100.78 ms | 2000.0000 | 1000.0000 |   8.08 MB |
| &#39;Insert 5 Complex Customers EntitySpaces2026&#39; | 128.2 ms | 133.5 ms |  88.31 ms | 100.70 ms | 1000.0000 |         - |   7.26 MB |
