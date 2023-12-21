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
    public class BirimManager : IBirimService
    {
        private readonly IBirimDal _birimDal;

        public BirimManager(IBirimDal birimDal)
        {
            _birimDal = birimDal;
        }

        public void TDelete(Birim t)
        {
            _birimDal.Delete(t);
        }

        public Birim TGetByID(int id)
        {
            return _birimDal.GetByID(id);
        }

        public List<Birim> TGetList()
        {
            return _birimDal.GetList();
        }

        public void TInsert(Birim t)
        {
            _birimDal.Insert(t);
        }

        public void TUpdate(Birim t)
        {
           _birimDal.Update(t);
        }
    }
}
