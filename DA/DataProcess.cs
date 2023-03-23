using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public class DataProcess<TEntity> where TEntity : class
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(DataProcess<TEntity>));

        /// <summary>
        /// Get current datetime in server
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            try
            {
                using (var context = new SwireDBEntities())
                {
                    return context.Database.SqlQuery<DateTime>("SELECT GetDate()").First();
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Get current date on server is error");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Get list entity
        /// </summary>
        /// <returns>List<TEntity></returns>
        public IEnumerable<TEntity> Select()
        {
            try
            {
                var context = new SwireDBEntities();
                return context.Set<TEntity>().AsNoTracking().ToList<TEntity>();
            }
            catch(System.ArgumentNullException argex)
            {
                log.ErrorFormat("==> Get all data [{0}] is error", typeof(TEntity).Name);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", argex.Message, argex.InnerException, argex.StackTrace);
                var innerEx = "Lỗi Select Entity ("+ typeof(TEntity).Name + ") :";
                if (argex.InnerException != null) innerEx = innerEx + argex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = argex.Message, InnerException = innerEx, StackTrace = argex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                InsertErrorLog(errorlog);
                return null;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("==> Get all data [{0}] is error", typeof(TEntity).Name);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                var innerEx = "Lỗi Select Entity (" + typeof(TEntity).Name + ") :";
                if (ex.InnerException != null) innerEx = innerEx + ex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                InsertErrorLog(errorlog);
                return null;
            }
        }

        /// <summary>
        /// Execute a procedure or a query by user definition
        /// </summary>
        /// <param name="procedureName">string</param>
        /// <param name="paramsValue">params</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<TEntity> Executing(string procedureName, params object[] paramsValue)
        {
            try
            {
                using (var context = new SwireDBEntities())
                {
                    return context.Database.SqlQuery<TEntity>(procedureName, paramsValue).ToList();
                }
            }
            catch (Exception ex)
            {
                string paramsList = string.Empty;
                log.ErrorFormat("==> Executing procedure or query string is error :", procedureName + "- " + ex.Message);
                log.ErrorFormat("==> Procedure or query string =[{0}], paramlist =[{1}]", procedureName, String.Join(paramsList, paramsValue));
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                string content = $"==> Lỗi thực thi SP: [{ procedureName}]";
                if (paramsValue != null)
                {
                    content += $"\n";
                    content += $"Các giá trị thực thi như sau :";
                    foreach (var item in paramsValue)
                    {
                        content += $"{item},";
                    }
                }
                var innerEx = "";
                if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = content + "\n" + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                InsertErrorLog(errorlog);
                return null;
            }
        }

        /// <summary>
        /// Get list entity by function and predicate
        /// </summary>
        /// <param name="predicate">Expression<Func<TEntity, bool>></param>
        /// <returns>List<TEntity></returns>
        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var context = new SwireDBEntities();
                List<TEntity> result = context.Set<TEntity>().AsNoTracking().Where(predicate).ToList<TEntity>();
                return result;
            }
            catch (System.ArgumentNullException argex)
            {
                log.ErrorFormat("==> Get all data [{0}] is error", typeof(TEntity).Name);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", argex.Message, argex.InnerException, argex.StackTrace);
                var innerEx = "Lỗi Select Entity (" + typeof(TEntity).Name + ") với điều kiện :";
                if (argex.InnerException != null) innerEx = innerEx + argex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = argex.Message, InnerException = innerEx, StackTrace = argex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                InsertErrorLog(errorlog);
                return null;
            }
            catch (Exception ex)
            {
                string paramsList = string.Empty;
                log.ErrorFormat("==> Get all data [{0}] by where is error", predicate.GetType().Name);
                log.ErrorFormat("==> Where clause =[{0}]", predicate.Body);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                var innerEx = "Lỗi Select Entity (" + typeof(TEntity).Name + ") với điều kiện :";
                if (ex.InnerException != null) innerEx = innerEx + ex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                InsertErrorLog(errorlog);
                return null;
            }
        }


        /// <summary>
        /// Update value for entity
        /// </summary>
        /// <param name="entitys">TEntity</param>
        /// <returns>int</returns>
        public int Update(params TEntity[] entitys)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var updateItem in entitys)
                        {
                            var update = context.Set<TEntity>().Add(updateItem);
                            context.Entry<TEntity>(updateItem).State = System.Data.Entity.EntityState.Modified;
                        }

                        int result = context.SaveChanges();
                        dbContextTransaction.Commit();

                        return result;
                    }
                    catch (DbUpdateConcurrencyException dbucex)
                    {
                        log.ErrorFormat("==> Update entity is error", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", dbucex.Message, dbucex.InnerException, dbucex.StackTrace);
                        string content = $" ==> Lỗi Update table [{entitys.GetType().Name}]\n";
                        var innerEx = "";
                        if (dbucex.InnerException != null) innerEx = dbucex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content+ dbucex.Message, InnerException = innerEx, StackTrace = dbucex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbevex)
                    {
                        log.ErrorFormat("==> Update entity is error", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", dbevex.Message, dbevex.InnerException, dbevex.StackTrace);
                        string innerContent = "";
                        string content = $" ==> Lỗi Update table [{entitys.GetType().Name}]\n";
                        if (dbevex.EntityValidationErrors != null)
                        {
                            foreach (DbEntityValidationResult item in dbevex.EntityValidationErrors)
                            {
                                innerContent += item.ValidationErrors.ElementAt(0).ErrorMessage + ";\n";
                            }
                        }
                        var errorlog = new ErrorLogs() { ContentsError = content+ dbevex.Message, InnerException = innerContent, StackTrace = dbevex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("==> Update entity is error", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        string content = $" ==> Lỗi Update table [{entitys.GetType().Name}]\n";
                        var innerEx = "";
                        if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content +ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Insert current entity into DB
        /// </summary>
        /// <param name="entitys">TEntity</param>
        /// <returns>int</returns>
        public int Insert(params TEntity[] entitys)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Set<TEntity>().AddRange(entitys);
                        int result = context.SaveChanges();
                        dbContextTransaction.Commit();
                        return result;
                    }
                    catch (DbEntityValidationException dbevex)
                    {
                        log.ErrorFormat("==> Insert entity is error", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", dbevex.Message, dbevex.InnerException, dbevex.StackTrace);
                        string innerContent = "";
                        string content = $" ==> Lỗi Insert table [{entitys.GetType().Name}]\n";
                        if (dbevex.EntityValidationErrors != null)
                        {
                            foreach (DbEntityValidationResult item in dbevex.EntityValidationErrors)
                            {
                                innerContent += item.ValidationErrors.ElementAt(0).ErrorMessage + ";\n";
                            }
                        }
                        var errorlog = new ErrorLogs() { ContentsError =content+ dbevex.Message, InnerException = innerContent, StackTrace = dbevex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("==> Insert entity is error", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        string content = $" ==> Lỗi Insert table [{entitys.GetType().Name}]\n";
                        var innerEx = "";
                        if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content +ex.Message, InnerException =innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Insert error log to Db
        /// </summary>
        /// <param name="errorLogs">ErrorLogs</param>
        /// <returns>int</returns>
        protected internal static int InsertErrorLog(ErrorLogs errorLogs)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Set<ErrorLogs>().Add(errorLogs);
                        int result = context.SaveChanges();
                        dbContextTransaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Delete current entity
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>int</returns>
        public int Delete(TEntity entitys)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {

                    try
                    {

                        context.Set<TEntity>().Attach(entitys);
                        context.Set<TEntity>().Remove(entitys);
                        int result = context.SaveChanges();
                        dbContextTransaction.Commit();
                        return result;

                    }
                    catch (DbEntityValidationException dbex)
                    {
                        log.ErrorFormat("==> Delete entity is error :", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", dbex.Message, dbex.InnerException, dbex.StackTrace);
                        string innerContent = "";
                        string content = $" ==> Lỗi Delete table [{entitys.GetType().Name}]\n";
                        if (dbex.EntityValidationErrors != null)
                        {
                            foreach (DbEntityValidationResult item in dbex.EntityValidationErrors)
                            {
                                innerContent += item.ValidationErrors.ElementAt(0).ErrorMessage + ";\n";
                            }
                        }
                        var errorlog = new ErrorLogs() { ContentsError = content+ dbex.Message, InnerException = innerContent, StackTrace = dbex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("==> Delete entity is error :", entitys.GetType().Name);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        string content = $" ==> Lỗi Delete table [{entitys.GetType().Name}]\n";
                        var innerEx = "";
                        if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Execute a procedure or query with query style is no query
        /// </summary>
        /// <param name="procedureName">string</param>
        /// <param name="list">params object[]</param>
        /// <returns>int</returns>
        public int ExecuteNoQuery(string procedureName, params object[] list)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int result = context.Database.ExecuteSqlCommand(procedureName, list);
                        dbContextTransaction.Commit();
                        return result;
                    }
                    catch (DbEntityValidationException dbex)
                    {
                        string paramsList = string.Empty;
                        log.ErrorFormat("==> ExecuteNoQuery entity is error :", dbex.Message);
                        log.ErrorFormat("==> Store procedureName or query string =[{0}], params list=[{1}]", procedureName, String.Join(paramsList, list));
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", dbex.Message, dbex.InnerException, dbex.StackTrace);
                        string innerContent = "";
                        string content = $"==> Lỗi thực thi SP: [{ procedureName}] ";
                        if (dbex.EntityValidationErrors != null)
                        {
                            foreach (DbEntityValidationResult item in dbex.EntityValidationErrors)
                            {
                                innerContent += item.ValidationErrors.ElementAt(0).ErrorMessage + ";\n";
                            }
                        }
                        var errorlog = new ErrorLogs() { ContentsError =content+ dbex.Message, InnerException = innerContent, StackTrace = dbex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                    catch (Exception ex)
                    {
                        string paramsList = string.Empty;
                        log.ErrorFormat("==> ExecuteNoQuery entity is error :", ex.Message);
                        log.ErrorFormat("==> Store procedureName or query string =[{0}], params list=[{1}]", procedureName, String.Join(paramsList, list));
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        string content = $"==> Lỗi thực thi SP: [{ procedureName}]";
                        if (list != null)
                        {
                            content += $"\n";
                            content += $"Các giá trị thực thi như sau :";
                            foreach (var item in list)
                            {
                                content += $"{item},";
                            }
                        }
                        var innerEx = "";
                        if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content + "\n" + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = GetLoginName(), CreatedTime = DateTime.Now };
                        InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -2;
                    }
                }
            }
        }

        /// <summary>
        /// Get login name
        /// </summary>
        /// <returns></returns>
        internal static string GetLoginName()
        {
            string contents = string.Empty;
            if (File.Exists(Application.StartupPath + "\\LoginName.txt"))
            {
                contents = File.ReadAllText(Application.StartupPath + "\\LoginName.txt");
            }
            return contents;
        }
    }
}
