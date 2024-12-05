using Application.Domain;
using Application.Domain.Context;
using Application.Repository.Infrastructure;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddAppointmentResponse> AddAppointment(AddAppointmentRequest request)
        {
            AddAppointmentResponse response = new AddAppointmentResponse();

            try
            {
                AppointmentDetail appointmentDetail = new AppointmentDetail();
                appointmentDetail.Name = request.Name;
                appointmentDetail.Address = request.Address;
                appointmentDetail.Phone = request.Phone;
                appointmentDetail.Date = request.Date;
                appointmentDetail.Time = request.Time;
                await _dbContext.AppointmentDetail.AddAsync(appointmentDetail);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<CancelAppointmentResponse> CancelAppointment(int Id)
        {
            CancelAppointmentResponse response = new CancelAppointmentResponse();

            try
            {
                AppointmentDetail? result = await _dbContext.AppointmentDetail.FindAsync(Id);
                result.Status = Status.CANCEL;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
