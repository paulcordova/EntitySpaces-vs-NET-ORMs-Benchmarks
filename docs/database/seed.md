# Benchmark dataset

The benchmarks run against a single SQL Server database, `CamparationEntityDapper`, on the local
instance `VANHALEN\SQLEXPRESS`. The schema is created by the EF Core migrations in
`Benchmarks.Tests.Net8.SqlServer/Migrations`; the rows are seeded by the sample application and then
grown by every write benchmark, which commits its inserts.

## Shape

| Table | Rows (2026-11-20) | Notes |
|---|---:|---|
| `efdp_address` | 10,608 | root of the graph scenario |
| `efdp_customer` | 10,608 | exactly one customer per address |
| `efdp_product_page` | 106,080 | ten pages per customer |
| `efdp_product` | 1,027,837 | ten rows per customer are linked; the rest were inserted by the write benchmarks with no `customer_id` or `product_page_id` |

The graph scenarios traverse `address → customer → product → product_page`, so **500 addresses
produce exactly 5,000 joined rows**. The single-table reads use `TOP(n)` over `efdp_product`, which
is why that table's size matters: 1.03 M rows, of which only ~106 K participate in the graph.

## Why the counts matter

A latency comparison is only valid if every implementation loads the same number of rows. The
`--validate` switch checks that:

```powershell
dotnet run -c Release --project Benchmarks.Runner.Net8.SqlServer -- --validate
```

It prints addresses, customers and products per ORM and exits. Two graph-read implementations were
returning a different shape until this check was added; see the README section
*Validating the scenarios*.

## Verifying the counts

```sql
SELECT COUNT(*) FROM efdp_address;
SELECT COUNT(*) FROM efdp_customer;
SELECT COUNT(*) FROM efdp_product_page;
SELECT COUNT(*) FROM efdp_product;
SELECT COUNT(*) FROM efdp_product WHERE customer_id IS NOT NULL;   -- rows in the graph

-- rows the 500-address graph read has to materialize
SELECT COUNT(*)
FROM efdp_address ad
INNER JOIN efdp_customer c ON ad.Id = c.address_id
INNER JOIN efdp_product p ON c.Id = p.customer_id
INNER JOIN efdp_product_page pp ON p.product_page_id = pp.Id
WHERE ad.Id IN (SELECT TOP 500 Id FROM efdp_address ORDER BY Id);
```

Indexes that the join relies on: `PK_efdp_address(Id)`, `IX_efdp_customer_address_id`,
`IX_efdp_product_customer_id`, `IX_efdp_product_product_page_id`.

## Caveats

1. **The dataset is not reproducible from the repository.** There is no seeding script; the original
   sample application created the first customer/product graphs and the write benchmarks have been
   adding rows since. Counts above are recorded so a reader can tell whether a run is comparable.
2. **Write benchmarks mutate the database.** Every `SinglesInserts*` and `ComplexInserts*` iteration
   commits, so `efdp_product` and the graph tables grow during a run. `efdp_product` passed one
   million rows this way, which also means later select benchmarks read a larger, more fragmented
   table than earlier ones.
3. **Rows are arbitrary.** Select benchmarks use `TOP(n)` without `ORDER BY`; the rows returned are
   whatever the engine yields first, which is fine for throughput and not for comparing individual
   records.
