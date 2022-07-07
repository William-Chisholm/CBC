using CBC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        [HttpGet("{userName}")]
        public List<UserInfo> GetUserInfo(string userName)
        {
            return Queries.GetUserInfo(userName);
        }
    }
}
