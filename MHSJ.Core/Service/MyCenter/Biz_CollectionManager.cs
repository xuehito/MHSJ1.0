using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Entity;

namespace MHSJ.Core.Service.MyCenter
{
    public class Biz_CollectionManager
    {
        public static Biz_CollectionManager biz_collection=new Biz_CollectionManager();

        public bool IsCollection(int id, int accountId)
        {
            return Dac_CollectionManager.dac_collection.IsCollection(id,accountId);
        }

        public V_Post QueryCollectionPost()
        {
            //return Dac_CollectionManager.dac_collection.QueryCollectionPost(id, accountId);
            return null;
        }
    }
}
