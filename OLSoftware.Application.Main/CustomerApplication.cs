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
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _CustomersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;

        public CustomerApplication(ICustomerDomain CustomerDomain, IMapper mapper, IAppLogger<CustomerApplication> logger)
        {
            _CustomersDomain = CustomerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(CustomerDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Customer>(model);
                response.Data = await _CustomersDomain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Customer exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(CustomerDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Customer>(model);
                response.Data = await _CustomersDomain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Customer exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _CustomersDomain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var resp = await _CustomersDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(resp);
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

        public async Task<Response<CustomerDTO>> GetAsync(int? Id)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var clase = await _CustomersDomain.GetAsync(Id);

                response.Data = _mapper.Map<CustomerDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
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
