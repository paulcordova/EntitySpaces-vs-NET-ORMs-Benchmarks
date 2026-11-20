```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                         | Mean     | Error    | StdDev    | Median   | Gen0       | Gen1      | Allocated |
|----------------------------------------------- |---------:|---------:|----------:|---------:|-----------:|----------:|----------:|
| &#39;Insert 20 Complex Customers Dapper&#39;           | 296.2 ms | 310.3 ms | 205.21 ms | 232.9 ms |  4000.0000 | 3000.0000 |     27 MB |
| &#39;Insert 20 Complex Customer EF6&#39;               | 468.9 ms | 609.7 ms | 403.28 ms | 327.1 ms | 11000.0000 | 3000.0000 |  54.18 MB |
| &#39;Insert 20 Complex Customer EF Core&#39;           | 375.0 ms | 674.2 ms | 445.92 ms | 236.4 ms |  5000.0000 | 4000.0000 |  32.31 MB |
| &#39;Insert 20 Complex Customers EntitySpaces2026&#39; | 302.0 ms | 138.7 ms |  91.75 ms | 275.6 ms |  5000.0000 | 3000.0000 |  28.97 MB |
