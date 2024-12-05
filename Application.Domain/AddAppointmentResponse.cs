using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class AddAppointmentResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Successful";
    }

    
}
