```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6466/22H2/2022Update)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 2.10GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.404
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3
  Job-SLVDPW : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v3

IterationCount=10  RunStrategy=ColdStart  WarmupCount=3  

```
| Method                          | Mean     | Error     | StdDev    | Median    | Allocated |
|-------------------------------- |---------:|----------:|----------:|----------:|----------:|
| &#39;Select 1 Product EntitySpaces&#39; | 60.68 ms | 286.10 ms | 189.24 ms | 0.6056 ms |  29.45 KB |
