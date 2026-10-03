using System.Text.Json;

string json = File.ReadAllText("vendas.json");

using JsonDocument documento = JsonDocument.Parse(json);

JsonElement vendas = documento.RootElement.GetProperty("vendas");

Dictionary<string, decimal> comissoes = new();

foreach (JsonElement venda in vendas.EnumerateArray())
{
    string vendedor = venda.GetProperty("vendedor").GetString()!;
    decimal valor = venda.GetProperty("valor").GetDecimal();

    decimal percentual = 0;

    if (valor >= 500)
    {
        percentual = 0.05m;
    }
    else if (valor >= 100)
    {
        percentual = 0.01m;
    }

    decimal comissao = valor * percentual;

    if (comissoes.ContainsKey(vendedor))
    {
        comissoes[vendedor] += comissao;
    }
    else
    {
        comissoes[vendedor] = comissao;
    }
}

foreach (var comissao in comissoes)
{
    Console.WriteLine($"{comissao.Key}: R$ {comissao.Value:F2}");
}