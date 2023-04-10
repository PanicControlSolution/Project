using CommunityToolkit.Maui;
using Lab5.Application.Abstractions;
using Lab5.Application.Services;
using Lab5.Domain.Abstractions;
using Lab5.Persistence.Data;
using Lab5.Persistence.UnitOfWork;
using Lab5.UI.ViewModels;
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

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddSingleton(new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()));

            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();

            services.AddSingleton<ISetService, SetService>();
            services.AddSingleton<ISushiService, SushiService>();

            services.AddTransient<Pages.Sets>();
            services.AddTransient<SetViewModel>();
        }
    }
}