
using System.ComponentModel.DataAnnotations;


namespace GestorPaciente.Core.Application.ViewModels.Usuario
{
    public class SaveUsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar el apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre de usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool Admin { get; set; }
    }
}
