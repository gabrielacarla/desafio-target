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

Console.Write("\nDigite o código do produto: ");

if (!int.TryParse(Console.ReadLine(), out int codigoInformado))
{
    Console.WriteLine("Código inválido.");
    return;
}

JsonElement produtoSelecionado = default;
bool produtoEncontrado = false;

foreach (JsonElement produto in estoque.EnumerateArray())
{
    if (produto.GetProperty("codigoProduto").GetInt32() == codigoInformado)
    {
        produtoSelecionado = produto;
        produtoEncontrado = true;
        break;
    }
}

if (!produtoEncontrado)
{
    Console.WriteLine("Produto não encontrado.");
    return;
}

string descricaoProduto = produtoSelecionado.GetProperty("descricaoProduto").GetString()!;
int estoqueAtual = produtoSelecionado.GetProperty("estoque").GetInt32();

Console.WriteLine($"Produto selecionado: {descricaoProduto}");
Console.WriteLine($"Estoque atual: {estoqueAtual}");

Console.Write("\nTipo de movimentação (E - Entrada | S - Saída): ");
string tipoMovimentacao = Console.ReadLine()?.Trim().ToUpper() ?? "";

if (tipoMovimentacao != "E" && tipoMovimentacao != "S")
{
    Console.WriteLine("Tipo de movimentação inválido.");
    return;
}

Console.Write("Quantidade: ");

if (!int.TryParse(Console.ReadLine(), out int quantidadeMovimentada) || quantidadeMovimentada <= 0)
{
    Console.WriteLine("Quantidade inválida.");
    return;
}

int estoqueFinal;

if (tipoMovimentacao == "E")
{
    estoqueFinal = estoqueAtual + quantidadeMovimentada;
}
else
{
    if (quantidadeMovimentada > estoqueAtual)
    {
        Console.WriteLine("Estoque insuficiente para realizar a saída.");
        return;
    }

    estoqueFinal = estoqueAtual - quantidadeMovimentada;
}

long idMovimentacao = DateTimeOffset.Now.ToUnixTimeMilliseconds();

string descricaoMovimentacao = tipoMovimentacao == "E"
    ? "Entrada de estoque"
    : "Saída de estoque";

Console.WriteLine("\nMovimentação realizada:");
Console.WriteLine($"ID: {idMovimentacao}");
Console.WriteLine($"Produto: {descricaoProduto}");
Console.WriteLine($"Tipo: {descricaoMovimentacao}");
Console.WriteLine($"Quantidade: {quantidadeMovimentada}");
Console.WriteLine($"Estoque final: {estoqueFinal}");