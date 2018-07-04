namespace MHSJ.Data.MyCenter
{
    using MHSJ.Data.Common;
    using MHSJ.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class Dac_Collection
    {
        public static Dac_Collection dac_collection = new Dac_Collection();

        public bool CancelCollection(T_Collection collectionInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    EntityKey key = new EntityKey("MHSJEntities.T_Collection", "CollectionId", collectionInfo.CollectionId);
                    Dac_EntityHelper<MHSJEntities, T_Collection>.UpdateEntity(entities, collectionInfo, key, false);
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CollectionPost(T_Collection collectionInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_Collection>.Insert_IntoEntities(entities, collectionInfo, "T_Collection");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetAccountCollectionNumber(T_Collection item)
        {
            int num;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    num = (from c in entities.T_Collection
                        where (c.AccountId == item.AccountId) && (c.State == 1)
                        select c).ToList<T_Collection>().Count<T_Collection>();
                }
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

        public bool IsCollection(int postId, int accountId)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    if ((from c in entities.T_Collection
                        where ((c.PostId == postId) && (c.AccountId == accountId)) && (c.State == 1)
                        select c).Count<T_Collection>() <= 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }

        public bool IsCollection(int postId, int accountId, int state)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Collection> source = from c in entities.T_Collection
                        where (c.PostId == postId) && (c.AccountId == accountId)
                        select c;
                    if (state != 0)
                    {
                        source = from c in source
                            where c.State == 0
                            select c;
                    }
                    if (source.Count<T_Collection>() <= 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }

        public List<V_Post> QueryCollectionPost(T_Collection item, int pageSize, int pageIndex, out int recordCount)
        {
            List<V_Post> list;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<V_Post> source = from c in entities.V_Post
                        where (c.AccountId == item.AccountId) && (c.clstate == 1)
                        select c;
                    recordCount = source.ToList<V_Post>().Count<V_Post>();
                    list = (from c in source
                        orderby c.CreateDate descending
                        select c).Skip<V_Post>((pageSize * (pageIndex - 1))).Take<V_Post>(pageSize).ToList<V_Post>();
                }
            }
            catch (Exception)
            {
                recordCount = 0;
                list = null;
            }
            return list;
        }

        public int QueryId(int postId, int accountId)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Collection> source = from c in entities.T_Collection
                        where (c.PostId == postId) && (c.AccountId == accountId)
                        select c;
                    if (source.Count<T_Collection>() >= 0)
                    {
                        T_Collection t_s = source.FirstOrDefault<T_Collection>();
                        if (t_s != null)
                        {
                            return t_s.CollectionId;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }
    }
}

