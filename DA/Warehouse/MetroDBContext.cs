using System;
using System.Data;
using System.Data.Entity;

namespace DA.Warehouse
{
    public class MetroDBContext : DbContext
    {
        /// <summary>
        /// Get all data in store No
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public DataTable GetComboStoreNo(string commandText)
        {
            using (var context = new MetroDBContext())
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
                    return null;
                }
            }
        }
    }
}
