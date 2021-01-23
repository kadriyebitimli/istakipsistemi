using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.DTO.DTOs.BildirimDtos;
using Proje.ToDo.Business.Interfaces;
using Proje.ToDo.Entities.Concrete;
using Proje.Web.BaseControllers;
using Proje.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class BildirimController : BaseIdentityController
    {
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public BildirimController(IBildirimService bildirimService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
            _bildirimService = bildirimService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Bildirim;
            var user = await GetirGirisYapanKullanici();
     
            return View(_mapper.Map<List<BildirimListDto>>(_bildirimService.GetirOkunmayanlar(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
         var guncellenecekBildirim=  _bildirimService.GetirIdile(id);
            guncellenecekBildirim.Durum = true;
            _bildirimService.Guncelle(guncellenecekBildirim);
            return RedirectToAction("Index");
        }
    }
}
