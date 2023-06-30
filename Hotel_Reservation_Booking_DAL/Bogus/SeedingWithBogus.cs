using Bogus;
using Hotel_Reservation_Booking_DAL.Enums;
using Hotel_Reservation_Booking_Data_access.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Bogus
{
    public class SeedingWithBogus
    {
        public IEnumerable<RoomsCategories> RoomsCategories { get; set; } = new List<RoomsCategories>();
        public IEnumerable<HotelCategories> HotelCategories { get; set; } = new List<HotelCategories>();
        public IEnumerable<Countries> Countries { get; set; } = new List<Countries>();
        public IEnumerable<Cities> Cities { get; set; } = new List<Cities>();
        public IEnumerable<Companies> Companies { get; set; } = new List<Companies>();
        public IEnumerable<Hotel> Hotels { get; set; } = new List<Hotel>();
        public IEnumerable<Rooms> Rooms { get; set; } = new List<Rooms>();
        public IEnumerable<Guests> Guests { get; set; } = new List<Guests>();  
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
        public IEnumerable<InvoiceGuests> InvoiceGuests { get; set; } = new List<InvoiceGuests>();
        public IEnumerable<RoomReserved> RoomReserveds { get; set; } = new List<RoomReserved>();

        public SeedingWithBogus()
        {
            RoomsCategories = RoomsCategoriesSeeding();
            HotelCategories = HotelCategoriesSeeding();
            Countries = CountriesSeeding();
            Cities = CitiesSeeding(Countries);
            Companies = CompaniesSeeding(Cities);
            Hotels = HotelSeeding(HotelCategories, Cities, Companies);
            Rooms = RoomsSeeding(Hotels, RoomsCategories);
            Guests = GuestsSeeding();
            Reservations = ReservationsSeeding(Guests);
            InvoiceGuests = InvoiceGuestsSeeding(Guests, Reservations);
            RoomReserveds = RoomReservedsSeeding(Reservations, Rooms);
        }

        private IEnumerable<RoomsCategories> RoomsCategoriesSeeding(int size = 10)
        {
            var roomsCategories = new Faker<RoomsCategories>().Generate(size);

            var roomsEnum = Enum.GetNames(typeof(RoomsCategoriesEnum));

            for (int i = 0; i < roomsCategories.Count; i++) 
            { 
                roomsCategories.ToArray()[i].Title = roomsEnum[i]; 
            }

            return roomsCategories;
        }

        private IEnumerable<HotelCategories> HotelCategoriesSeeding (int size = 10)
        {
            var hotelsCategories = new Faker<HotelCategories>().Generate(size);

            var hotelsEnum = Enum.GetNames(typeof(HotelCategoriesEnum));

            for (int i = 0; i < hotelsCategories.Count; i++)
            {
                hotelsCategories.ToArray()[i].Title = hotelsEnum[i];
            }

            return hotelsCategories;
        }

        private IEnumerable<Countries> CountriesSeeding(int size = 20) 
        {
            var countries = new Faker<Countries>()
                .RuleFor(x => x.Title, f => f.Address.Country())
                .Generate(size);

            return countries;
        }

        private IEnumerable<Cities> CitiesSeeding(IEnumerable<Countries> countries, int size = 50)
        {
            var cities = new Faker<Cities>()
                .RuleFor(x => x.Title, f => f.Address.City())
                .RuleFor(x => x.PostalCode, f => f.Address.ZipCode())
                .RuleFor(x => x.CountriesID, f => f.PickRandom(countries).ID)
                .Generate(size);

            return cities;
        }

        private IEnumerable<Companies> CompaniesSeeding(IEnumerable<Cities> cities, int size = 150)
        {
            var companies = new Faker<Companies>()
                .RuleFor(x => x.Title, f => f.Company.CompanyName())
                .RuleFor(x => x.Details, f => f.Company.CompanySuffix())
                .RuleFor(x => x.Email, (o, f) => o.Internet.Email(f.Title))
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .RuleFor(x => x.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.IsActive, f => f.Random.Bool())
                .RuleFor(x => x.CitiesID, f => f.PickRandom(cities).ID)
                .Generate(size);

            return companies;
        }

        private IEnumerable<Hotel> HotelSeeding(IEnumerable<HotelCategories> hotelsCategories, 
            IEnumerable<Cities> cities, IEnumerable<Companies> companies,
            int size = 100)
        {
            var hotel = new Faker<Hotel>()
               .RuleFor(h => h.Title, f => f.Company.CompanyName())
               .RuleFor(h => h.Description, f => f.Lorem.Paragraph())
               .RuleFor(h => h.IsActive, f => f.Random.Bool())
               .RuleFor(h => h.HotelCategoriesID, f => f.PickRandom(hotelsCategories).ID)
               .RuleFor(h => h.CitiesID, f => f.PickRandom(cities).ID)
               .RuleFor(h => h.CompaniesID, f => f.PickRandom(companies).ID)
               .Generate(size);

            return hotel;
        }

        private IEnumerable<Rooms> RoomsSeeding(IEnumerable<Hotel> hotels, IEnumerable<RoomsCategories> roomsCategories, 
            int size = 200)
        {
            var rooms = new Faker<Rooms>()
                .RuleFor(r => r.Title, f => f.Lorem.Word())
                .RuleFor(r => r.Description, f => f.Lorem.Sentence())
                .RuleFor(r => r.Price, f => f.Random.Decimal(50, 200))
                .RuleFor(r => r.HotelID, f => f.PickRandom(hotels).ID)
                .RuleFor(r => r.RoomsCategoriesID, f => f.PickRandom(roomsCategories).ID)
                .Generate(size);

            return rooms;
        }

        private IEnumerable<Guests> GuestsSeeding(int size = 150)
        {
            var guests = new Faker<Guests>()
                .RuleFor(g => g.FirstName, f => f.Person.FirstName)
                .RuleFor(g => g.LastName, f => f.Person.LastName)
                .RuleFor(g => g.Email, f => f.Person.Email)
                .RuleFor(g => g.Mobile, f => f.Person.Phone)
                .RuleFor(g => g.Details, f => f.Lorem.Sentence())
                .Generate(size);

            return guests;
        }

        private IEnumerable<Reservation> ReservationsSeeding(IEnumerable<Guests> guests, int size = 100)
        {
            var reservation = new Faker<Reservation>()
                .RuleFor(r => r.StartDateTime, f => f.Date.Future())
                .RuleFor(r => r.EndDateTime, (f, r) => f.Date.Between(r.StartDateTime, r.StartDateTime.AddDays(7)))
                .RuleFor(r => r.CreatedDateTime, f => f.Date.Past())
                .RuleFor(r => r.DiscountPercent, f => f.Random.Decimal(0, 100))
                .RuleFor(r => r.TotalPrice, f => f.Random.Decimal(0, 1000))
                .RuleFor(r => r.GuestsID, f => f.PickRandom(guests).ID)
                .Generate(size);

            return reservation;
        }

        private IEnumerable<InvoiceGuests> InvoiceGuestsSeeding(IEnumerable<Guests> guests, 
            IEnumerable<Reservation> reservations, 
            int size = 100)
        {
            var invoiceGuests = new Faker<InvoiceGuests>()
                .RuleFor(i => i.IssuedDateTime, f => f.Date.Past())
                .RuleFor(i => i.GuestsID, f => f.PickRandom(guests).ID)
                .RuleFor(i => i.ReservationID, f => f.PickRandom(reservations).ID)
                .Generate(size);

            return invoiceGuests;
        }

        private IEnumerable<RoomReserved> RoomReservedsSeeding(IEnumerable<Reservation> reservations, 
            IEnumerable<Rooms> rooms, 
            int size = 200)
        {
            var roomReserveds = new Faker<RoomReserved>()
                .RuleFor(r => r.Price, f => f.Random.Decimal(0, 1000))
                .RuleFor(x => x.ReservationID, f => f.PickRandom(reservations).ID)
                .RuleFor(x => x.RoomsID, f => f.PickRandom(rooms).ID)
                .Generate(size);

            return roomReserveds;
        }
    }
}
