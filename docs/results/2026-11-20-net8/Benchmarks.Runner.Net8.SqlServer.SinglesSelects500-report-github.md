```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Median   | Gen0      | Allocated  |
|---------------------------------- |----------:|----------:|----------:|---------:|----------:|-----------:|
| &#39;Select 500 Product Ado&#39;          |  16.26 ms |  57.61 ms |  38.11 ms | 4.003 ms |         - |  768.46 KB |
| &#39;Select 500 Product Dapper&#39;       |  26.11 ms | 107.37 ms |  71.02 ms | 3.725 ms |         - |  834.46 KB |
| &#39;Select 500 Product Ef Core 6&#39;    | 113.82 ms | 515.76 ms | 341.14 ms | 5.875 ms |         - | 1002.16 KB |
| &#39;Select 500 Product Ef 6&#39;         |  86.43 ms | 375.84 ms | 248.59 ms | 7.869 ms | 1000.0000 | 2684.33 KB |
| &#39;Select 500 Product EntitySpaces&#39; |  17.54 ms |  64.52 ms |  42.67 ms | 3.847 ms |         - |  841.97 KB |
