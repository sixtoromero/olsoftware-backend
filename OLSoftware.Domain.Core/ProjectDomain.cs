using OLSoftware.Domain.Entity;
using OLSoftware.Domain.Interface;
using OLSoftware.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Domain.Core
{
    public class ProjectDomain : IProjectDomain
    {
        private readonly IProjectRepository _Repository;
        public IConfiguration Configuration { get; }

        public ProjectDomain(IProjectRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Project model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Project model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }        

        public async Task<Project> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }

        public async Task<Project> GetProjectInfoAsync()
        {
            return await _Repository.GetProjectInfoAsync();
        }
    }
}
