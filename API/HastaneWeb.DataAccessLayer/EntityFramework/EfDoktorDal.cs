﻿using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Repositories;
using HastaneWeb.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.DataAccessLayer.EntityFramework
{
    public class EfDoktorDal:GenericRepository<Doktor>,IDoktorDal
    {
        public EfDoktorDal(Context context): base (context) 
        {

        }
       
    }
}
