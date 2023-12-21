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
    public class HastaneManager : IHastaneService
    {
        private readonly IHastaneDal _hastaneDal;

        public HastaneManager(IHastaneDal hastaneDal)
        {
            _hastaneDal = hastaneDal;
        }

        public void TDelete(Hastane t)
        {
            _hastaneDal.Delete(t);
        }

        public Hastane TGetByID(int id)
        {
            return _hastaneDal.GetByID(id);
        }

        public List<Hastane> TGetList()
        {
            return _hastaneDal.GetList();
        }

        public void TInsert(Hastane t)
        {
            _hastaneDal.Insert(t);
        }

        public void TUpdate(Hastane t)
        {
            _hastaneDal.Update(t);
        }
    }
}
