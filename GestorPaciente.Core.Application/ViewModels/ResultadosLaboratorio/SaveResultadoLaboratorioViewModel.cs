
using System.ComponentModel.DataAnnotations;


namespace GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio
{
    public class SaveResultadoLaboratorioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar cual fue el resultado")]
        public string? Result { get; set; }
        public bool Pending { get; set; }

        public int? PruebaLaboratorioId { get; set; }

        public int? CitaId { get; set; }
    }
}
