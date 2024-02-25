
using System.ComponentModel.DataAnnotations;


namespace GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio
{
    public class SavePruebaLaboratorioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [MaxLength(200, ErrorMessage = "No puedo usar mas de 200 catacteres")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
