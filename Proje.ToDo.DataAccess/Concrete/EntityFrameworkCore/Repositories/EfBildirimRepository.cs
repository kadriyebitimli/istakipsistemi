using Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Proje.ToDo.DataAccess.Interfaces;
using Proje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBildirimRepository : EfGenericRepository<Bildirim>, IBildirimDal
    {
        public List<Bildirim> GetirOkunmayanlar(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Bildirimler.Where(I => I.AppUserId == AppUserId && !I.Durum).ToList();
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            using var context = new TodoContext();
            return context.Bildirimler.Count(I => I.AppUserId == AppUserId && !I.Durum);

        }
    }
}
