```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                              | Mean      | Error     | StdDev    | Median    | Allocated  |
|------------------------------------ |----------:|----------:|----------:|----------:|-----------:|
| &#39;Insert 5 Product Ado&#39;              |  51.43 ms | 208.03 ms | 137.60 ms |  7.789 ms |  801.22 KB |
| &#39;Insert 5 Product Ado SqlBulkCopy&#39;  |  29.37 ms |  96.18 ms |  63.62 ms |  8.467 ms |  804.34 KB |
| &#39;Insert 5 Product Dapper&#39;           |  42.43 ms | 157.08 ms | 103.90 ms |  9.659 ms |  829.02 KB |
| &#39;Insert 5 Product Ef Core&#39;          |  97.10 ms | 435.37 ms | 287.97 ms |  5.752 ms |  886.94 KB |
| &#39;Insert 5 Product Ef 6&#39;             | 107.23 ms | 469.88 ms | 310.79 ms |  8.566 ms | 1124.12 KB |
| &#39;Insert 5 Product EntitySpaces2026&#39; |  30.20 ms |  91.62 ms |  60.60 ms | 11.258 ms |   842.3 KB |
