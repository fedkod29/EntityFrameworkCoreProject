﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs
{
    public class GETGuestsResultDTO
    {
        public Guid ID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Details { get; set; }
    }
}
