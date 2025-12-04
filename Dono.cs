namespace Desafios._2
{
    internal class Dono
    {
        public Dono(string nome, int idade, string profissao, string endereco)
        {
            Nome = nome;
            Idade = idade;
            Profissao = profissao;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public void AdicionarPet(Pet pet)
        {
            Pets.Add(pet);
            SistemaPetShop.PetsCadastrados.Add(pet);
        }

        static public Dono InserirDono()
        {
            Console.WriteLine("Insira o nome do dono: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira a idade do dono: ");
            int idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira a profissão do dono: ");
            string profissao = Console.ReadLine();
            Console.WriteLine("Insira o endereço do dono: ");
            string endereco = Console.ReadLine();
            Dono novoDono = new Dono(nome, idade, profissao, endereco);
            SistemaPetShop.DonosCadastrados.Add(novoDono);
            return novoDono; // retorna as informações do dono
        }

        public void ExibirDono()
        {
            Console.WriteLine("Informações do Dono:");
                if (Pets.Count > 0)
                {
                string nomeDosPets = string.Join(", ", Pets.Select(p => p.Nome));    
                Console.WriteLine($"Informações do Dono - Nome: {Nome}; Idade: {Idade}; Profissão: {Profissao}; Endereço {Endereco}; Pets: {nomeDosPets}");
                }
                else
                {
                    Console.WriteLine($"Informações do Dono - Nome: {Nome}; Idade: {Idade}; Profissão: {Profissao}; Endereço {Endereco}; Pets: Nenhum pet cadastrado.");
                }
        }

        public void ExibirPets()
        {
            Console.WriteLine($"Lista de Pets de {Nome}:");
            foreach (var pet in Pets)
            {
                Console.WriteLine($"Nome: {pet.Nome}; Espécie: {pet.Especie}; Raça {pet.Raça}; Idade: {pet.Idade} anos. ");
            }
        }
    }
}
