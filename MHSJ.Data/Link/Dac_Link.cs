using System.Data.Objects;

namespace MHSJ.Data.Link
{
    using MHSJ.Data.Common;
    using MHSJ.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class Dac_Link
    {
        public static Dac_Link dac_link = new Dac_Link();

        public bool DeleteLink(int id)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    T_Links entityObject = entities.T_Links.SingleOrDefault<T_Links>(c => c.Id == id);
                    Dac_EntityHelper<MHSJEntities, T_Links>.DeleteEntity(entities, entityObject);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T_Links GetSingleLink(int id)
        {
            T_Links links;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    links = entities.T_Links.SingleOrDefault<T_Links>(c => c.Id == id);
                }
            }
            catch (Exception)
            {
                links = null;
            }
            return links;
        }

        public bool InsertLink(T_Links wordInfo)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    Dac_EntityHelper<MHSJEntities, T_Links>.Insert_IntoEntities(entities, wordInfo, "T_Links");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T_Links> QueryList()
        {
            List<T_Links> list;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    list = (from c in entities.T_Links.Where("1 = 1", new ObjectParameter[0])
                        orderby c.DisplayOrder
                        select c).ToList<T_Links>();
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }

        public List<T_Links> QueryList(T_Links item, int pageSize, int pageIndex, out int recordCount)
        {
            List<T_Links> list;
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    IQueryable<T_Links> source = entities.T_Links.Where("1 = 1", new ObjectParameter[0]);
                    recordCount = source.ToList<T_Links>().Count<T_Links>();
                    list = (from c in source
                        orderby c.DisplayOrder
                        select c).Skip<T_Links>((pageSize * (pageIndex - 1))).Take<T_Links>(pageSize).ToList<T_Links>();
                }
            }
            catch (Exception)
            {
                recordCount = 0;
                list = null;
            }
            return list;
        }

        public bool UpdateLink(T_Links info)
        {
            try
            {
                using (MHSJEntities entities = Dac_Common.dac_Common.MHSJEntities())
                {
                    EntityKey key = new EntityKey("MHSJEntities.T_Links", "Id", info.Id);
                    Dac_EntityHelper<MHSJEntities, T_Links>.UpdateEntity(entities, info, key, false);
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

