using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.BusinessLayer.Concrete
{
    public class RandevuManager : IRandevuService
    {
        private readonly IRandevuDal _randevuDal;

        public RandevuManager(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
        }

        public List<Randevu> GetListRandevu(int id)
        {
        
            return _randevuDal.GetListByFilter(x => x.AppUserId == id);

        }

        //public List<Randevu> GetByFilter(Expression<Func<Randevu, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public void TDelete(Randevu t)
        {
            _randevuDal.Delete(t);
        }

        public Randevu TGetByID(int id)
        {
           return _randevuDal.GetByID(id);
        }

        public List<Randevu> TGetList()
        {
           return _randevuDal.GetList();
        }

        public void TInsert(Randevu t)
        {
            _randevuDal.Insert(t);
        }



        public void TUpdate(Randevu t)
        {
            _randevuDal.Update(t);
        }
    }
}
