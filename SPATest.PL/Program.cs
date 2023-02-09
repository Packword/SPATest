using SPATest.BuisnessLayer.DTO;
using SPATest.BuisnessLayer.Interfaces;
using SPATest.BuisnessLayer.Services;

namespace SPATest.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IOfferService<MusicOfferDTO>, MusicOfferService>();

            var app = builder.Build();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=MusicOffer}/{action=Index}/{id?}");

            app.Run();
        }
    }
}