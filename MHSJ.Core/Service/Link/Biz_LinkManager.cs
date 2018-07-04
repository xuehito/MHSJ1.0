using System.Collections.Generic;
using MHSJ.Data.Link;
using MHSJ.Entity;

namespace MHSJ.Core.Service.Link
{
    public class Biz_LinkManager
    {
        public static Biz_LinkManager biz_link = new Biz_LinkManager();

        public bool DeleteLink(int id)
        {
            return Dac_Link.dac_link.DeleteLink(id);
        }

        public T_Links GetSingleLink(int id)
        {
            return Dac_Link.dac_link.GetSingleLink(id);
        }

        public bool InsertLink(T_Links info)
        {
            return Dac_Link.dac_link.InsertLink(info);
        }

        public List<T_Links> QueryList()
        {
            return Dac_Link.dac_link.QueryList();
        }

        public List<T_Links> QueryList(T_Links item, int pageSize, int pageIndex, out int recordCount)
        {
            return Dac_Link.dac_link.QueryList(item, pageSize, pageIndex, out recordCount);
        }

        public bool UpdateLink(T_Links info)
        {
            return Dac_Link.dac_link.UpdateLink(info);
        }
    }
}
