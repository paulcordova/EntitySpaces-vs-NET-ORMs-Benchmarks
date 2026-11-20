```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                       | Mean      | Error     | StdDev    | Median   | Allocated |
|--------------------------------------------- |----------:|----------:|----------:|---------:|----------:|
| &#39;Insert 1 Complex Customer Dapper&#39;           |  95.59 ms | 364.90 ms | 241.36 ms | 19.20 ms |   1.55 MB |
| &#39;Insert 1 Complex Customer EF6&#39;              | 135.00 ms | 458.16 ms | 303.05 ms | 40.71 ms |   2.91 MB |
| &#39;Insert 1 Complex Customer EF Core&#39;          | 159.06 ms | 635.14 ms | 420.11 ms | 24.76 ms |    1.8 MB |
| &#39;Insert 1 Complex Customer EntitySpaces2026&#39; |  56.38 ms | 117.81 ms |  77.92 ms | 32.31 ms |   1.68 MB |
