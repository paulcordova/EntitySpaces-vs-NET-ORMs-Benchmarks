```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                      | Mean      | Error     | StdDev    | Median    | Gen0      | Allocated  |
|-------------------------------------------- |----------:|----------:|----------:|----------:|----------:|-----------:|
| &#39;Select 5 Complex Address Dapper&#39;           |  34.54 ms | 155.73 ms | 103.00 ms |  1.979 ms |         - |   93.64 KB |
| &#39;Select 5 Complex Address EF Core&#39;          | 116.69 ms | 500.73 ms | 331.20 ms |  4.262 ms |         - |  351.75 KB |
| &#39;Select 5 Complex Address EF6&#39;              | 142.13 ms | 612.68 ms | 405.25 ms | 14.524 ms | 1000.0000 | 2523.97 KB |
| &#39;Select 5 Complex Address EntitySpaces2026&#39; |  27.63 ms | 120.50 ms |  79.70 ms |  2.221 ms |         - |  219.02 KB |
