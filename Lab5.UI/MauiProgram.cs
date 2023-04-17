using CommunityToolkit.Maui;
using Lab5.Application.Abstractions;
using Lab5.Application.Services;
using Lab5.Domain.Abstractions;
using Lab5.Persistence.Data;
using Lab5.Persistence.UnitOfWork;
using Lab5.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lab5.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            SetupServices(builder.Services);
            SetupViewModels(builder.Services);
            SetupViews(builder.Services);

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=database.db")
                .Options;


            services.AddSingleton(new AppDbContext(options));

            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();

            services.AddSingleton<ISetService, SetService>();
            services.AddSingleton<ISushiService, SushiService>();
        }

        private static void SetupViewModels(IServiceCollection services)
        {
            services.AddTransient<SetViewModel>();
        }

        private static void SetupViews(IServiceCollection services)
        {
            services.AddTransient<Pages.Sets>();
        }
    }
}