using System.Text.Json;

string json = File.ReadAllText("vendas.json");

using JsonDocument documento = JsonDocument.Parse(json);

JsonElement vendas = documento.RootElement.GetProperty("vendas");

Dictionary<string, decimal> comissoes = new();

foreach (JsonElement venda in vendas.EnumerateArray())
{
    string vendedor = venda.GetProperty("vendedor").GetString()!;
    decimal valor = venda.GetProperty("valor").GetDecimal();

    // » Define o percentual de comissão conforme a faixa de valor da venda
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

Console.WriteLine("========================================");
Console.WriteLine("          COMISSÃO DE VENDEDORES");
Console.WriteLine("========================================");
Console.WriteLine();
Console.WriteLine($"{"Vendedor",-25} {"Comissão",14}");
Console.WriteLine("----------------------------------------");

foreach (var comissao in comissoes)
{
    Console.WriteLine($"{comissao.Key,-25} R$ {comissao.Value,10:F2}");
}

Console.WriteLine("========================================");