using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.BusinessLayer.Concrete
{
    public class HizmetManager : IHizmetService
    {
        private readonly IHizmetDal _hizmetDal;

        public HizmetManager(IHizmetDal hizmetDal)
        {
            _hizmetDal = hizmetDal;
        }

        public void TDelete(Hizmet t)
        {
            _hizmetDal.Delete(t);
        }

        public Hizmet TGetByID(int id)
        {
            return _hizmetDal.GetByID(id);
        }

        public List<Hizmet> TGetList()
        {
           return _hizmetDal.GetList();
        }

        public void TInsert(Hizmet t)
        {
            _hizmetDal.Insert(t);
        }

        public void TUpdate(Hizmet t)
        {
            _hizmetDal.Update(t);
        }
    }
}
