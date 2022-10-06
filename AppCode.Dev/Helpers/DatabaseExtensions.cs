using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppCode.Dev.Helpers
{
    public static class DatabaseExtensions
    {

        public static bool Exists(this DatabaseFacade db)
        {
            return (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.Exists();
        }
        
        public static void ResetDb(this DbContext dbContext, bool useMigrations = false)
        {
            if (useMigrations) dbContext.Database.Migrate();
            else
            {
                // This is primarily for cloud dbs so that we don't delete the whole database but instead clear it if it exists
                if (dbContext.Database.Exists())
                {
                    dbContext.Database.ExecuteSqlRaw(@"
                    DECLARE @sql NVARCHAR(2000)

                    WHILE(EXISTS(SELECT 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE='FOREIGN KEY'))
                        BEGIN
                            SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME + '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                            WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'
                            EXEC(@sql)
                            PRINT @sql
                        END

                    WHILE(EXISTS(SELECT * from INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME NOT LIKE '%database_firewall_rules'))
                        BEGIN
                            SELECT TOP 1 @sql=('DROP TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME + ']')
                            FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME NOT LIKE '%database_firewall_rules'
                            EXEC(@sql)
                            PRINT @sql
                        END
                ");
                }
                
                dbContext.Database.EnsureCreated();
            }
        }
    }
}