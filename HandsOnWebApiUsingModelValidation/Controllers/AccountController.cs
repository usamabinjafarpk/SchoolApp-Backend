using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HandsOnWebApiUsingModelValidation.Models;

namespace HandsOnWebApiUsingModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        List<Login> logins = new List<Login>()
        {
            new Login() {Username="Anna",Password="1234"},
            new Login() {Username="Amal",Password="2345"},
            new Login() {Username="Usama",Password="3456"},
            new Login() {Username="Akhil",Password="4567"}
        };
        List<User> users = new List<User>() 
        { 
            new User(){Id=1,Name="Usama",Email="u@g.c",Mobile="0987654321",Username="Usama",Password="3456"}
        };
        [HttpPost]
        public IActionResult Validate(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var user = logins.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                   /* var user=from i in logins
                             where i.Username == login.Username && i.Password == login.Password
                             select i;*/
                   var user=from l in logins
                            join u in users
                            on l.Username equals u.Username
                            where u.Username == login.Username && u.Password==login.Password
                            select u;
                    if (user != null)
                    {
                        return StatusCode(200, user);
                    }
                    else
                    {
                        return StatusCode(200, new JsonResult("Invalid user"));
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost,Route("Register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Id = new Random().Next(100, 999);
                    users.Add(user);
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(501, ex);
            }
        }
    }
}
