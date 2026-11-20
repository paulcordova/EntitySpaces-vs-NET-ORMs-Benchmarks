```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                             | Mean      | Error     | StdDev    | Median   | Gen0       | Allocated |
|----------------------------------- |----------:|----------:|----------:|---------:|-----------:|----------:|
| &#39;Select 5000 Product Ado&#39;          |  51.57 ms | 114.18 ms |  75.52 ms | 26.77 ms |          - |    4.3 MB |
| &#39;Select 5000 Product Dapper&#39;       |  56.16 ms | 146.34 ms |  96.80 ms | 25.52 ms |  1000.0000 |   3.84 MB |
| &#39;Select 5000 Product Ef Core&#39;      | 142.99 ms | 485.63 ms | 321.21 ms | 40.82 ms |  3000.0000 |   7.46 MB |
| &#39;Select 5000 Product Ef 6&#39;         | 179.67 ms | 591.93 ms | 391.52 ms | 56.11 ms | 12000.0000 |  25.67 MB |
| &#39;Select 5000 Product EntitySpaces&#39; |  51.90 ms |  77.01 ms |  50.93 ms | 32.31 ms |  1000.0000 |   8.54 MB |
