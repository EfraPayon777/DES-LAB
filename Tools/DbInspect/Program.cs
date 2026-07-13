using System;
using Microsoft.Data.Sqlite;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var dbPath = args.Length > 0 ? args[0] : Path.Combine("..", "Ejercicio 1 LAB 3", "efrapayon777_deslab.db");
        Console.WriteLine($"DB Path: {Path.GetFullPath(dbPath)}");
        if (!File.Exists(dbPath))
        {
            Console.WriteLine("Database file not found.");
            return;
        }

        using var conn = new SqliteConnection($"Data Source={dbPath}");
        conn.Open();

        // List tables
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT name, type FROM sqlite_master WHERE type IN ('table','view') ORDER BY name;";
            using var reader = cmd.ExecuteReader();
            Console.WriteLine("Tables/Views:");
            while (reader.Read())
            {
                Console.WriteLine($" - {reader.GetString(0)} ({reader.GetString(1)})");
            }
        }

        // For known tables, print counts and sample rows
        var tables = new[] { "Employees", "Projects", "Assignments" };
        foreach (var t in tables)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{t}'";
            var exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            if (!exists)
            {
                Console.WriteLine($"Table {t} does not exist.");
                continue;
            }
            using (var c2 = conn.CreateCommand())
            {
                c2.CommandText = $"SELECT COUNT(*) FROM {t};";
                var count = Convert.ToInt32(c2.ExecuteScalar());
                Console.WriteLine($"Table {t}: {count} rows");
            }
            using (var c3 = conn.CreateCommand())
            {
                c3.CommandText = $"SELECT * FROM {t} LIMIT 5;";
                using var r = c3.ExecuteReader();
                var cols = new System.Collections.Generic.List<string>();
                for (int i = 0; i < r.FieldCount; i++) cols.Add(r.GetName(i));
                Console.WriteLine("Columns: " + string.Join(", ", cols));
                while (r.Read())
                {
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        Console.Write($"{cols[i]}={r.GetValue(i)}; ");
                    }
                    Console.WriteLine();
                }
            }
        }

        conn.Close();
    }
}
