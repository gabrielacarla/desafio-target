using System.Text.Json;

string json = File.ReadAllText("vendas.json");

Console.WriteLine("Arquivo de vendas carregado.");

Console.WriteLine(json);