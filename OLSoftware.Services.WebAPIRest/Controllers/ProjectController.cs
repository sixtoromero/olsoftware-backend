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
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DbContextOptions<OLSoftwareDataContext> options;
        private readonly IProjectApplication _ProjectApplication;
        private readonly AppSettings _appSettings;        

        public ProjectController(IProjectApplication ProjectApplication,
                                DbContextOptions<OLSoftwareDataContext> options,                                
                                IOptions<AppSettings> appSettings)
        {
            this.options = options;
            _ProjectApplication = ProjectApplication;
            _appSettings = appSettings.Value;            
        }

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync(ProjectDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();

                response = await _ProjectApplication.InsertAsync(model);
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

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(ProjectDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {

                if (model == null)
                    return BadRequest();

                response = await _ProjectApplication.UpdateAsync(model);
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

        [HttpDelete("DeleteAsync/{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _ProjectApplication.DeleteAsync(Id);

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

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<ProjectDTO>> response = new Response<IEnumerable<ProjectDTO>>();

            try
            {
                response = await _ProjectApplication.GetAllAsync();
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

        [HttpGet("GetProjectInfoAsync")]
        public async Task<IActionResult> GetProjectInfoAsync()
        {
            Response<ProjectDTO> response = new Response<ProjectDTO>();

            try
            {
                response = await _ProjectApplication.GetProjectInfoAsync();
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

        [HttpGet("GetAsync/{Id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            Response<ProjectDTO> response = new Response<ProjectDTO>();

            try
            {
                response = await _ProjectApplication.GetAsync(Id);
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
