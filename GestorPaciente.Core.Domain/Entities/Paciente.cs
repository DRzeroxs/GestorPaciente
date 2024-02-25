using GestorPaciente.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Paciente : PropiedadesComunes
    {
        [MaxLength(150)]
        public string Direction { get; set; }

        public DateTime BirhtDate { get; set; }

        public bool Smoker {  get; set; }
        public bool allergies { get; set; }

        //conductores
        [InverseProperty("Paciente")]
        public ICollection<Cita> citas { get; set; }
    }
}
