using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHSJ.Data.MyCenter;
using MHSJ.Entity;

namespace MHSJ.Core.Service.MyCenter
{
    public class Biz_CollectionManager
    {
        public static Biz_CollectionManager biz_collection=new Biz_CollectionManager();

        public bool CancelCollection(T_Collection collectionInfo)
        {
            return Dac_Collection.dac_collection.CancelCollection(collectionInfo);
        }

        public bool CollectionPost(T_Collection collectionInfo)
        {
            return Dac_Collection.dac_collection.CollectionPost(collectionInfo);
        }

        public int GetAccountCollectionNumber(T_Collection collectionInfo)
        {
            return Dac_Collection.dac_collection.GetAccountCollectionNumber(collectionInfo);
        }

        public bool IsCollection(int post, int accountId)
        {
            return Dac_Collection.dac_collection.IsCollection(post, accountId);
        }

        public bool IsCollection(int post, int accountId, int state)
        {
            return Dac_Collection.dac_collection.IsCollection(post, accountId, state);
        }

        public List<V_Post> QueryCollectionPost(T_Collection collectionInfo, int pageSize, int pageIndex, out int recordCount)
        {
            return Dac_Collection.dac_collection.QueryCollectionPost(collectionInfo, pageSize, pageIndex, out recordCount);
        }

        public int QueryId(int post, int accountId)
        {
            return Dac_Collection.dac_collection.QueryId(post, accountId);
        }
    }
}
