using Microsoft.AspNetCore.Mvc;
using System;

namespace CBC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserManagementController : ControllerBase
    {
        [HttpGet]
        public string GenerateUserText()
        {
            return GenerateText.GenerateUserText();
        }

        [HttpPost("{firstName}/{lastName}/{userName}/{key}/{password}/{access}")]
        public void AddUser(string firstName, string lastName, string userName, string key, string password, int access)
        {
            Console.WriteLine("ADDING USER...");
            Queries.AddUser(firstName, lastName, userName, key, password, access);
        }
    }
}
