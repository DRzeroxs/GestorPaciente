using GestorPaciente.Core.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPaciente.Core.Domain.Entities
{
    public class ResultadoLaboratorio : AuditableBaseEntity
    {
        public string Result {  get; set; }
        public bool Pending { get; set; }

        //llaves foraneas

        [ForeignKey("PruebaLaboratio")]
        public int PruebaLaboratorioId { get; set; }

        [ForeignKey("Cita")]
        public int CitaId { get; set; }

        //conductores
        public PruebaLaboratorio PruebaLaboratorio { get; set; }
        public Cita Cita { get; set; }

    }
}
