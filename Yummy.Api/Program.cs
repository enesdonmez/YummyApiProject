using FluentValidation;
using Scalar.AspNetCore;
using Yummy.Api.Context;
using Yummy.Api.Entitites;
using Yummy.Api.ValidationRules;

namespace Yummy.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<ApiContext>();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<IValidator<MenuItem>, MenuItemValidator>();
        builder.Services.AddScoped<IValidator<Chef>, ChefValidator>();
        builder.Services.AddScoped<IValidator<Contact>, ContactValidator>();
        builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(opt => opt.Theme = ScalarTheme.Mars);
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
