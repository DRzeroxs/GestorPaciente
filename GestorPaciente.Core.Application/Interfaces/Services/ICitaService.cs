using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface ICitaService : IGenericService< SaveCitaViewModel,CitaViewModel, Cita>
    {
    }
}
