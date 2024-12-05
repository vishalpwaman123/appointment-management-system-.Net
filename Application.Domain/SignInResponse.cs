using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class SignInResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Successful";
        public string Token { get; set; } = string.Empty;
        public User Data { get; set; }
    }
}
