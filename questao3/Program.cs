using System.Globalization;

Console.Write("Digite o valor: R$ ");

if (!decimal.TryParse(
    Console.ReadLine(),
    NumberStyles.Number,
    CultureInfo.GetCultureInfo("pt-BR"),
    out decimal valor) || valor <= 0)
{
    Console.WriteLine("Valor inválido.");
    return;
}

Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");

if (!DateTime.TryParseExact(
    Console.ReadLine(),
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out DateTime dataVencimento))
{
    Console.WriteLine("Data inválida.");
    return;
}

Console.WriteLine($"\nValor: R$ {valor:F2}");
Console.WriteLine($"Vencimento: {dataVencimento:dd/MM/yyyy}");

DateTime dataAtual = DateTime.Today;

int diasAtraso = (dataAtual - dataVencimento.Date).Days;

if (diasAtraso <= 0)
{
    Console.WriteLine("Dias em atraso: 0");
    Console.WriteLine("Juros: R$ 0,00");
    return;
}

decimal taxaJuros = 0.025m;
decimal juros = valor * taxaJuros * diasAtraso;

Console.WriteLine($"Dias em atraso: {diasAtraso}");
Console.WriteLine($"Juros: R$ {juros:F2}");