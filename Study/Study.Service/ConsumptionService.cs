using Study.Core.Entity;
using Study.Core.Interfaces;
using Study.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study.Service
{
    public class ConsumptionService : IConsumptionService
    {
        public Task<BaseResponse<List<AuthItem>>> GetAuthListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseResponse<UserInfo>> LoginAsync(string account, string passWord)
        {
            throw new System.NotImplementedException();
        }
    }
}
