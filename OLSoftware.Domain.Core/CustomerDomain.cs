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
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _Repository;
        public IConfiguration Configuration { get; }

        public CustomerDomain(ICustomerRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Customer model)
        {
            return await _Repository.InsertAsync(model); 
        }

        public async Task<string> UpdateAsync(Customer model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Customer> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
