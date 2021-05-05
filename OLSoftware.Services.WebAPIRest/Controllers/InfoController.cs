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

namespace OLSoftware.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoApplication _InfoApplication;
        private readonly AppSettings _appSettings;

        public InfoController(IInfoApplication InfoApplication,                                
                                IOptions<AppSettings> appSettings)
        {
            _InfoApplication = InfoApplication;
            _appSettings = appSettings.Value;
        }


        [HttpGet("GetProjectInfoAsync")]
        public async Task<IActionResult> GetProjectInfoAsync()
        {            
            Response<IEnumerable<InfoProjectDTO>> response = new Response<IEnumerable<InfoProjectDTO>>();

            try
            {
                response = await _InfoApplication.GetProjectInfoAsync();
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
