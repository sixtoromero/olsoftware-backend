using Dapper;
using OLSoftware.Domain.Entity;
using OLSoftware.InfraStructure.Interface;
using OLSoftware.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OLSoftware.InfraStructure.DAL;

namespace OLSoftware.InfraStructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContextOptions<OLSoftwareDataContext> options;
        private readonly IConnectionFactory _connectionFactory;

        public CustomerRepository(DbContextOptions<OLSoftwareDataContext> options = null, IConnectionFactory connectionFactory = null)
        {
            this.options = options;
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Customer model)
        {
            using (var context = new OLSoftwareDataContext(this.options))
            {
                try
                {
                    model.Date = new DateTime();
                    context.Customers.Add(model);

                    await context.SaveChangesAsync();

                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> UpdateAsync(Customer model)
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task<string> DeleteAsync(int? Id)
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    var user = await context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
                    if (user == null)
                    {
                        return "No se encontró el registro";
                    }
                    else
                    {
                        context.Remove(user);
                        await context.SaveChangesAsync();
                    }

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    return await context.Customers.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Customer> GetAsync(int? Id)
        {            
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    return await context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }        
    }
}
