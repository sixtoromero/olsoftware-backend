using OLSoftware.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLSoftware.Domain.Interface
{
    public interface IProjectDomain : IDomain<Project>
    {
        Task<Project> GetProjectInfoAsync();
    }
}
