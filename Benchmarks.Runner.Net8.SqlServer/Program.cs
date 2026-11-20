using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace Benchmarks.Runner.Net8.SqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // ========== CONFIGURATION ==========
            // Flip a flag to true to run that scenario, false to skip it.
            // Command line: --filter=<text> runs only the classes whose name contains <text>
            //               --list           prints the class names and exits.
            bool runInserts1 = true;
            bool runInserts5 = true;
            bool runInserts20 = true;
            bool runInserts200 = true;

            bool runSelects1 = true;
            bool runSelects5 = true;
            bool runSelects50 = true;
            bool runSelects500 = true;
            bool runSelects5000 = true;

            bool runEntitySpacesInserts1 = true;
            bool runEntitySpacesSelects1 = true;

            bool runCplxInserts1 = true;
            bool runCplxInserts5 = true;
            bool runCplxInserts20 = true;

            bool runCplxSelects1 = true;
            bool runCplxSelects5 = true;
            bool runCplxSelects50 = true;
            bool runCplxSelects500 = true;
            // ===================================

            var filter = GetOption(args, "--filter");
            if (args.Any(a => a.Equals("--list", StringComparison.OrdinalIgnoreCase)))
            {
                foreach (var name in TypeNames)
                    Console.WriteLine(name);
                return;
            }

            // Cross-checks the graph-read implementations; run it with --validate.
            if (args.Any(a => a.Equals("--validate", StringComparison.OrdinalIgnoreCase)))
            {
                Validation.RunGraphReadChecksAsync().GetAwaiter().GetResult();
                return;
            }

            // The filter is a case-insensitive substring match on the benchmark class name.
            bool Enabled(string className) =>
                string.IsNullOrEmpty(filter) ||
                className.Contains(filter, StringComparison.OrdinalIgnoreCase);

            void Run<TBenchmark>()
            {
                var name = typeof(TBenchmark).Name;
                if (!Enabled(name))
                {
                    Console.WriteLine($"-- skipped {name} (filter: {filter})");
                    return;
                }
                _ = BenchmarkRunner.Run<TBenchmark>();
            }

            // --- Single-table writes ---
            if (runInserts1) Run<SinglesInserts1>();
            if (runInserts5) Run<SinglesInserts5>();
            if (runInserts20) Run<SinglesInserts20>();
            if (runInserts200) Run<SinglesInserts200>();

            // --- Single-table reads ---
            if (runSelects1) Run<SinglesSelects1>();
            if (runSelects5) Run<SinglesSelects5>();
            if (runSelects50) Run<SinglesSelects50>();
            if (runSelects500) Run<SinglesSelects500>();
            if (runSelects5000) Run<SinglesSelects5000>();

            // --- EntitySpaces isolation runs ---
            if (runEntitySpacesInserts1) Run<SinglesInsertsEntitySpaces1>();
            if (runEntitySpacesSelects1) Run<SinglesSelectsEntitySpaces1>();

            // --- Graph writes ---
            if (runCplxInserts1) Run<ComplexInserts1>();
            if (runCplxInserts5) Run<ComplexInserts5>();
            if (runCplxInserts20) Run<ComplexInserts20>();

            // --- Graph reads ---
            if (runCplxSelects1) Run<ComplexSelects1>();
            if (runCplxSelects5) Run<ComplexSelects5>();
            if (runCplxSelects50) Run<ComplexSelects50>();
            if (runCplxSelects500) Run<ComplexSelects500>();
        }

        // Every benchmark class, in run order. Used by --list.
        private static readonly string[] TypeNames =
        {
            nameof(SinglesInserts1), nameof(SinglesInserts5), nameof(SinglesInserts20), nameof(SinglesInserts200),
            nameof(SinglesSelects1), nameof(SinglesSelects5), nameof(SinglesSelects50), nameof(SinglesSelects500), nameof(SinglesSelects5000),
            nameof(SinglesInsertsEntitySpaces1), nameof(SinglesSelectsEntitySpaces1),
            nameof(ComplexInserts1), nameof(ComplexInserts5), nameof(ComplexInserts20),
            nameof(ComplexSelects1), nameof(ComplexSelects5), nameof(ComplexSelects50), nameof(ComplexSelects500)
        };

        // Reads "--name=value" or "--name value" from the command line.
        private static string GetOption(string[] args, string name)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith(name + "=", StringComparison.OrdinalIgnoreCase))
                    return args[i].Substring(name.Length + 1);
                if (args[i].Equals(name, StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                    return args[i + 1];
            }
            return null;
        }
    }
}
