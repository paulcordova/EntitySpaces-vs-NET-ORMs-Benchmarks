```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Median   | Gen0      | Allocated |
|---------------------------------- |----------:|----------:|----------:|---------:|----------:|----------:|
| &#39;Select 500 Product Ado&#39;          |  27.84 ms | 111.23 ms |  73.57 ms | 4.887 ms |         - | 445.34 KB |
| &#39;Select 500 Product Dapper&#39;       |  33.77 ms | 145.21 ms |  96.05 ms | 3.293 ms |         - | 397.16 KB |
| &#39;Select 500 Product Ef Core&#39;      | 102.52 ms | 460.82 ms | 304.80 ms | 6.040 ms |         - | 774.34 KB |
| &#39;Select 500 Product Ef 6&#39;         | 116.59 ms | 521.68 ms | 345.06 ms | 7.506 ms | 1000.0000 | 2682.7 KB |
| &#39;Select 500 Product EntitySpaces&#39; |  20.09 ms |  73.91 ms |  48.88 ms | 4.666 ms |         - | 838.73 KB |
