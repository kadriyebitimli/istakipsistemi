using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.DTO.DTOs.GorevDtos;
using Proje.ToDo.Business.Interfaces;
using Proje.ToDo.Entities.Concrete;
using Proje.Web.BaseControllers;
using Proje.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class GorevController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
      
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
         
            _gorevService = gorevService;
        }
        public async Task<IActionResult> Index(int aktifSayfa=1)
        {
            TempData["Active"] = TempdataInfo.Gorev;

            var user = await GetirGirisYapanKullanici();
            int toplamSayfa;

            var gorevler= _mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarlaTamamlanmayan(out toplamSayfa, user.Id, aktifSayfa));

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

           
            return View(gorevler);
        }
    }
}
