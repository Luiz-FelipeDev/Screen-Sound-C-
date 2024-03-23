using System.Diagnostics.CodeAnalysis;

string mensagemDeBoasVindas = "Seja Bem-vindo ao Screen Sound";
//List<string> listaDeBandas = new List<string> { "U2", "Link Park"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

bandasRegistradas.Add("Linkin Park", new List<int> { 10, 9, 8 });
bandasRegistradas.Add("Pink floyd", new List<int>());
void ExibeLogo()
{
    Console.WriteLine(@"
        
        ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
        ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
        ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
        ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
        ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
        ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}



void ExibeOpcoesDeMenu()
    
{
    ExibeLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a opção escolhida: ");
    string opcaoEscolhida = Console.ReadLine()!; // ! operador de supressão null, .ReadLine() retorna por padrão uma string
    int opcaoNumericaEscolhida = int.Parse(opcaoEscolhida);

    switch (opcaoNumericaEscolhida) // Cenário para muitos casos
    {
        case 1: RegistraBanda();
            break;
        case 2: ExibeTodasAsBandas();
            break;
        case 3: AvaliaUmaBanda();
            break;
        case 4:CalculaMediaBanda();
            break;
        case -1: Console.WriteLine("A opção escolhida foi " + opcaoNumericaEscolhida);
            break;
        default: Console.WriteLine(" Opção inválida");
            break;
    }

}

void RegistraBanda()
{
    Console.Clear();

    ExibeTituloDasOpcoes("Registre sua Banda");

    Console.WriteLine("Registre a banda de sua escolha...");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();

    ExibeOpcoesDeMenu();
}

void ExibeTodasAsBandas()
{
    Console.Clear();

    ExibeTituloDasOpcoes("Exibindo todas as bandas registradas");

    //for (int i = 0; i < listaDeBandas.Count; i++)
    //{
    //      Console.WriteLine($"Banda: {listaDeBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite alguma tecla para voltar ao menu principal: ");
    Console.ReadKey();
}

void ExibeTituloDasOpcoes(string titulo)
{
    int quantidadeDeCaracteres = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeCaracteres, '*');

    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliaUmaBanda()
    
{
    Console.Clear();
    ExibeTituloDasOpcoes("Avaliar Banda");

    Console.Write("Digite o nome da banda que voçe deseja avaliar: " + "\n");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Digite uma nota para a banda {nomeBanda}: ");
        string notaBandaCaracter = Console.ReadLine()!;
        int notaBanda = int.Parse(notaBandaCaracter);

        bandasRegistradas[nomeBanda].Add(notaBanda);
        Console.WriteLine($"A nota {notaBanda} dada a banda {nomeBanda} foi adicionada");
        Thread.Sleep(4000);
        ExibeOpcoesDeMenu();
    }
    else
    {
        Console.WriteLine("Não existe essa banda em nossa lista! Add ela\n");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibeOpcoesDeMenu();
    }
}

void CalculaMediaBanda()
{
    Console.Clear();
    ExibeTituloDasOpcoes("Consulta Media de uma Banda");

    Console.Write("Qual banda você deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        int totalDeNotas = 0;
        for (int i = 0; i < bandasRegistradas[nomeBanda].Count; i++)
        {
            totalDeNotas = totalDeNotas + bandasRegistradas[nomeBanda][i];
            
        }
        int quantidadeDeNotas = bandasRegistradas[nomeBanda].Count;
        double mediaNotas = totalDeNotas / quantidadeDeNotas;
        Console.WriteLine($"A media da banda {nomeBanda} é {mediaNotas}\n");
    } else
    {
        Console.WriteLine($"O nome {nomeBanda} não pertence a nossa lista\n");
        Console.WriteLine("Digite alguma tecla para voltar ao menu inicial");
    }
    Console.Clear();
}

ExibeOpcoesDeMenu();
