﻿using HastaneWeb.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.BusinessLayer.Abstract
{
    public interface IRandevuService:IGenericService<Randevu>
    {
        List<Randevu> GetListRandevu(int id);
    }
}
