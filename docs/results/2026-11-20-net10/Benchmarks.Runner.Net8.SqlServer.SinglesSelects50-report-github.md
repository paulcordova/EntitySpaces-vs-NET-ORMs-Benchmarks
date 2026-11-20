```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                           | Mean      | Error     | StdDev    | Median    | Allocated |
|--------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 50 Product Ado&#39;          |  24.26 ms | 109.69 ms |  72.55 ms | 1.0626 ms |  51.62 KB |
| &#39;Select 50 Product Dapper&#39;       |  30.53 ms | 141.15 ms |  93.36 ms | 0.8056 ms |  45.15 KB |
| &#39;Select 50 Product Ef Core&#39;      |  97.42 ms | 455.53 ms | 301.31 ms | 1.7441 ms |  87.55 KB |
| &#39;Select 50 Product Ef 6&#39;         | 103.77 ms | 486.52 ms | 321.80 ms | 1.7591 ms | 312.92 KB |
| &#39;Select 50 Product EntitySpaces&#39; |  17.07 ms |  74.53 ms |  49.30 ms | 1.1417 ms | 103.21 KB |
