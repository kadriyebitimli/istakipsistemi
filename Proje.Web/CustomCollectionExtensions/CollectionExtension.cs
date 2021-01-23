using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Proje.DTO.DTOs.AciliyetDtos;
using Proje.DTO.DTOs.AppUserDtos;
using Proje.DTO.DTOs.GorevDtos;
using Proje.DTO.DTOs.RaporDtos;
using Proje.ToDo.Business.ValidationRules.FluentValidation;
using Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Proje.ToDo.Entities.Concrete;
using System;

namespace Proje.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false; //sayi icerme zorunlulugunu false yaparız.
                opt.Password.RequireUppercase = false;//bir büyük harf içerme zorunlulugunu false yaptım.
                opt.Password.RequiredLength = 1;//en az bir karakter olacak.
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;//ünlem,soru işareti gibi karakter zorunlulugunu false yapıyorum.

            })

                 .AddEntityFrameworkStores<TodoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//baska web sayfalarıyla paylasılmasını ıstemiyorm.
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";


            });
        }
        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AciliyetAddDto>, AciliyetAddValidator>();
            services.AddTransient<IValidator<AciliyetUpdateDto>, AciliyetUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<GorevAddDto>, GorevAddValidator>();
            services.AddTransient<IValidator<GorevUpdateDto>, GorevUpdateValidator>();
            services.AddTransient<IValidator<RaporAddDto>, RaporAddValidator>();
            services.AddTransient<IValidator<RaporUpdateDto>, RaporUpdateValidator>();

        }
    }
}
