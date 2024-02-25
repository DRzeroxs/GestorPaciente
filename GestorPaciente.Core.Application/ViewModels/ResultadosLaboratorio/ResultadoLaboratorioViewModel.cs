using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;


namespace GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio
{
    public class ResultadoLaboratorioViewModel
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public bool Pending { get; set; }

        public int PruebaLaboratorioId { get; set; }

        public PacienteViewModel Paciente { get; set; }

        public PruebaLaboratorioViewModel PruebaLaboratorio { get; set; }

        public int CitaId { get; set; }

        public CitaViewModel Cita { get; set; }
    }
}
