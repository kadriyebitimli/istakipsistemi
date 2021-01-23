using Microsoft.EntityFrameworkCore;
using Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Proje.ToDo.DataAccess.Interfaces;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            /* select *from AspNetUsers inner join AspNetUserRoles 
            on AspNetUsers.Id=AspNetUserRoles.UserId
            inner join AspNetRoles
            on AspNetUserRoles.RoleId=AspNetRoles.Id where AspNetRoles.Name='Member'*/
            using var context = new TodoContext();
           return  context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join
             (context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
             (resultTable, resultRole) => new
             {
                 user = resultTable.user,
                 userRoles = resultTable.userRole,
                 roles = resultRole
             }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
             {
                 Id=I.user.Id,
                 Name=I.user.Name,
                 Surname=I.user.Surname,
                 Picture=I.user.Picture,
                 Email=I.user.Email,
                 UserName=I.user.UserName
             }).ToList();
             


        }
        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa,string aranacakKelime,int aktifSayfa = 1)
        {
            using var context = new TodoContext();

            var result= context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join
              (context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
              (resultTable, resultRole) => new
              {
                  user = resultTable.user,
                  userRoles = resultTable.userRole,
                  roles = resultRole
              }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
              {
                  Id = I.user.Id,
                  Name = I.user.Name,
                  Surname = I.user.Surname,
                  Picture = I.user.Picture,
                  Email = I.user.Email,
                  UserName = I.user.UserName
              });

            toplamSayfa =(int) Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(aranacakKelime))
            {
               result= result.Where(I => I.Name.ToLower().Contains(aranacakKelime) || I.Surname.ToLower()
               .Contains(aranacakKelime.ToLower()));
                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

            }
           result= result.Skip((aktifSayfa - 1) * 3).Take(3);//önemli bir algoritma.microsoftun sitesinde bulunur.

            return result.ToList();
           


        }
        /* select AspNetUsers.UserName,count(Gorevler.Id) from AspNetUsers inner join Gorevler on AspNetUsers.Id=Gorevler.AppUserId
where Gorevler.Durum=1 group by AspNetUsers.UserName */

        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            using var context = new TodoContext();
        return context.Gorevler.Include(I => I.AppUser).Where(I => I.Durum).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I=>new DualHelper
            {
                Isim=I.Key,
                GorevSayisi=I.Count()
            }).ToList();

        }
        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(I => I.AppUser).Where(I => !I.Durum && I.AppUserId!=null).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Isim = I.Key,
                GorevSayisi = I.Count()
            }).ToList();

        }


    }
    // class ThreeModel
    //{
    //  public AppUser AppUser { get; set; }
    //public AppRole AppRole { get; set; }
    //}


}
    

