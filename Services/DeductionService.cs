namespace Services;
public class DeductionService
{
    public string TemDeducoes(ref double receitaBruta)
    {
        Console.WriteLine("\nHá alguma dedução nessa etapa?\n1 - Sim\n2 - Não");
        string deducao = "";
        try
        {
            int resposta = Convert.ToInt32(Console.ReadLine());
            if (resposta == 1)
            {
                Console.WriteLine("\nInsira o nome da dedução.Para encerrar a inserção, não insira nada em seu nome");
                string deducaoNome = Console.ReadLine();
                while (deducaoNome != "")
                {
                    Console.WriteLine("\nInsira o valor da Dedução: ");
                    try
                    {
                        double deducaoValor = Convert.ToDouble(Console.ReadLine());
                        deducao += "\t(-) " + deducaoNome + ": " + deducaoValor + "\n";
                        receitaBruta -= deducaoValor;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("O valor informado é inválido. Tente novamente");
                    }
                    Console.WriteLine("\nInsira o nome da dedução.Para encerrar a inserção, não insira nada em seu nome");
                    deducaoNome = Console.ReadLine();
                }

            }
        }
        catch (Exception)
        {
            Console.WriteLine("O valor informado é inválido. Tente novamente");
            TemDeducoes(ref receitaBruta);
        }

        return deducao;
    }
}