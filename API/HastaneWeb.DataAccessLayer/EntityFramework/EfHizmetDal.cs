using HastaneWeb.DataAccessLayer.Repositories;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.DataAccessLayer.EntityFramework
{
    public class EfHizmetDal:GenericRepository<Hizmet>,IHizmetDal
    {
        public EfHizmetDal(Context context) : base(context) { }

    }
}
