```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                         | Mean     | Error    | StdDev    | Median   | Gen0       | Gen1      | Allocated |
|----------------------------------------------- |---------:|---------:|----------:|---------:|-----------:|----------:|----------:|
| &#39;Insert 20 Complex Customers Dapper&#39;           | 281.8 ms | 264.1 ms | 174.68 ms | 229.4 ms |  6000.0000 | 4000.0000 |  30.71 MB |
| &#39;Insert 20 Complex Customer EF6&#39;               | 435.3 ms | 426.0 ms | 281.75 ms | 352.2 ms | 12000.0000 | 2000.0000 |  56.38 MB |
| &#39;Insert 20 Complex Customer EF Core&#39;           | 353.4 ms | 654.0 ms | 432.57 ms | 219.7 ms |  5000.0000 | 2000.0000 |  35.13 MB |
| &#39;Insert 20 Complex Customers EntitySpaces2026&#39; | 274.5 ms | 122.6 ms |  81.11 ms | 257.5 ms |  5000.0000 | 1000.0000 |     33 MB |
