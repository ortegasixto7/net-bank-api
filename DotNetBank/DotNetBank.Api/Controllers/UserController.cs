﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotNetBank.Api.External.Auth;
using DotNetBank.Api.Core.User.UseCases.SignIn;
using DotNetBank.Api.Core.User.UseCases.SignUp;
using DotNetBank.Api.Core.User;

namespace DotNetBank.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthPersistence authPersistence;
        private readonly IUserPersistence userPersistence;
        public UserController(IAuthPersistence authPersistence, IUserPersistence userPersistence)
        {
            this.authPersistence = authPersistence;
            this.userPersistence = userPersistence;
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            return await new EndpointService().ResponseWrapper(() => new SignInUseCase(authPersistence).Execute(request));
        }

        [HttpPost("sign-up/v1")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            return await new EndpointService().ResponseWrapper(() => new SignUpUseCase(userPersistence, authPersistence).Execute(request));
        }
    }
}
