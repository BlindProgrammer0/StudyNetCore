using Consumption.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Study.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> logger;
        protected readonly IUnitOfWork work;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="work"></param>
        public BaseController(ILogger<T> logger, IUnitOfWork work)
        {
            this.logger = logger;
            this.work = work;
        }
    }
}
