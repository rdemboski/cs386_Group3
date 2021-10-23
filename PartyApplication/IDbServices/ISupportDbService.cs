using PartyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyApplication.IDbServices
{
    public interface ISupportDbService
    {
        Task AddSupportAsync(Support item);
    }
}
