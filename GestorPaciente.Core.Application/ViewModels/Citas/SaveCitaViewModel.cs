using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModels.Citas
{
    public class SaveCitaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Ingresar la causa de la Cita")]
        [DataType(DataType.Text)]
        public string cause { get; set; }

        [Required(ErrorMessage = "Debe colocar la fecha de la cita")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Debe colocar la hora de la Cita")]
        [DataType(DataType.Time)]
        public TimeOnly Hour { get; set; }

        public bool Complete { get; set; }
        public bool PendingQuery { get; set; } = true;
        public bool PendingResult { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el medico")]
        public int MedicoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el paciente")]
        public int PacienteId { get; set; }
        public List<PacienteViewModel>? Pacientes { get; set; }
        public List<MedicoViewModel>? Medicos { get; set; }

    }
}
