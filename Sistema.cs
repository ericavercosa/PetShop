using System.Threading.Channels;

namespace Desafios._2
{
    internal class SistemaPetShop
    {
        public static List<Dono> DonosCadastrados { get; set; } = new List<Dono>();
        public static List<Medico> MedicosCadastrados { get; set; } = new List<Medico>();
        public static List<Consulta> ConsultasAgendadas { get; set; } = new List<Consulta>();
        public static List<Pet> PetsCadastrados { get; set; } = new List<Pet>();
    }

}
