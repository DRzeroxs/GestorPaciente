using GestorPaciente.Core.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Cita : AuditableBaseEntity
    {
        public string Cause { get; set; }
        public DateTime Date {  get; set; }
        public TimeOnly Hour {  get; set; }

        public bool Complete { get; set; }
        public bool PendingQuery { get; set; }
        public bool PendingResult { get; set; }

        //llaves foraneas
        [ForeignKey("Medico")]
        public int MedicoId { get; set; }

        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        //conductores
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        //conductores
        [InverseProperty("Cita")]
        public ICollection<ResultadoLaboratorio> ResultadoLaboratorios { get; set; }
    }
}
