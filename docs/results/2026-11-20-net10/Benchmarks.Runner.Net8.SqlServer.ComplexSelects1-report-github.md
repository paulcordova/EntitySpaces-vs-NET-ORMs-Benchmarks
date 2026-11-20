```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                      | Mean      | Error     | StdDev    | Median     | Allocated  |
|-------------------------------------------- |----------:|----------:|----------:|-----------:|-----------:|
| &#39;Select 1 Complex Address Dapper&#39;           |  34.11 ms | 157.73 ms | 104.33 ms |  0.8629 ms |   27.31 KB |
| &#39;Select 1 Complex Address EF Core&#39;          | 114.99 ms | 498.64 ms | 329.82 ms |  2.4737 ms |  163.21 KB |
| &#39;Select 1 Complex Address EF6&#39;              | 129.90 ms | 571.77 ms | 378.19 ms | 10.4614 ms | 1826.91 KB |
| &#39;Select 1 Complex Address EntitySpaces2026&#39; |  26.29 ms | 118.43 ms |  78.33 ms |  1.2010 ms |  120.07 KB |
