using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;

namespace dotnetcoregetcurrentservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentUserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<String> Get()
        {
            var context = _httpContextAccessor.HttpContext.User.Identity.Name.Split('\\')[1];
            return "setUser(\"" + context + "\");";
        }
    }
}
