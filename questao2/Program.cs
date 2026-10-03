using System.Text.Json;

string json = File.ReadAllText("estoque.json");

using JsonDocument documento = JsonDocument.Parse(json);

JsonElement estoque = documento.RootElement.GetProperty("estoque");

Console.WriteLine("================================================");
Console.WriteLine("              CONTROLE DE ESTOQUE");
Console.WriteLine("================================================");
Console.WriteLine();
Console.WriteLine("PRODUTOS DISPONÍVEIS");
Console.WriteLine();
Console.WriteLine($"{"Código",-8} {"Produto",-31} {"Estoque",7}");
Console.WriteLine("------------------------------------------------");

foreach (JsonElement produto in estoque.EnumerateArray())
{
    int codigo = produto.GetProperty("codigoProduto").GetInt32();
    string descricao = produto.GetProperty("descricaoProduto").GetString()!;
    int quantidade = produto.GetProperty("estoque").GetInt32();

    Console.WriteLine($"{codigo,-8} {descricao,-31} {quantidade,7}");
}

Console.WriteLine("------------------------------------------------");
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

Console.WriteLine($"\nProduto: {descricaoProduto}");
Console.WriteLine($"Estoque atual: {estoqueAtual}");

Console.WriteLine("\nTipo de movimentação");
Console.WriteLine("[E] Entrada");
Console.WriteLine("[S] Saída");
Console.Write("\nOpção: ");

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

// » Atualiza o estoque conforme o tipo de movimentação
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

// » Gera um identificador numérico único para a movimentação
long idMovimentacao = DateTimeOffset.Now.ToUnixTimeMilliseconds();

string descricaoMovimentacao = tipoMovimentacao == "E"
    ? "Entrada de estoque"
    : "Saída de estoque";

Console.WriteLine("\n================================================");
Console.WriteLine("            MOVIMENTAÇÃO CONCLUÍDA");
Console.WriteLine("================================================");
Console.WriteLine($"ID:               {idMovimentacao}");
Console.WriteLine($"Produto:          {descricaoProduto}");
Console.WriteLine($"Movimentação:     {descricaoMovimentacao}");
Console.WriteLine($"Quantidade:       {quantidadeMovimentada}");
Console.WriteLine($"Estoque anterior: {estoqueAtual}");
Console.WriteLine($"Estoque final:    {estoqueFinal}");
Console.WriteLine("================================================");