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

            AddDbContext(builder);
            SetupServices(builder.Services);
            SetupViewModels(builder.Services);
            SetupViews(builder.Services);
            SeedData(builder.Services);

            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {
            //services.AddSingleton(new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()));

            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();

            services.AddSingleton<ISetService, SetService>();
            services.AddSingleton<ISushiService, SushiService>();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connStr = builder.Configuration
            .GetConnectionString("SqliteConnection");
            string dataDirectory = String.Empty;
#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + "/";
#endif
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;
            builder.Services.AddSingleton<AppDbContext>((s) => new AppDbContext(options));
        }

        public async static void SeedData(IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();
            var unitOfWork = provider.GetService<IUnitOfWork>();
            await unitOfWork.RemoveDatbaseAsync();
            await unitOfWork.CreateDatabaseAsync();
            // Add cources
            IReadOnlyList<Set> sets = new List<Set>()
        {
            new Set(1, 129.99, "Сяке сет", "Без огурцов", 1200),
            new Set(2, 139.99, "Кунсей сет", "Много огурцов", 1400)
        };
            foreach (var set in sets)
                await unitOfWork._setRepository.AddAsync(set);
            await unitOfWork.SaveAllAsync();
            //Add sushi
            foreach (var set in sets)
                for (int j = 0; j < 10; j++)
                    await unitOfWork._sushiRepository.AddAsync(new Sushi(j, $"Суши {j}", 4, set.Id));
            await unitOfWork.SaveAllAsync();
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