// See https://aka.ms/new-console-template for more information
using RobotEasyAutomation;

try
{
    var filePath = "D:\\documentos\\github\\curso_automacao_processos_rpa_dotnet\\AutomationSeleniumChorme\\RobotEasyAutomation\\database_costumer.csv";

    var lines = File.ReadAllLines(filePath);
    //var checkouts = lines.Skip(1).Select(Checkout.Map).ToList();

    var checkouts = lines.Skip(1)
                         .Select(line => line.Split(',')) // Divide a linha em colunas
                         .Where(parts => parts.Length >= 2) // Verifica se há pelo menos 2 colunas (ajuste conforme necessário)
                         .Select(parts => new Checkout
                         {
                             FirstName = parts[0],
                             LastName = parts[1],
                             Username = parts[2],
                             Email = parts[3],
                             Address = parts[4],
                             Country = parts[5],
                             State = parts[6],
                             Zip = parts[7],
                             Payment = parts[8],
                             NameCard = parts[9],
                             CreditCard = parts[10],
                             Expiration = parts[11],
                             Cvv = parts[12]
                         })
                         .ToList();

    foreach (var checkout in checkouts)
    {
        Console.WriteLine("checkout = " + checkout.FirstName);
    }
}
catch (Exception ex)
{

    Console.WriteLine("messagem de erro:" + ex.Message);
}
