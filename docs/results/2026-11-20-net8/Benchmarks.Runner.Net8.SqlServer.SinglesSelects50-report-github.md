```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                           | Mean      | Error     | StdDev    | Median    | Allocated |
|--------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 50 Product Ado&#39;          |  13.37 ms |  57.75 ms |  38.20 ms | 0.9508 ms |  87.02 KB |
| &#39;Select 50 Product Dapper&#39;       |  23.14 ms | 105.11 ms |  69.52 ms | 0.8163 ms |  93.26 KB |
| &#39;Select 50 Product Ef Core 6&#39;    | 109.97 ms | 515.42 ms | 340.92 ms | 1.7956 ms | 121.14 KB |
| &#39;Select 50 Product Ef 6&#39;         |  79.31 ms | 367.87 ms | 243.32 ms | 2.3344 ms | 314.61 KB |
| &#39;Select 50 Product EntitySpaces&#39; |  14.10 ms |  63.48 ms |  41.99 ms | 0.6042 ms |  32.98 KB |
