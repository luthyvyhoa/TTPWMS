using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class FileProcess
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(FileProcess));

        /// <summary>
        /// Insert table into DB by table Name
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="tableName">string</param>
        /// <returns>int</returns>
        public static int InsertFile(DataTable dt, string tableName)
        {
            using (var context = new SwireDBEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        using (var bulkInsert = new SqlBulkCopy(context.Database.Connection.ConnectionString))
                        {
                            bulkInsert.DestinationTableName = tableName;
                            bulkInsert.WriteToServer(dt);
                        }

                        dbContextTransaction.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("==> InsertFile is error, tableName=[{0}]", tableName);
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                        string content = $"==> Lỗi insert table : [{ tableName}]";
                        var innerEx = "";
                        if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                        var errorlog = new ErrorLogs() { ContentsError = content + "\n" + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = DataProcess<ErrorLogs>.GetLoginName(), CreatedTime = DateTime.Now };
                        DataProcess<ErrorLogs>.InsertErrorLog(errorlog);
                        dbContextTransaction.Rollback();
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// Load data by query clause to dataTable
        /// </summary>
        /// <param name="commandText">string</param>
        /// <returns>DataTable</returns>
        public static DataTable LoadTable(string commandText)
        {
            using (var context = new SwireDBEntities())
            {
                try
                {
                    using (var connection = context.Database.Connection)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = commandText;
                            connection.Open();
                            using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                            {
                                using (var tbResult = new DataTable())
                                {
                                    tbResult.Load(reader);
                                    return tbResult;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("==> LoadTable is error, CommandText=[{0}]", commandText);
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    string content = $"==> Lỗi thực thi truy vấn: [{ commandText}]";
                    var innerEx = "";
                    if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                    var errorlog = new ErrorLogs() { ContentsError = content + "\n" + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName = DataProcess<ErrorLogs>.GetLoginName(), CreatedTime = DateTime.Now };
                    DataProcess<ErrorLogs>.InsertErrorLog(errorlog);
                    return null;
                }
            }
        }

        public static DataTable LoadTableFromStoredProc(string commandText)
        {
            try
            {
                SqlConnection sConn = new SqlConnection("XXXXX");
                SqlCommand sCom = sConn.CreateCommand();
                sCom.CommandText = commandText;
                sConn.Open();
                using (var reader = sCom.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    using (var tbResult = new DataTable())
                    {
                        tbResult.Load(reader);
                        return tbResult;
                    }
                }


            }
            catch (Exception ex)
            {
                log.ErrorFormat("==> LoadTable is error, CommandText=[{0}]", commandText);
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                string content = $"==> Lỗi thực thi truy vấn: [{ commandText}]";
                var innerEx = "";
                if (ex.InnerException != null) innerEx = ex.InnerException.Message;
                var errorlog = new ErrorLogs() { ContentsError = content + "\n" + ex.Message, InnerException = innerEx, StackTrace = ex.StackTrace, UserName =DataProcess<ErrorLogs>.GetLoginName(), CreatedTime = DateTime.Now };
                DataProcess<ErrorLogs>.InsertErrorLog(errorlog);
                return null;
            }
        }
    }
}
