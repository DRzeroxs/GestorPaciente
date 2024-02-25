using GestorPaciente.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GestorPaciente.Core.Domain.Entities
{
    public class Usuario : AuditableBaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        [MaxLength(60)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(70)]
        public string Password { get; set; }

        public bool Admin { get; set; }
    }
}
