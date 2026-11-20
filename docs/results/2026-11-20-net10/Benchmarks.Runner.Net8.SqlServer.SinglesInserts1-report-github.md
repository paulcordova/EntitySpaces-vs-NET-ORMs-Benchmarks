```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                              | Mean      | Error     | StdDev    | Median   | Allocated |
|------------------------------------ |----------:|----------:|----------:|---------:|----------:|
| &#39;Insert 1 Product Ado&#39;              |  56.02 ms | 241.65 ms | 159.84 ms | 5.163 ms | 755.38 KB |
| &#39;Insert 1 Product Ado SqlBulkCopy&#39;  |  36.30 ms | 133.35 ms |  88.20 ms | 8.305 ms | 785.64 KB |
| &#39;Insert 1 Product Dapper&#39;           |  49.45 ms | 213.80 ms | 141.42 ms | 4.829 ms | 758.19 KB |
| &#39;Insert 1 Product Ef Core&#39;          | 119.62 ms | 549.83 ms | 363.68 ms | 4.290 ms | 777.85 KB |
| &#39;Insert 1 Product Ef 6&#39;             |  97.83 ms | 444.00 ms | 293.68 ms | 4.596 ms | 853.16 KB |
| &#39;Insert 1 Product EntitySpaces2026&#39; |  23.01 ms |  90.28 ms |  59.71 ms | 4.120 ms | 761.29 KB |
