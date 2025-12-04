namespace Desafios._2
{
    internal class Consulta
    {
        public DateTime Data { get; set; }
        public Medico Medico { get; set; }
        public Dono Dono { get; set; }
        public Pet Pet { get; set; }

        public Consulta(DateTime data, Medico medico, Dono dono, Pet pet)
        {
            Data = data;
            Medico = medico;
            Dono = dono;
            Pet = pet;
        }

        public void ExibirConsulta()
        {
            Console.WriteLine($"Data da Consulta: {Data}; Médico: {Medico.Nome} - Especialidade: {Medico.Especialidade}; Dono: {Dono.Nome}; Pet: {Pet.Nome} - Espécie: {Pet.Especie} - Raça: {Pet.Raça} - Idade: {Pet.Idade}.");
        }

        public static void InserirConsulta()
        {
            Console.WriteLine("Insira a data da consulta: (Formato dd/mm/aaaa)");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Insira o horário da consulta:");
            string horarioInput = Console.ReadLine();
            DateTime horario = DateTime.ParseExact(horarioInput, "HH:mm", null);
            DateTime dataHoraConsulta = new DateTime(
            data.Year, data.Month, data.Day, horario.Hour, horario.Minute, 0);
            Console.WriteLine("Insira o nome do médico responsável: ");
            string nomeMedico = Console.ReadLine();
            Medico medicoSelecionado = SistemaPetShop.MedicosCadastrados.Find(m => m.Nome.Equals(nomeMedico, StringComparison.OrdinalIgnoreCase));
            if (medicoSelecionado == null)
            {
                Console.WriteLine("Médico não encontrado. Cadastre o médico antes de criar a consulta.");
                return;
            }
            Console.WriteLine("Insira o nome do Dono do Pet:");
            string nomeDono = Console.ReadLine();
            Dono donoSelecionado = SistemaPetShop.DonosCadastrados.Find(d => d.Nome.Equals(nomeDono, StringComparison.OrdinalIgnoreCase));
            if (donoSelecionado == null)
            {
                Console.WriteLine("Dono não encontrado. Cadastre o dono antes de criar a consulta.");
                return;
            }
            Console.WriteLine("Insira o nome do Pet");
            string nomePet = Console.ReadLine();
            Pet petSelecionado = SistemaPetShop.PetsCadastrados.Find(p => p.Nome.Equals(nomePet, StringComparison.OrdinalIgnoreCase) && p.Dono.Nome.Equals(nomeDono, StringComparison.OrdinalIgnoreCase));
            if (petSelecionado == null)
            {
                Console.WriteLine("Pet não encontrado. Cadastre o pet antes de criar a consulta.");
                return;
            }
            
            DateTime dataCompleta = new DateTime(data.Year, data.Month, data.Day);
            Consulta consulta = new Consulta(dataHoraConsulta, medicoSelecionado, donoSelecionado, petSelecionado);
            SistemaPetShop.ConsultasAgendadas.Add(consulta);
            Console.WriteLine("Consulta cadastradas com sucesso!");
        }
    }
}
