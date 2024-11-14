// Screen Sound

string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
void ExibirMensagemDeBoasVindas()
{
    Console.Clear();
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");
    Console.WriteLine(mensagemDeBoasVindas);

}
void ExibirOpcoesDoMenu()
{
    ExibirMensagemDeBoasVindas();
    Console.WriteLine("\n1 - Registrar uma banda");
    Console.WriteLine("2 - Mostrar todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir a média de uma banda");
    Console.WriteLine("-1 - Sair");

    Console.WriteLine("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;


    switch (opcaoEscolhida)
    {
        case "1":
            RegistrarBanda();
            break;
        case "2":
            MostrarBandasRegistradas();
            break;
        case "3":
            AvaliarBanda();
            break;
        case "4":
            MediaDasBandas();
            break;
        case "-1":
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.Clear();
            Console.WriteLine("\n\n*******************Opção inválida*******************");
            Thread.Sleep(2000);
            ExibirOpcoesDoMenu();
            break;
    }
}
void RegistrarBanda()
{
    Console.Clear();
    Console.WriteLine(@"
█▀█ █▀▀ █▀▀ █ █▀ ▀█▀ █▀█ █▀█   █▀▄ █▀▀   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█ █▀
█▀▄ ██▄ █▄█ █ ▄█ ░█░ █▀▄ █▄█   █▄▀ ██▄   █▄█ █▀█ █░▀█ █▄▀ █▀█ ▄█");
    Console.WriteLine("\nDigite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
    Console.ReadKey();
    ExibirOpcoesDoMenu();

}
void MostrarBandasRegistradas()
{
    Console.Clear();
    Console.WriteLine(@"
█▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█ █▀   █▀█ █▀▀ █▀▀ █ █▀ ▀█▀ █▀█ ▄▀█ █▀▄ ▄▀█ █▀
█▄█ █▀█ █░▀█ █▄▀ █▀█ ▄█   █▀▄ ██▄ █▄█ █ ▄█ ░█░ █▀▄ █▀█ █▄▀ █▀█ ▄█");
    Console.WriteLine();
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"{banda}");
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
    Console.ReadKey();
    ExibirOpcoesDoMenu();

}
void AvaliarBanda()
{
    Console.Clear();
    Console.WriteLine(@"
▄▀█ █░█ ▄▀█ █░░ █ █▀▀   █░█ █▀▄▀█ ▄▀█   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█
█▀█ ▀▄▀ █▀█ █▄▄ █ ██▄   █▄█ █░▀░█ █▀█   █▄█ █▀█ █░▀█ █▄▀ █▀█");
    Console.WriteLine("\nDigite o nome da banda que deseja avaliar: ");
    string bandaAvaliada = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        Console.WriteLine($"\nDigite uma nota de 1 a 10 para {bandaAvaliada}");
        int nota = int.Parse(Console.ReadLine()!);

        if (nota > 10) nota = 10;
        else if (nota < 0) nota = 0;

        bandasRegistradas[bandaAvaliada].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para {bandaAvaliada}.");
        Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {bandaAvaliada} não foi registrada!");
        Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
}
void MediaDasBandas()
{
    Console.Clear();
    Console.WriteLine(@"
█▀▄▀█ █▀▀ █▀▄ █ ▄▀█   █▀▄ ▄▀█ █▀   █▄▄ ▄▀█ █▄░█ █▀▄ ▄▀█ █▀
█░▀░█ ██▄ █▄▀ █ █▀█   █▄▀ █▀█ ▄█   █▄█ █▀█ █░▀█ █▄▀ █▀█ ▄█");
    Console.WriteLine("\nDigite o nome da banda que deseja ver a nota média: ");
    string bandaAvaliada = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(bandaAvaliada))
    {
        if (bandasRegistradas[bandaAvaliada].Count() <= 0)
        {
            Console.WriteLine($"A banda {bandaAvaliada} não possui notas registradas");
            Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }
        else
        {
            int media = 0;
            foreach (int nota in bandasRegistradas[bandaAvaliada])
            {
                media += nota;
            }
            media = media / (bandasRegistradas[bandaAvaliada].Count());
            Console.WriteLine($"A nota média da banda {bandaAvaliada} é {media}");
            Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }

    }
    else
    {
        Console.WriteLine($"\nA banda {bandaAvaliada} não foi registrada!");
        Console.WriteLine("\nAperte qualquer tecla para voltar para o Menu Principal");
        Console.ReadKey();
        ExibirOpcoesDoMenu();

    }
}
ExibirOpcoesDoMenu();