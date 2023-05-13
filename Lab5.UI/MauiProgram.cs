using CommunityToolkit.Maui;
using Lab5.Application.Abstractions;
using Lab5.Application.Services;
using Lab5.Domain.Abstractions;
using Lab5.Domain.Entities;
using Lab5.Persistence.Data;
using Lab5.Persistence.UnitOfWork;
using Lab5.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Lab5.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "Lab5.UI.appsettings.json";

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
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            SetupServices(builder.Services);
            SetupViewModels(builder.Services);
            SetupViews(builder.Services);
            AddDbContext(builder);
            SeedData(builder);

            return builder.Build();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connectionString = builder.Configuration
            .GetConnectionString("SqliteConnection");
            string dataDirectory = string.Empty;
#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + Path.DirectorySeparatorChar;
#else
            dataDirectory = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar;
#endif
            connectionString = string.Format(connectionString, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connectionString)
            .EnableSensitiveDataLogging()
            .Options;
            builder.Services.AddSingleton((s) => new AppDbContext(options));
        }

        public async static void SeedData(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IUnitOfWork, EfUnitOfWork>();

            using var provider = builder.Services.BuildServiceProvider();

            var unitOfWork = provider.GetService<IUnitOfWork>();
            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();
            // Add sets
            IList<Set> sets = new List<Set>() {
                new Set(129.99, "Сяке сет", "Без огурцов", 1200),
                new Set(139.99, "Кунсей сет", "Много огурцов", 1400)
            };

            foreach (var set in sets)
            {
                await unitOfWork._setRepository.AddAsync(set);
            }
            await unitOfWork.SaveAllAsync();
            foreach (var set in sets)
            {
                for (int j = 1; j < new Random().Next(4, 10); j++)
                {
                    await unitOfWork._sushiRepository.AddAsync(new Sushi($"Суши {j}", new Random().Next(4, 12), new List<Set> { set }));
                }
            }
            await unitOfWork.SaveAllAsync();
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddSingleton<ISetService, SetService>();
            services.AddSingleton<ISushiService, SushiService>();
        }

        private static void SetupViewModels(IServiceCollection services)
        {
            services.AddSingleton<SetViewModel>();
            services.AddSingleton<SushiViewModel>();
        }

        private static void SetupViews(IServiceCollection services)
        {
            services.AddSingleton<Pages.Sets>();
            services.AddTransient<Pages.Details>();
            services.AddTransient<Pages.EditSushiPage>();
        }
    }
}