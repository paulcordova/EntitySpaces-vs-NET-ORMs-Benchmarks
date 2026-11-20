```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                          | Mean      | Error     | StdDev    | Median    | Allocated |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 1 Product Ado&#39;          |  24.05 ms | 110.42 ms |  73.04 ms | 0.5968 ms |   7.73 KB |
| &#39;Select 1 Product Dapper&#39;       |  30.23 ms | 140.52 ms |  92.94 ms | 0.5261 ms |   6.34 KB |
| &#39;Select 1 Product Ef Core&#39;      |  97.25 ms | 457.71 ms | 302.75 ms | 1.0226 ms |  13.71 KB |
| &#39;Select 1 Product Ef 6&#39;         | 102.70 ms | 483.90 ms | 320.07 ms | 1.3982 ms |  57.45 KB |
| &#39;Select 1 Product EntitySpaces&#39; |  16.27 ms |  73.97 ms |  48.93 ms | 0.5683 ms |  29.45 KB |
