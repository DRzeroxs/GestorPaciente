
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace GestorPaciente.Core.Application.ViewModels.Paciente
{
    public class SavePacienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [MaxLength(60, ErrorMessage = "No puedo usar mas de 60 catacteres")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [MaxLength(80, ErrorMessage = "No puedo usar mas de 80 catacteres")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un numero celular")]
        [MaxLength(20, ErrorMessage = "No puedo usar mas de 20 catacteres")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Debe colocar su cedula")]
        [MaxLength(20, ErrorMessage = "No puedo usar mas de 20 catacteres")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Debe colocar su cedula")]
        [MaxLength(150, ErrorMessage = "No puedo usar mas de 150 catacteres")]
        [DataType(DataType.Text)]
        public string Direction { get; set; }

        [Required(ErrorMessage = "Debe colocar la fecha de nacimiento")]
        public DateTime BirhtDate { get; set; }

        public bool Smoker { get; set; }

        public bool Allergies { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
