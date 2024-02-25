

namespace GestorPaciente.Core.Application.ViewModels.Paciente
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Cedula { get; set; }
        public string ImageUrl { get; set; }
        public string Direction { get; set; }
        public bool Smoker { get; set; }
        public bool allergies { get; set; }

        public DateTime BirhtDate { get; set; }
    }
}
