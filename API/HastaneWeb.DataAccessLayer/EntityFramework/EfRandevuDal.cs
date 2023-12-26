using HastaneWeb.DataAccessLayer.Abstract;
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
    public class EfRandevuDal : GenericRepository<Randevu>, IRandevuDal
    {
        //public List<Randevu> GetRandevuWİthListWithDoktor()
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Custumers.Include(x => x.Job).ToList();
        //    }
        //}
        public EfRandevuDal(Context context) : base(context) { }

        public void RandevuStatusChange(Randevu status)
        {
            var context = new Context();
            var values = context.Randevular.Where(x => x.RandevuID == status.RandevuID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void RandevuStatusChange2(int id)
        {
            var context = new Context();
            var values = context.Randevular.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }
    }
}
