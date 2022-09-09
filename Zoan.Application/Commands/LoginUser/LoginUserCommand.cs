﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;

namespace Zoan.Application.Commands.LoginUser
{
    public class LoginUserCommand: IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
