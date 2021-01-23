using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.ToDo.Business.Interfaces
{
   public  interface IDosyaService
    {
        /// <summary>
    /// geriye üretmiş ve upload etmiş oldugu pdf dosyasının virtual pathini döner.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
        string AktarPdf<T>(List<T> list) where T:class,new();
        /// <summary>
        /// geriye excel verisini byte dizisi olarak döner. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] AktarExcel<T>(List<T> list) where T : class, new();
    }
}
