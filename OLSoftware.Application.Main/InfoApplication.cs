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
    public class InfoApplication : IInfoApplication
    {
        private readonly IInfoDomain _InfoDomain;
        private readonly IMapper _mapper;

        public InfoApplication(IInfoDomain InfoDomain, IMapper mapper, IAppLogger<ProjectApplication> logger)
        {
            _InfoDomain = InfoDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<InfoProjectDTO>>> GetProjectInfoAsync()
        {
            var response = new Response<IEnumerable<InfoProjectDTO>>();
            try
            {
                var resp = await _InfoDomain.GetProjectInfoAsync();
                response.Data = _mapper.Map<IEnumerable<InfoProjectDTO>>(resp);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
