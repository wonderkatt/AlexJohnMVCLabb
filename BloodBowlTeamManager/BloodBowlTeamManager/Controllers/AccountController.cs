using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlTeamManager
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        public AccountController(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("registration")]
        public async ValueTask<Result> Register([FromBody]UserRegistrationModelDTO userModel)
        {
            Result httpResponse = new Result();
            UserRegistrationModel parsedUserModel;
            try
            {
                 parsedUserModel = mapper.Map<UserRegistrationModel>(userModel);
            }
            catch (Exception)
            {

                throw;
            }

            var user = mapper.Map<User>(parsedUserModel);
            var result = await userManager.CreateAsync(user, userModel.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    httpResponse.Errors.Add(error.Description);
                }

                httpResponse.Success = result.Succeeded;
                return httpResponse;
            }

            await userManager.AddToRoleAsync(user, "Visitor");
            httpResponse.Success = true;
            return httpResponse;
        }
    }
}
