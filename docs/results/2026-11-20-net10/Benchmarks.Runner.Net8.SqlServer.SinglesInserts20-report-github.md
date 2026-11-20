```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                               | Mean      | Error     | StdDev    | Median   | Gen0      | Allocated  |
|------------------------------------- |----------:|----------:|----------:|---------:|----------:|-----------:|
| &#39;Insert 20 Products Ado&#39;             |  60.40 ms | 215.93 ms | 142.83 ms | 15.63 ms |         - |  910.17 KB |
| &#39;Insert 20 Products SqlBulkCopy&#39;     |  38.47 ms |  93.65 ms |  61.94 ms | 16.43 ms |         - |  893.41 KB |
| &#39;Insert 20 Products Dapper&#39;          |  53.15 ms | 154.29 ms | 102.05 ms | 20.35 ms |         - |   924.2 KB |
| &#39;Insert 20 Products Ef Core&#39;         | 109.90 ms | 451.27 ms | 298.49 ms | 16.61 ms |         - |    1202 KB |
| &#39;Insert 20 Products Ef 6&#39;            | 115.51 ms | 451.96 ms | 298.94 ms | 20.70 ms | 1000.0000 | 2105.09 KB |
| &#39;Insert 20 Product EntitySpaces2026&#39; |  69.24 ms |  91.43 ms |  60.48 ms | 45.58 ms |         - |  1064.7 KB |
