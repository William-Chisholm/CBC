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
    public class EstimatorController : ControllerBase
    {
        [HttpGet("{package}")]
        public List<Package> GetPackage(string package)
        {
            return Queries.GetPackage(package);
        }

        [HttpGet]
        public List<PackageList> GetAllPackages()
        {
            return Queries.GetAllPackages();
        }
    }
}
