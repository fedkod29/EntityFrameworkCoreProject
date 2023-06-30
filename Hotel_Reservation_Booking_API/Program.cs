using Hotel_Reservation_Booking_BLL.Services.Interfaces;
using Hotel_Reservation_Booking_BLL.Services;
using Hotel_Reservation_Booking_DAL.Contex;
using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Hotel_Reservation_Booking_DAL.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hotel Reservation Booking App",
        Description = "Faster, cheaper transportation options allow us to travel across the world in a matter of hours. " +
        "And people have more disposable income than ever before. Is it any surprise that tourism is growing rapidly?"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<HotelReservationBookingContext>(configurations =>
{
    configurations.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        options => options.MigrationsAssembly("HotelReservationBookingFramework"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGuestsService, GuestsService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
        s.RoutePrefix = "swagger";
    });
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();