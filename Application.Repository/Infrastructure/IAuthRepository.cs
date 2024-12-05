using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain;

namespace Application.Repository.Infrastructure
{
    public interface IAuthRepository
    {
        public Task<SignInResponse> SignIn(SignInRequest request);
    }
}
