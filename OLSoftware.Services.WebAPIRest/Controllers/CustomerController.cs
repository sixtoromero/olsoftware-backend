using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OLSoftware.Application.DTO;
using OLSoftware.Application.Interface;
using OLSoftware.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using OLSoftware.InfraStructure.DAL;

namespace OLSoftware.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly DbContextOptions<OLSoftwareDataContext> options;
        private readonly ICustomerApplication _CustomerApplication;
        private readonly AppSettings _appSettings;

        public CustomerController(ICustomerApplication CustomerApplication,
                                DbContextOptions<OLSoftwareDataContext> options,
                                IOptions<AppSettings> appSettings)
        {
            this.options = options;
            _CustomerApplication = CustomerApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(CustomerDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {                
                if (model == null)
                    return BadRequest();

                response = await _CustomerApplication.InsertAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {                

                if (model == null)
                    return BadRequest();

                response = await _CustomerApplication.UpdateAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
            
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _CustomerApplication.DeleteAsync(Id);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CustomerDTO>> response = new Response<IEnumerable<CustomerDTO>>();

            try
            {
                response = await _CustomerApplication.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }       

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            Response<CustomerDTO> response = new Response<CustomerDTO>();

            try
            {
                response = await _CustomerApplication.GetAsync(Id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }        
    }
}
