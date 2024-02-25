using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio
{
    public class AsignarPruebaViewModel
    {
        public int CitaId { get; set; }

        public List<PruebaLaboratorioViewModel>? Pruebas { get; set; }

        [MinLength(1, ErrorMessage = "Debe seleccionar al menos una prueba")]
        public List<int> PruebasSelesccionadas { get; set; }
    }
}
