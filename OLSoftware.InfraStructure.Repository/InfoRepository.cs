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
    public class InfoRepository : IInfoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public InfoRepository(IConnectionFactory connectionFactory = null)
        {            
            _connectionFactory = connectionFactory;
        }

        
        public async Task<IEnumerable<InfoProject>> GetProjectInfoAsync()
        {            

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetProjectInfo";
                var parameters = new DynamicParameters();
                return await connection.QueryAsync<InfoProject>(query, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
