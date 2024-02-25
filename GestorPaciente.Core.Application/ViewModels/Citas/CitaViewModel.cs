using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModels.Citas
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public string cause {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Hour {  get; set; }

        public bool Complete { get; set; }
        public bool PendingQuery { get; set; }
        public bool PendingResult { get; set; }

        public int MedicoId { get; set; }

        public MedicoViewModel Medico { get; set; }

        public int PacienteId { get; set; }

        public PacienteViewModel Paciente { get; set; }

        public List<ResultadoLaboratorioViewModel>? Results { get; set; }

    }
}
