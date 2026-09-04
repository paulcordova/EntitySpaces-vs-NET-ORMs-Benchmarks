using BenchmarkDotNet.Running;
using Benchmarks.Tests.Net8.SqlServer.Dtos;
using System.Collections.Generic;

namespace Benchmarks.Runner.Net8.SqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // ========== CONFIGURACIÓN ==========
            // Cambia a true para ejecutar, false para omitir
            bool runInserts1 = false;
            bool runInserts5 = false;
            bool runInserts20 = false;
            bool runInserts200 = false;

            bool runSelects1 = false;
            bool runSelects5 = false;
            bool runSelects50 = false;
            bool runSelects500 = false;
            bool runSelects5000 = false;

            bool runEntitySpacesInserts1 = false;  // si ya tienes estas clases
            bool runEntitySpacesSelects1 = false;

            // NUEVO: Insert complejo de EntitySpaces (1 cliente con sus relaciones)

            bool runCplxInserts1 = false;
            bool runCplxInserts5 = false;
            bool runCplxInserts20 = false;


            // ===================================

            // --- Selecciones simples ---
            if (runInserts1) _ = BenchmarkRunner.Run<SinglesInserts1>();
            if (runInserts5) _ = BenchmarkRunner.Run<SinglesInserts5>();
            if (runInserts20) _ = BenchmarkRunner.Run<SinglesInserts20>();
            if (runInserts200) _ = BenchmarkRunner.Run<SinglesInserts200>();

            if (runSelects1) _ = BenchmarkRunner.Run<SinglesSelects1>();
            if (runSelects5) _ = BenchmarkRunner.Run<SinglesSelects5>();
            if (runSelects50) _ = BenchmarkRunner.Run<SinglesSelects50>();
            if (runSelects500) _ = BenchmarkRunner.Run<SinglesSelects500>();
            if (runSelects5000) _ = BenchmarkRunner.Run<SinglesSelects5000>();

            // --- EntitySpaces simples ---
            if (runEntitySpacesInserts1) _ = BenchmarkRunner.Run<SinglesInsertsEntitySpaces1>();
            if (runEntitySpacesSelects1) _ = BenchmarkRunner.Run<SinglesSelectsEntitySpaces1>();

            // --- NEW for EntityFramework - EntityFramework Core - EntitySpaces2026
            if (runCplxInserts1) _ = BenchmarkRunner.Run<ComplexInserts1>();
            if (runCplxInserts5) _ = BenchmarkRunner.Run<ComplexInserts5>();
            if (runCplxInserts20) _ = BenchmarkRunner.Run<ComplexInserts20>();

            // Complex Selects
            bool runCplxSelects1 = true;
            bool runCplxSelects5 = true;
            bool runCplxSelects50 = true;
            bool runCplxSelects500 = true;

            if (runCplxSelects1) _ = BenchmarkRunner.Run<ComplexSelects1>();
            if (runCplxSelects5) _ = BenchmarkRunner.Run<ComplexSelects5>();
            //if (runCplxSelects50) _ = BenchmarkRunner.Run<ComplexSelects50>();
            //if (runCplxSelects500) _ = BenchmarkRunner.Run<ComplexSelects500>();



        }
    }
}