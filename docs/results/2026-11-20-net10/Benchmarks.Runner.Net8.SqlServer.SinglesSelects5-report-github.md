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
| &#39;Select 5 Product Ado&#39;          |  23.64 ms | 108.12 ms |  71.51 ms | 0.7315 ms |  11.24 KB |
| &#39;Select 5 Product Dapper&#39;       |  30.22 ms | 140.97 ms |  93.24 ms | 0.5198 ms |   9.47 KB |
| &#39;Select 5 Product Ef Core&#39;      |  97.13 ms | 456.85 ms | 302.18 ms | 1.1378 ms |  17.28 KB |
| &#39;Select 5 Product Ef 6&#39;         | 103.23 ms | 486.08 ms | 321.51 ms | 1.3708 ms |  75.53 KB |
| &#39;Select 5 Product EntitySpaces&#39; |  15.99 ms |  72.60 ms |  48.02 ms | 0.5752 ms |  35.33 KB |
