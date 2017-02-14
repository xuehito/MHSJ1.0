using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MHSJ.Data.Common
{
    #region 公共类 EntityHelper
    /// <summary>
    /// 公共类 EntityHelper 
    /// Create by Jeff
    /// 2011-06-08
    /// </summary>
    /// <typeparam name="O">操作对象的上下文类型</typeparam>
    /// <typeparam name="T">操作实体类型</typeparam>
    public class Dac_EntityHelper<O, T>
        where O : System.Data.Objects.ObjectContext
        where T : System.Data.Objects.DataClasses.EntityObject
    {
        #region  public static bool Insert_IntoEntities(O objectContext, T entityObject,string entitySetName)
        /// <summary>
        /// 向指定实体集合插入单条记录
        /// </summary>
        /// <param name="objectContext">实体集的上下文</param>
        /// <param name="entityObject">待插入实体</param>
        /// <param name="entitySetName">实体集合名称</param>
        /// <returns>true:插入成功;false:插入失败</returns>
        public static bool Insert_IntoEntities(O objectContext, T entityObject, string entitySetName)
        {
            try
            {
                objectContext.AddObject(entitySetName, entityObject);
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }

        }

        #endregion

        #region  public static bool Insert_IntoEntities(O objectContext, List<StructEntity<System.Data.Objects.DataClasses.EntityObject>> StructList)
        ///// <summary>
        ///// 批量插入记录
        ///// </summary>
        ///// <param name="objectContext">实体集所在上下文</param>
        ///// <param name="StructList">实体描述链表</param>
        ///// <returns>true:插入成功;false:插入失败</returns>
        //public static bool Insert_IntoEntities(O objectContext, List<StructEntity<System.Data.Objects.DataClasses.EntityObject>> StructList)
        //{
        //    try
        //    {
        //        foreach (StructEntity<System.Data.Objects.DataClasses.EntityObject> structDescription in StructList)
        //        {
        //            objectContext.AddObject(structDescription.EntitySetName, structDescription.Entity);
        //        }
        //        objectContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        throw (ex);
        //        //return false;
        //    }

        //}

        #endregion

        #region public static bool DeleteEntity(O objectContext, T entityObject)
        /// <summary>
        /// 删除一个实体记录
        /// </summary>
        /// <param name="objectContext">实体集的上下文</param>
        /// <param name="entityObject">待删除实体</param>
        /// <returns>true:删除完成; false:删除失败</returns>
        public static bool DeleteEntity(O objectContext, T entityObject)
        {

            try
            {
                objectContext.DeleteObject(entityObject);
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region public static List<T> GetEntitiesWithEntitySql(O objectContext,string commandText,SqlParameter[] paras)
        /// <summary>
        ///  根据EntitySQL 返回查询结果
        /// </summary>
        /// <param name="objectContext">实体集合的上下文</param>
        /// <param name="commandText">EntitySql</param>
        /// <param name="paras">参数数组</param>
        /// <returns>泛型T的List 集合</returns>
        public static List<T> GetEntitiesWithEntitySql(O objectContext, string commandText, SqlParameter[] paras)
        {
            try
            {
                List<T> TQuery = objectContext.ExecuteStoreQuery<T>(commandText, paras).ToList<T>();
                return TQuery;
            }
            catch (Exception ex)
            {
                //不捕获异常 靳龙 2012/11/8
                throw ex;
            }
        }
        #endregion

        #region  public static bool ChangeEntitiesWithSql(O objectContext, string commandText, SqlParameter[] paras)
        /// <summary>
        /// 根据SQL修改实体
        /// </summary>
        /// <param name="objectContext">实体的上下文</param>
        /// <param name="commandText">SQL命令</param>
        /// <param name="paras">参数数组</param>
        /// <returns>true:修改完成; false:修改失败</returns>
        public static bool ChangeEntitiesWithSql(O objectContext, string commandText, SqlParameter[] paras)
        {
            try
            {
                objectContext.ExecuteStoreCommand(commandText, paras);
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region public static T GetEntities(O objectContext, EntityKey key)
        /// <summary>
        ///  根据自定义键值查询实体
        /// </summary>
        /// <param name="objectContext">实体的上下文</param>
        /// <param name="key">自定义键值</param>
        /// <returns>类型T 的实体</returns>
        public static T GetEntities(O objectContext, EntityKey key)
        {
            try
            {
                object obj;
                bool IsContains = objectContext.TryGetObjectByKey(key, out obj);
                if (IsContains == true)
                {
                    T entity = (T)obj;
                    return entity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }

        }
        #endregion

        #region public static bool UpdateEntity(O objectContext, T entityObject, EntityKey key, bool IsNull)
        /// <summary>
        /// 根据自定义键值更新实体中的所有字段
        /// </summary>
        /// <param name="objectContext">实体集合所在的上下文</param>
        /// <param name="entityObject">待更新实体</param>
        /// <param name="key">待更新的实体自定义键值</param>
        /// <param name="IsNull">true:更新实体中所有字段;false:更新实体中非空字段</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        public static bool UpdateEntity(O objectContext, T entityObject, EntityKey key, bool IsNull)
        {
            try
            {
                object entity = objectContext.GetObjectByKey(key);
                PropertyInfo[] Properties = entity.GetType().GetProperties();
                foreach (PropertyInfo property in Properties)
                {
                    if (property.CanWrite)
                    {
                        if (Convert.ToString((property.GetValue(entity, null))) != Convert.ToString((property.GetValue(entityObject, null))))
                        {
                            if (property.GetValue(entityObject, null) == null)
                            {
                                if (IsNull)
                                {
                                    property.SetValue(entity, property.GetValue(entityObject, null), null);
                                }
                            }
                            else
                            {
                                property.SetValue(entity, property.GetValue(entityObject, null), null);
                            }
                        }
                    }
                }
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region public static bool UpdateEntity(O objectContext, T entityObject, bool IsNull)
        /// <summary>
        ///  更新实体
        /// </summary>
        /// <param name="objectContext">实体所在上下文集合</param>
        /// <param name="entityObject">待更新实体</param>
        /// <param name="IsNull">是否更新空值字段</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        public static bool UpdateEntity(O objectContext, T entityObject, bool IsNull)
        {
            try
            {
                objectContext.Attach(entityObject);
                ObjectStateEntry stateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(entityObject);
                PropertyInfo[] Properties = entityObject.GetType().GetProperties();
                foreach (PropertyInfo property in Properties)
                {
                    if (property.CanWrite)
                    {
                        if (property.GetValue(entityObject, null) == null)
                        {
                            if (IsNull)
                            {
                                stateEntry.SetModifiedProperty(property.Name);
                            }
                        }
                        else
                        {
                            stateEntry.SetModifiedProperty(property.Name);
                        }

                    }
                }
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region  public static bool UpdateEntity(O objectContext, T entityObject, EntityKey key, bool IsNull, string nullProperty)
        /// <summary>
        /// 根据自定义键值更新实体中的所有字段
        /// </summary>
        /// <param name="objectContext">实体集合所在的上下文</param>
        /// <param name="entityObject">待更新实体</param>
        /// <param name="key">待更新的实体自定义键值</param>
        /// <param name="IsNull">true:更新实体中所有字段;false:更新实体中非空字段</param>
        /// <param name="nullProperty">若不更新空字段,例外的属性名称,用","分割</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        public static bool UpdateEntity(O objectContext, T entityObject, EntityKey key, bool IsNull, string nullProperty)
        {
            try
            {
                object entity = objectContext.GetObjectByKey(key);
                PropertyInfo[] Properties = entity.GetType().GetProperties();
                foreach (PropertyInfo property in Properties)
                {
                    if (property.CanWrite)
                    {
                        if (Convert.ToString((property.GetValue(entity, null))) != Convert.ToString((property.GetValue(entityObject, null))))
                        {
                            if (property.GetValue(entityObject, null) == null)
                            {
                                if (IsNull || nullProperty.Contains(property.Name))
                                {
                                    property.SetValue(entity, property.GetValue(entityObject, null), null);
                                }
                            }
                            else
                            {
                                property.SetValue(entity, property.GetValue(entityObject, null), null);
                            }
                        }
                    }
                }
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region public static bool UpdateEntity(O objectContext, T entityObject, bool IsNull, string nullProperty)
        /// <summary>
        ///  更新实体
        /// </summary>
        /// <param name="objectContext">实体所在上下文集合</param>
        /// <param name="entityObject">待更新实体</param>
        /// <param name="IsNull">是否更新空值字段</param>
        /// <param name="nullProperty">若不更新空字段,例外的属性名称,用","分割</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        public static bool UpdateEntity(O objectContext, T entityObject, bool IsNull, string nullProperty)
        {
            try
            {
                objectContext.Attach(entityObject);
                ObjectStateEntry stateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(entityObject);
                PropertyInfo[] Properties = entityObject.GetType().GetProperties();
                foreach (PropertyInfo property in Properties)
                {
                    if (property.CanWrite)
                    {
                        if (property.GetValue(entityObject, null) == null)
                        {
                            if (IsNull || nullProperty.Contains(property.Name))
                            {
                                stateEntry.SetModifiedProperty(property.Name);
                            }
                        }
                        else
                        {
                            stateEntry.SetModifiedProperty(property.Name);
                        }

                    }
                }
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

        #region public static bool UpdateEntities(O objectContext, List<StructEntity<System.Data.Objects.DataClasses.EntityObject>> StructList, bool IsNull)
        /// <summary>
        /// 根据自定义键值批量更新实体中的所有字段
        /// </summary>
        /// <param name="objectContext">实体集合所在的上下文</param>
        /// <param name="StructList">待更新实体描述链表</param>
        /// <param name="IsNull">true:更新实体中所有字段;false:更新实体中非空字段</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        //public static bool UpdateEntities(O objectContext, List<StructEntity<System.Data.Objects.DataClasses.EntityObject>> StructList, bool IsNull)
        //{
        //    try
        //    {
        //        foreach (StructEntity<System.Data.Objects.DataClasses.EntityObject> structDescription in StructList)
        //        {
        //            object entity = objectContext.GetObjectByKey(structDescription.Key);
        //            PropertyInfo[] Properties = entity.GetType().GetProperties();
        //            foreach (PropertyInfo property in Properties)
        //            {
        //                if (property.CanWrite)
        //                {
        //                    if (Convert.ToString((property.GetValue(entity, null))) != Convert.ToString((property.GetValue(structDescription.Entity, null))))
        //                    {
        //                        if (property.GetValue(structDescription.Entity, null) == null)
        //                        {
        //                            if (IsNull)
        //                            {
        //                                property.SetValue(entity, property.GetValue(structDescription.Entity, null), null);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            property.SetValue(entity, property.GetValue(structDescription.Entity, null), null);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        objectContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        return false;
        //    }
        //}
        #endregion

        #region public static bool UpdateEntities(O objectContext, List<System.Data.Objects.DataClasses.EntityObject> EntityList, bool IsNull)
        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="objectContext">实体所在上下文集合</param>
        /// <param name="EntityList">待更新实体描述</param>
        /// <param name="IsNull">是否更新空值字段</param>
        /// <returns>true:更新成功;false:更新失败</returns>
        public static bool UpdateEntities(O objectContext, List<System.Data.Objects.DataClasses.EntityObject> EntityList, bool IsNull)
        {
            try
            {
                foreach (System.Data.Objects.DataClasses.EntityObject entityObject in EntityList)
                {
                    objectContext.Attach(entityObject);
                    ObjectStateEntry stateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(entityObject);
                    PropertyInfo[] Properties = entityObject.GetType().GetProperties();
                    foreach (PropertyInfo property in Properties)
                    {
                        if (property.CanWrite)
                        {
                            if (property.GetValue(entityObject, null) == null)
                            {
                                if (IsNull)
                                {
                                    stateEntry.SetModifiedProperty(property.Name);
                                }
                            }
                            else
                            {
                                stateEntry.SetModifiedProperty(property.Name);
                            }

                        }
                    }
                }
                objectContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
        #endregion

    }
    #endregion
}
