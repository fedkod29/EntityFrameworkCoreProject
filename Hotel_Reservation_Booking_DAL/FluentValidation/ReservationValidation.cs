using FluentValidation;
using Hotel_Reservation_Booking_Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.FluentValidation
{
    public class ReservationValidation : AbstractValidator<Reservation>
    {
        public ReservationValidation()
        {
            RuleFor(date => date.StartDateTime).LessThanOrEqualTo(DateTime.Now)
                .NotEmpty().NotNull().WithMessage("This started date time must be less than date time now!!!");

            RuleFor(date => date.EndDateTime).Must(this.CheckingEndDateTimeWithMethod)
                .WithMessage("This end date time must be more than date time now!!!");
        }

        private bool CheckingEndDateTimeWithMethod(DateTime dateTime)
        {
            return !dateTime.Equals(DateTime.Now);
        }
    }
}
