using System.Globalization;

Console.WriteLine("================================================");
Console.WriteLine("               CÁLCULO DE JUROS");
Console.WriteLine("================================================");

Console.Write("\nDigite o valor: R$ ");

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

DateTime dataAtual = DateTime.Today;
int diasAtraso = (dataAtual - dataVencimento.Date).Days;

decimal taxaJuros = 0.025m;
decimal juros = 0;

if (diasAtraso > 0)
{
    // » Calcula os juros de 2,5% ao dia sobre o período em atraso
    juros = valor * taxaJuros * diasAtraso;
}
else
{
    diasAtraso = 0;
}

decimal valorTotal = valor + juros;

Console.WriteLine("\n------------------------------------------------");
Console.WriteLine("               RESUMO DO CÁLCULO");
Console.WriteLine("------------------------------------------------");
Console.WriteLine($"{"Valor original:",-20} R$ {valor,12:F2}");
Console.WriteLine($"{"Vencimento:",-20} {dataVencimento:dd/MM/yyyy}");
Console.WriteLine($"{"Dias em atraso:",-20} {diasAtraso}");
Console.WriteLine($"{"Taxa diária:",-20} 2,5%");
Console.WriteLine($"{"Juros calculados:",-20} R$ {juros,12:F2}");
Console.WriteLine($"{"Valor com juros:",-20} R$ {valorTotal,12:F2}");
Console.WriteLine("================================================");