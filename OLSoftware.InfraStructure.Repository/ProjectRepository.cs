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
using System.Linq;

namespace OLSoftware.InfraStructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbContextOptions<OLSoftwareDataContext> options;
        private readonly IConnectionFactory _connectionFactory;

        public ProjectRepository(DbContextOptions<OLSoftwareDataContext> options = null, IConnectionFactory connectionFactory = null)
        {
            this.options = options;
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Project model)
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    model.Date = new DateTime();
                    context.Projects.Add(model);

                    await context.SaveChangesAsync();

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        public async Task<string> UpdateAsync(Project model)
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
                    var project = context.Projects.FirstOrDefaultAsync(x => x.Id == Id);
                    if (project != null)
                    {
                        context.Remove(project);
                        await context.SaveChangesAsync();
                        return "Success";
                    } else
                    {
                        return "No se encontró el registro";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    return await context.Projects.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }        

        public async Task<Project> GetAsync(int? Id)
        {
            try
            {
                using (var context = new OLSoftwareDataContext(this.options))
                {
                    return await context.Projects.FirstOrDefaultAsync(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Project> GetProjectInfoAsync()
        {
            Project mProject = new Project();            

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetProjectInfo";
                var parameters = new DynamicParameters();
                var resp = await connection.QueryAsync<InfoProject>(query, commandType: CommandType.StoredProcedure);
                mProject.InfoProjects = resp.ToList();
                return mProject;
            }
        }

    }
}
