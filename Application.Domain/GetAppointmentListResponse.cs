using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class GetAppointmentListResponse : AddAppointmentResponse
    {
        public List<AppointmentDetail> List { get; set; }
    }
}
