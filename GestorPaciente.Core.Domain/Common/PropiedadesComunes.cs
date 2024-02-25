using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Domain.Common
{
    public class PropiedadesComunes : AuditableBaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        [MaxLength (20)]
        public string Phone { get; set; }

        [MaxLength (20)]
        public string Cedula { get; set; }

        public string? ImageUrl { get; set; }
    }
}
