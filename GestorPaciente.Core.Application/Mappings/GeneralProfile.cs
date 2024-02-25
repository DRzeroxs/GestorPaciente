using AutoMapper;
using GestorPaciente.Core.Application.ViewModels.Citas;
using GestorPaciente.Core.Application.ViewModels.Medicos;
using GestorPaciente.Core.Application.ViewModels.Paciente;
using GestorPaciente.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPaciente.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPaciente.Core.Application.ViewModels.Usuario;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            //Cuando se crea el mapeo pasa de propiedad 2 a propiedad 1, como <1,2> con el reverseMap se cambia. 

            #region Cita


            CreateMap<Cita, CitaViewModel>()
                    .ReverseMap()
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.ResultadoLaboratorios, opt => opt.Ignore())
                ;

            CreateMap<Cita, SaveCitaViewModel>()
                .ForMember(dest => dest.Pacientes, opt => opt.Ignore())
                .ForMember(dest => dest.Medicos, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                    .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                    .ForMember(dest => dest.Paciente, opt => opt.Ignore())
                    .ForMember(dest => dest.Medico, opt => opt.Ignore())
                    .ForMember(dest => dest.ResultadoLaboratorios, opt => opt.Ignore())
                ;

            #endregion

            #region Medito

            CreateMap<Medico, MedicoViewModel>().
                ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.citas, opt => opt.Ignore())
                ;

            CreateMap<Medico, SaveMedicoViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.citas, opt => opt.Ignore())
                ;

            #endregion

            #region Paciente

            CreateMap<Paciente, PacienteViewModel>().
                ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.citas, opt => opt.Ignore())
                ;

            CreateMap<Paciente, SavePacienteViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.citas, opt => opt.Ignore())
                ;

            #endregion

            #region Prueba Laboratorio

            CreateMap<PruebaLaboratorio, PruebaLaboratorioViewModel>().
                ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ResultadosLaboratorios, opt => opt.Ignore())
                ;

            CreateMap<PruebaLaboratorio, SavePruebaLaboratorioViewModel>().
                ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ResultadosLaboratorios, opt => opt.Ignore())
                ;

            #endregion

            #region Resultado Laboratorio

            CreateMap<ResultadoLaboratorio, ResultadoLaboratorioViewModel>()
                .ForMember(dest => dest.Paciente, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                ;

            CreateMap<ResultadoLaboratorio, SaveResultadoLaboratorioViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.PruebaLaboratorio, opt => opt.Ignore())
                .ForMember(dest => dest.Cita, opt => opt.Ignore())
                ;

            #endregion

            #region Usuario

            CreateMap<Usuario, UsuarioViewModel>().
                ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                ;

            CreateMap<Usuario, SaveUsuarioViewModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedby, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                ;

            #endregion
        }
    }
}
