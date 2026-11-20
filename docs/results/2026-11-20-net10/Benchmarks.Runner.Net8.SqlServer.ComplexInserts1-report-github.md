```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                       | Mean      | Error     | StdDev    | Median   | Gen0      | Allocated |
|--------------------------------------------- |----------:|----------:|----------:|---------:|----------:|----------:|
| &#39;Insert 1 Complex Customer Dapper&#39;           |  88.52 ms | 347.72 ms | 229.99 ms | 15.94 ms |         - |   1.36 MB |
| &#39;Insert 1 Complex Customer EF6&#39;              | 182.04 ms | 676.06 ms | 447.17 ms | 39.01 ms | 1000.0000 |   2.81 MB |
| &#39;Insert 1 Complex Customer EF Core&#39;          | 161.49 ms | 680.98 ms | 450.42 ms | 18.83 ms |         - |   1.63 MB |
| &#39;Insert 1 Complex Customer EntitySpaces2026&#39; |  58.18 ms | 151.02 ms |  99.89 ms | 26.24 ms |         - |   1.48 MB |
