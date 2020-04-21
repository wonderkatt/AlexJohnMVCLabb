using AutoMapper;
using BloodBowlTeamManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BloodBowlTeamManager
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BBContext context;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, BBContext context)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }

        [HttpPost]
        [Route("login")]
        public async ValueTask<Result> Login([FromBody]UserLoginModelDTO userModel)
        {
            Result httpResponse = new Result();
            UserLoginModel parsedLoginModel = new UserLoginModel(); ;
            try
            {
                parsedLoginModel = mapper.Map<UserLoginModel>(userModel);
            }
            catch (Exception)
            {
                httpResponse.Success = false;
            }

            var user = await userManager.FindByNameAsync(parsedLoginModel.CoachName);
            if (user != null &&
                await userManager.CheckPasswordAsync(user, parsedLoginModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));

                httpResponse.Success = true;
                return httpResponse;
                
            }
            else
            {
                httpResponse.Errors.Add("Invalid username or password");
                httpResponse.Success = false;
                return httpResponse;
            }
        }
        [HttpPost]
        [Route("logout")]
        public async ValueTask<Result> Logout()
        {
            await signInManager.SignOutAsync();

            return new Result
            {
                Success = true
            };
        }
        [HttpPost]
        [Route("registration")]
        public async ValueTask<Result> Register([FromBody]UserRegistrationModelDTO userModel)
        {
            Result httpResponse = new Result();
            UserRegistrationModel parsedUserModel = new UserRegistrationModel();
            try
            {
                 parsedUserModel = mapper.Map<UserRegistrationModel>(userModel);
            }
            catch (Exception)
            {
                httpResponse.Success = false;
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
            Coach coach = new Coach
            {
                Id = user.Id,
                Teams = new List<Team>()
            };
            context.Coaches.Add(coach);
            context.SaveChanges();
            httpResponse.Success = true;
            return httpResponse;
        }
        [HttpGet]
        [Route("authorize")]
        public async ValueTask<Result> Authorize()
        {
            Result result = new Result();
            result.Success = signInManager.IsSignedIn(User);
            return result;
        }


    }
}
