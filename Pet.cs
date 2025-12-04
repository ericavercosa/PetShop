namespace Desafios._2
{
    internal class Pet
    {
        public Pet(string nome, string especie, string raça, int idade, Dono dono)
        {
            Nome = nome;
            Raça = raça;
            Idade = idade;
            Especie = especie;
            Dono = dono;
        }

        public string Nome { get; set; }
        public string Raça { get; set; }
        public int Idade { get; set; }

        public string Especie { get; set; }

        public Dono Dono { get; set; }
        public static Pet InserirPet(Dono dono)
        {
            Console.WriteLine("Insira o nome do Pet:");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira a espécie do Pet:");
            string especie = Console.ReadLine();
            Console.WriteLine("Insira a raça do Pet:");
            string raça = Console.ReadLine();
            Console.WriteLine("Insira a idade do Pet:");
            int idade = int.Parse(Console.ReadLine());
            Pet novoPet = new Pet(nome, especie, raça, idade, dono);
            SistemaPetShop.PetsCadastrados.Add(novoPet);
            return novoPet; // retorna as informações do pet
        }
        public void ExibirPet()
        {
            Console.WriteLine($"Nome do Pet:{Nome}; Espécie: {Especie}; Raça {Raça}; Idade: {Idade}; Dono: {Dono.Nome}.");
        }
    }
}
