using Proje.DTO.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.DTO.DTOs.AppUserDtos
{
  public  class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public GorevListDto Gorev { get; set; }
    }
}
