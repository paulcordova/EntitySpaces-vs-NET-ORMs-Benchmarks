```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                        | Mean     | Error    | StdDev    | Median   | Gen0       | Gen1      | Allocated |
|---------------------------------------------- |---------:|---------:|----------:|---------:|-----------:|----------:|----------:|
| &#39;Select 500 Complex Address Dapper&#39;           | 449.8 ms | 165.8 ms | 109.63 ms | 412.6 ms |  1000.0000 |         - |   8.14 MB |
| &#39;Select 500 Complex Address EF Core&#39;          | 284.0 ms | 503.2 ms | 332.86 ms | 189.6 ms |  4000.0000 | 1000.0000 |   23.7 MB |
| &#39;Select 500 Complex Address EF6&#39;              | 673.1 ms | 650.2 ms | 430.08 ms | 527.8 ms | 14000.0000 | 2000.0000 |  85.91 MB |
| &#39;Select 500 Complex Address EntitySpaces2026&#39; | 141.8 ms | 138.8 ms |  91.83 ms | 112.6 ms |  3000.0000 | 1000.0000 |  14.87 MB |
