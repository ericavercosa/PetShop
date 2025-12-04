namespace Desafios._2
{
    internal class Medico
    {
        public Medico(string nome, string especialidade)
        {
         Nome = nome;
         Especialidade = especialidade;
        }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public void ExibirMedico()
        {
            Console.WriteLine($"Nome do Médico: {Nome}; Especialidade: {Especialidade}.");
        }

        public static Medico InserirMedico()
        {
            Console.WriteLine("Insira o nome do Médico: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira a especialidade do Médico: ");
            string especialidade = Console.ReadLine();
            Medico novoMedico = new Medico(nome, especialidade);
            SistemaPetShop.MedicosCadastrados.Add(novoMedico);
            return novoMedico; // retorna as informações do médico
        }
    }
}
