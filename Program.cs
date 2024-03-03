using Microsoft.Extensions.DependencyInjection;
using Services;
public class Program
{
    public static void Main()
    {
        Console.Clear();
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var deductionService = serviceProvider.GetService<DeductionService>();
        string dre = "";
        Console.WriteLine("Insira o valor da Receita Operacional Bruta: ");

        double receitaBruta = Convert.ToDouble(Console.ReadLine());
        dre += "(=) Receita Operacional Bruta: " + receitaBruta + "\n";

        Console.WriteLine("\nDespesas de Produtos\n");
        dre += deductionService.TemDeducoes(ref receitaBruta);
        dre += "(=) Receita Operacional Liquida: " + receitaBruta + "\n";

        Console.WriteLine("\nCustos de Produtos\n");
        dre += deductionService.TemDeducoes(ref receitaBruta);
        dre += "(=) Lucro Bruto: " + receitaBruta + "\n";

        Console.WriteLine("\nDespesas Operacionais\n");
        dre += deductionService.TemDeducoes(ref receitaBruta);
        dre += "(=) Lucro Operacional: " + receitaBruta + "\n";

        Console.WriteLine("\nDespesas Financeiras\n");
        dre += deductionService.TemDeducoes(ref receitaBruta);
        dre += "(=) Lucro Líquido antes do IR: " + receitaBruta + "\n";

        dre += "\t(-) IR: " + receitaBruta * 0.15 + "\n";
        receitaBruta -= (receitaBruta * 0.15);
        dre += "(=) TOTAL: " + receitaBruta + "\n";

        Console.Clear();
        
        Console.WriteLine(dre);
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<DeductionService>();

    }
}