using GestorPaciente.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPaciente.Core.Domain.Entities
{
    public class PruebaLaboratorio : AuditableBaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }

        //conductor
        [InverseProperty("PruebaLaboratorio")]
        public ICollection<ResultadoLaboratorio> ResultadosLaboratorios { get; set; }
    }
}
