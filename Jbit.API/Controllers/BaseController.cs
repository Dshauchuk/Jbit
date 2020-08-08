using AutoMapper;
using Jbit.Common.Auth.Extensions;
using Jbit.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jbit.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    { 
        public BaseController(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected readonly IMapper mapper;
        
        protected readonly IHttpContextAccessor httpContextAccessor;

        protected UserContext UserContext => httpContextAccessor.GetUserContext();

    }
}
