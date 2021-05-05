using OLSoftware.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLSoftware.InfraStructure.Interface
{
    public interface IInfoRepository
    {
        Task<IEnumerable<InfoProject>> GetProjectInfoAsync();
    }
}
