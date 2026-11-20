```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100
  [Host]     : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 8.0.34 (8.0.34, 8.0.3426.52217), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                                       | Mean      | Error     | StdDev    | Median    | Gen0      | Allocated  |
|--------------------------------------------- |----------:|----------:|----------:|----------:|----------:|-----------:|
| &#39;Select 50 Complex Address Dapper&#39;           |  33.80 ms | 122.68 ms |  81.14 ms |  8.221 ms |         - | 1275.94 KB |
| &#39;Select 50 Complex Address EF Core&#39;          | 192.19 ms | 705.13 ms | 466.40 ms | 21.300 ms | 1000.0000 | 2977.53 KB |
| &#39;Select 50 Complex Address EF6&#39;              | 109.48 ms | 490.10 ms | 324.17 ms |  5.354 ms |         - |  488.64 KB |
| &#39;Select 50 Complex Address EntitySpaces2026&#39; |  92.45 ms | 382.64 ms | 253.09 ms | 12.483 ms |         - | 1452.28 KB |
