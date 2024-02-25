using GestorPaciente.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Medico : PropiedadesComunes
    {
        [MaxLength(100)]
        public string? Email { get; set; }

        //conductores
        [InverseProperty("Medico")]
        public ICollection<Cita> citas { get; set; }

    }
}
