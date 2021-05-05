using Microsoft.Extensions.Configuration;
using OLSoftware.Domain.Entity;
using OLSoftware.Domain.Interface;
using OLSoftware.InfraStructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Domain.Core
{
    public class InfoDomain : IInfoDomain
    {
        private readonly IInfoRepository _Repository;
        public IConfiguration Configuration { get; }

        public InfoDomain(IInfoRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<InfoProject>> GetProjectInfoAsync()
        {
            return await _Repository.GetProjectInfoAsync();
        }
    }
}
