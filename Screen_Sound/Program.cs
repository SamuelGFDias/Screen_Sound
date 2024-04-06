/* 
PROJETO SCREEN SOUND
*/

string mensagemDeBoasVindas = "Boas Vindas as Screen Sound";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string,List<int>>();
bandasRegistradas.Add("LinkPark", new List<int> { 10, 1, 2, 5});
bandasRegistradas.Add("Calypso", new List<int> { 8, 7, 2, 5 });
bandasRegistradas.Add("The Beathes", new List<int>());

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para mostrar a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    int opcaoEscolhidaNumerica;

    if (!int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
    {
        OpcaoInvalida();
        ExibirOpcoesDoMenu();
    }
    else 
    {
        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                MostrarBandasRegistradas();
                break;
            case 3:
                AvaliarUmaBanda();
                break;
            case 4:
                MostrarMediaDaBanda();
                break;
            case -1:
                Sair();
                break;
            default:
                OpcaoInvalida();
                ExibirOpcoesDoMenu();
                break;
        }
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja cadastrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso");
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    AguardandoUsuario();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulo("Exibindo todas as bandas registradas");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    AguardandoUsuario();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTitulo("Avaliar uma banda");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nQual a nota que a banda merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        if (nota <= 10 && nota >= 0)
        {
            bandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"\nA nota {nota} for registrada com sucesso!");
            AguardandoUsuario();
            Console.Clear();
            ExibirOpcoesDoMenu();
        } else
        {
            Console.WriteLine($"\nDigite uma nota entre 0 e 10");
            AguardandoUsuario();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        AguardandoUsuario();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MostrarMediaDaBanda()
{
    Console.Clear();
    ExibirTitulo("Media das Bandas");
    Console.Write("Digite o nome da manda que deseja mostrar a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        double soma = 0;
        for (int i = 0; i < bandasRegistradas[nomeDaBanda].Count; i++)
        {
            soma += bandasRegistradas[nomeDaBanda][i];
        }
        double media = soma / bandasRegistradas[nomeDaBanda].Count;
        Console.WriteLine($"\nMédia da {nomeDaBanda}: {media}");
        AguardandoUsuario();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        AguardandoUsuario();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirTitulo(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteristicos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteristicos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos + "\n");
}

void OpcaoInvalida()
{
    Console.WriteLine("\nOpcão inválida");
    AguardandoUsuario();
    Console.Clear();
}

void AguardandoUsuario()
{
    Console.WriteLine("\nAperte qualquer tecla para prosseguir...");
    Console.ReadKey();
}

void ExibirLogo()
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

void Sair()
{
    Thread.Sleep(200);
    Console.Write(".");
    Thread.Sleep(200);
    Console.Write(".");
    Thread.Sleep(200);
    Console.Write(".");
    Console.Write(" Volte Sempre!");
}

ExibirOpcoesDoMenu();
