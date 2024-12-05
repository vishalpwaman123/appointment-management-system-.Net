using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain;

namespace Application.Repository.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<AddAppointmentResponse> AddAppointment(AddAppointmentRequest request);
        Task<GetAppointmentListResponse> GetAppointmentList(int UserId);
        Task<CancelAppointmentResponse> CancelAppointment(int Id);
    }
}
