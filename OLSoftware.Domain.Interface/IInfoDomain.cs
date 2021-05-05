using OLSoftware.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Domain.Interface
{
    public interface IInfoDomain
    {
        Task<IEnumerable<InfoProject>> GetProjectInfoAsync();
    }
}
