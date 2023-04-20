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
            var connStr = builder.Configuration
            .GetConnectionString("SqliteConnection");
            string dataDirectory = string.Empty;
#if ANDROID
            dataDirectory = FileSystem.AppDataDirectory + "/";
#endif
            connStr = string.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
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
            IList<Set> sets = new List<Set>()
        {
            new Set(1, 129.99, "Сяке сет", "Без огурцов", 1200),
            new Set(2, 139.99, "Кунсей сет", "Много огурцов", 1400)
        };

            foreach (var set in sets)
                await unitOfWork._setRepository.AddAsync(set);
            try
            {
                await unitOfWork.SaveAllAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //Add sushi
            for (int j = 1; j < 10; j++)
                await unitOfWork._sushiRepository.AddAsync(new Sushi(j, $"Суши {j}", 4, new List<Set> { sets[0] }));
            /*for (int i = 1; i < 10; i++)
                unitOfWork._sushiRepository.ListAllAsync().Result[i].Sets.Add(sets[0]);*/
            for (int j = 10; j < 19; j++)
            {
                await unitOfWork._sushiRepository.AddAsync(new Sushi(j, $"Суши {j}", 10, new List<Set> { sets[1] }));
            }
            
            try
            {
                await unitOfWork.SaveAllAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void SetupServices(IServiceCollection services)
        {
            //services.AddSingleton(new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()));
            //services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();

            services.AddSingleton<ISetService, SetService>();
            services.AddSingleton<ISushiService, SushiService>();
        }
        private static void SetupViewModels(IServiceCollection services)
        {
            services.AddTransient<SetViewModel>();
            services.AddTransient<DetailsViewModel>();
        }

        private static void SetupViews(IServiceCollection services)
        {
            services.AddTransient<Pages.Sets>();
            services.AddTransient<Pages.Details>();
        }
    }
}