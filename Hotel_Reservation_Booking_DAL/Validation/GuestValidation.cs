using FluentValidation;
using Hotel_Reservation_Booking_Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Validation
{
    public class GuestValidation : AbstractValidator<Guests>
    {
        public GuestValidation()
        {
            RuleFor(guests => guests.FirstName)
             .NotEmpty().WithMessage("First name is required.")
             .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(guests => guests.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            RuleFor(guests => guests.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(guests => guests.Mobile)
                .NotEmpty().WithMessage("Mobile number is required.")
                .MaximumLength(100).WithMessage("Mobile number must not exceed 100 characters.");

            RuleFor(guests => guests.Details)
                .MaximumLength(255).WithMessage("Details must not exceed 255 characters.");

            RuleFor(guests => guests.Reservations)
                .NotNull().WithMessage("Reservations collection must not be null.");

            RuleFor(guests => guests.InvoiceGuests)
                .NotNull().WithMessage("InvoiceGuests collection must not be null.");
        }
    }
}
