using OLSoftware.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLSoftware.InfraStructure.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetProjectInfoAsync();
    }
}
