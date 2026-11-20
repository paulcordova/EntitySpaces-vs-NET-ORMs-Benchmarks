```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                             | Mean      | Error     | StdDev    | Median   | Gen0       | Allocated |
|----------------------------------- |----------:|----------:|----------:|---------:|-----------:|----------:|
| &#39;Select 5000 Product Ado&#39;          |  43.57 ms |  63.22 ms |  41.81 ms | 30.05 ms |  1000.0000 |   7.36 MB |
| &#39;Select 5000 Product Dapper&#39;       |  52.71 ms | 108.57 ms |  71.81 ms | 32.50 ms |  1000.0000 |   8.02 MB |
| &#39;Select 5000 Product Ef Core 6&#39;    | 154.94 ms | 531.82 ms | 351.77 ms | 42.14 ms |  4000.0000 |   9.54 MB |
| &#39;Select 5000 Product Ef 6&#39;         | 151.48 ms | 461.23 ms | 305.07 ms | 54.64 ms | 12000.0000 |  25.66 MB |
| &#39;Select 5000 Product EntitySpaces&#39; |  49.99 ms |  64.78 ms |  42.85 ms | 34.48 ms |  1000.0000 |   8.54 MB |
