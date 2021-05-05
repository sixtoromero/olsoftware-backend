using OLSoftware.Application.DTO;
using OLSoftware.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLSoftware.Application.Interface
{
    public interface IInfoApplication
    {        
        Task<Response<IEnumerable<InfoProjectDTO>>> GetProjectInfoAsync();
    }
}
