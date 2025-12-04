//Pet Shop
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Desafios._2;

void ExibirLogo()
{
    Console.WriteLine("\r\n░█████╗░░█████╗░███╗░░██╗██╗██╗░░░░░  ░█████╗░██╗░░░██╗░░░░░░░█████╗░██╗░░░██╗\r\n██╔══██╗██╔══██╗████╗░██║██║██║░░░░░  ██╔══██╗██║░░░██║░░░░░░██╔══██╗██║░░░██║\r\n██║░░╚═╝███████║██╔██╗██║██║██║░░░░░  ███████║██║░░░██║█████╗███████║██║░░░██║\r\n██║░░██╗██╔══██║██║╚████║██║██║░░░░░  ██╔══██║██║░░░██║╚════╝██╔══██║██║░░░██║\r\n╚█████╔╝██║░░██║██║░╚███║██║███████╗  ██║░░██║╚██████╔╝░░░░░░██║░░██║╚██████╔╝\r\n░╚════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚══════╝  ╚═╝░░╚═╝░╚═════╝░░░░░░░╚═╝░░╚═╝░╚═════╝░");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("**************************");
    Console.WriteLine("Bem-vindo ao Canil Au-Au!");
    Console.WriteLine("**************************");
    Console.WriteLine("\nEscolha a opção desejada:");
    Console.WriteLine("\nMenu - Donos:");
    Console.WriteLine("1 - Cadastrar Dono");
    Console.WriteLine("2 - Exibir donos cadastrados");
    Console.WriteLine("\nMenu - Pets:");
    Console.WriteLine("3 - Cadastrar Pet");
    Console.WriteLine("4 - Exibir Pets");
    Console.WriteLine("\nMenu - Médicos e Consultas:");
    Console.WriteLine("5 - Cadastrar Médico");
    Console.WriteLine("6 - Consultar Médicos cadastrados");
    Console.WriteLine("7 - Agendar Consulta");
    Console.WriteLine("8 - Exibir Consulta");
    Console.WriteLine("\n9 - Sair")
    ;
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarDono();
            break;
        case "2":
            ExibirDonosCadastrados();            
            break;
        case "3":
            CadastrarPet();
            break;
        case "4":
            ExibirPets();
            break;
        case "5":
            CadastrarMedico();
            break;
        case "6":
            ConsultarMedico();
            break;
        case "7":
            InserirConsulta();
            break;
        case "8":
            VerificarConsulta();
            break;
        case "9":
            Console.WriteLine("Saindo do sistema. Até logo!");
            break;

    }
}

ExibirOpcoesDoMenu();

void ExibirDonosCadastrados()
{
    Console.Clear();
    Console.WriteLine("***************************");
    Console.WriteLine("Exibir Donos Cadastrados:");
    Console.WriteLine("***************************");
    if (SistemaPetShop.DonosCadastrados.Count == 0)
    {
        Console.WriteLine("Nenhum dono cadastrado.");
    } else
    {
        foreach (var dono in SistemaPetShop.DonosCadastrados)
        {
            string nomeDosPets = dono.Pets.Count > 0 ? string.Join(", ", dono.Pets.Select(p => p.Nome)) : "Nenhum pet cadastrado";

            Console.WriteLine($"Informações do dono: Nome {dono.Nome}; Idade: {dono.Idade}; Profissão: {dono.Profissao}; Endereço: {dono.Endereco}; Pets: {nomeDosPets}");
        }
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void CadastrarDono()
{
    Console.Clear();
    Console.WriteLine("******************");
    Console.WriteLine("Cadastrar Dono:");
    Console.WriteLine("******************");
    Dono novoDono = Dono.InserirDono();
    Console.WriteLine("Novo Dono Cadastrado com sucesso! Aperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void CadastrarPet()
{
    Console.Clear();
    Console.WriteLine("*****************");
    Console.WriteLine("Cadastrar Pet:");
    Console.WriteLine("*****************");
    Console.WriteLine("Digite o nome do Dono para vincular o Pet:");
    string nomeDonoParaPet = Console.ReadLine();
    Dono donoEncontrado = SistemaPetShop.DonosCadastrados.Find(d => d.Nome.Equals(nomeDonoParaPet, StringComparison.OrdinalIgnoreCase));
    if (donoEncontrado != null)
    {
        Pet novoPetParaDono = Pet.InserirPet(donoEncontrado);
        donoEncontrado.AdicionarPet(novoPetParaDono);
        Console.WriteLine("\nPet cadastrado com sucesso");
    }
    else
    {
        Console.WriteLine("\nDono não encontrado. Cadastre o dono primeiro.");
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirPets()
{
    Console.Clear();
    Console.WriteLine("***********************");
    Console.WriteLine("Exibir Pets Cadastrados:");
    Console.WriteLine("***********************");
    Console.WriteLine("Insira o nome do Dono para listar os Pets:");
    string nomeDonoParaListarPets = Console.ReadLine();
    Dono donoEncontrado = SistemaPetShop.DonosCadastrados.Find(d => d.Nome.Equals(nomeDonoParaListarPets, StringComparison.OrdinalIgnoreCase));
    if (donoEncontrado == null)
    {
        Console.WriteLine("Dono não encontrado. Tente novamente");
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    if (donoEncontrado.Pets.Count == 0) 
    {
        Console.WriteLine("Esse dono não possui pets cadastrados.");
    }
    else
    {
        Console.WriteLine($"\nPets encontrados para o dono {donoEncontrado.Nome}");
        foreach (var pet in donoEncontrado.Pets)
        {
            Console.WriteLine($"Nome do Pet: {pet.Nome}; Espécie: {pet.Especie}; Raça {pet.Raça}, Idade: {pet.Idade} anos; Dono: {pet.Dono.Nome}");
        }
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void CadastrarMedico()
{
    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("Cadastrar Médico:");
    Console.WriteLine("********************");
    Medico novoMedico = Medico.InserirMedico();
    Console.WriteLine("Novo Médico cadastrado com sucesso! Aperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ConsultarMedico()
{
    Console.Clear();
    Console.WriteLine("****************************");
    Console.WriteLine("Exibir médicos cadastrados");
    Console.WriteLine("****************************");
    if (SistemaPetShop.MedicosCadastrados.Count == 0)
    {
        Console.WriteLine("Nenhum médico cadastrado");
    } else
    {
        foreach (var medico in SistemaPetShop.MedicosCadastrados)
        {
            medico.ExibirMedico();
        }
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void InserirConsulta()
{
    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("Inserir consulta:");
    Console.WriteLine("*******************");
    Consulta.InserirConsulta();
    Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void VerificarConsulta()
{
    Console.Clear();
    Console.WriteLine("********************");
    Console.WriteLine("Verificar consulta:");
    Console.WriteLine("********************");
    if (SistemaPetShop.ConsultasAgendadas.Count == 0)
    {
        Console.WriteLine("Nenhuma consulta agendada");
    }
    else
    {
        foreach (var consulta in SistemaPetShop.ConsultasAgendadas)
        {
            consulta.ExibirConsulta();
        }
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao Menu Inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}