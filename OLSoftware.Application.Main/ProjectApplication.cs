using AutoMapper;
using OLSoftware.Application.DTO;
using OLSoftware.Application.Interface;
using OLSoftware.Domain.Entity;
using OLSoftware.Domain.Interface;
using OLSoftware.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Application.Main
{
    public class ProjectApplication : IProjectApplication
    {
        private readonly IProjectDomain _ProjectsDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ProjectApplication> _logger;

        public ProjectApplication(IProjectDomain ProjectDomain, IMapper mapper, IAppLogger<ProjectApplication> logger)
        {
            _ProjectsDomain = ProjectDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(ProjectDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Project>(model);
                response.Data = await _ProjectsDomain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado la Correspondencia exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(ProjectDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Project>(model);
                response.Data = await _ProjectsDomain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Correspondencia exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _ProjectsDomain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado, por favor intente nuevamente " + response.Data);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<ProjectDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProjectDTO>>();
            try
            {
                var resp = await _ProjectsDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ProjectDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error inesperado consultando");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<ProjectDTO>> GetProjectInfoAsync()
        {
            var response = new Response<ProjectDTO>();
            try
            {
                var resp = await _ProjectsDomain.GetProjectInfoAsync();

                response.Data = _mapper.Map<ProjectDTO>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando los registros por Id.");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }       

        public async Task<Response<ProjectDTO>> GetAsync(int? Id)
        {
            var response = new Response<ProjectDTO>();
            try
            {
                var clase = await _ProjectsDomain.GetAsync(Id);

                response.Data = _mapper.Map<ProjectDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
                    _logger.LogWarning("Ha ocurrido un inconveniente al consultar los registros de Correspondencias");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }        
    }
}
