using System.Text.Json;

string json = File.ReadAllText("estoque.json");

using JsonDocument documento = JsonDocument.Parse(json);

JsonElement estoque = documento.RootElement.GetProperty("estoque");

Console.WriteLine("Produtos em estoque:");

foreach (JsonElement produto in estoque.EnumerateArray())
{
    int codigo = produto.GetProperty("codigoProduto").GetInt32();
    string descricao = produto.GetProperty("descricaoProduto").GetString()!;
    int quantidade = produto.GetProperty("estoque").GetInt32();

    Console.WriteLine($"{codigo} - {descricao}: {quantidade}");
}