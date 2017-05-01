using ContactApp.Business.Abstract;
using ContactApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactApp.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public bool UserAuthentication(User user)
        {
            return _userService.UserAuthentication(user.Username, user.Password);
        }
    }
}
