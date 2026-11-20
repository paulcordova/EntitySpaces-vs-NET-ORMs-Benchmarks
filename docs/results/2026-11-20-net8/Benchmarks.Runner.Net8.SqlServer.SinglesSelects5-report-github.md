```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                          | Mean      | Error     | StdDev    | Median    | Allocated |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|
| &#39;Select 5 Product Ado&#39;          |  13.24 ms |  58.94 ms |  38.99 ms | 0.6068 ms |  16.64 KB |
| &#39;Select 5 Product Dapper&#39;       |  22.73 ms | 105.38 ms |  69.70 ms | 0.5044 ms |   16.9 KB |
| &#39;Select 5 Product Ef Core 6&#39;    | 109.62 ms | 517.59 ms | 342.35 ms | 1.1029 ms |  32.73 KB |
| &#39;Select 5 Product Ef 6&#39;         |  78.60 ms | 368.75 ms | 243.91 ms | 1.3898 ms |  76.31 KB |
| &#39;Select 5 Product EntitySpaces&#39; |  14.15 ms |  63.31 ms |  41.88 ms | 0.7941 ms |  38.86 KB |
