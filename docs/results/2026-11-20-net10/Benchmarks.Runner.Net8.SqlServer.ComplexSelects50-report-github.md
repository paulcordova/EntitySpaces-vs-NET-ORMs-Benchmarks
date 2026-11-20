```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                       | Mean      | Error     | StdDev    | Median    | Gen0      | Allocated   |
|--------------------------------------------- |----------:|----------:|----------:|----------:|----------:|------------:|
| &#39;Select 50 Complex Address Dapper&#39;           |  40.60 ms | 154.32 ms | 102.07 ms |  8.720 ms |         - |   837.87 KB |
| &#39;Select 50 Complex Address EF Core&#39;          | 133.05 ms | 506.93 ms | 335.30 ms | 20.162 ms |         - |  2529.67 KB |
| &#39;Select 50 Complex Address EF6&#39;              | 158.83 ms | 558.02 ms | 369.09 ms | 39.436 ms | 1000.0000 | 10315.58 KB |
| &#39;Select 50 Complex Address EntitySpaces2026&#39; |  35.99 ms | 118.73 ms |  78.53 ms | 11.409 ms |         - |  1470.52 KB |
