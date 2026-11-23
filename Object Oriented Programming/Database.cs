using System.Data;
using Microsoft.Data.SqlClient; // Install NuGet package: Microsoft.Data.SqlClient

namespace Object_Oriented_Programming
{
    public static class DatabaseInitializer
    {
        // Use @"(localdb)\MSSQLLocalDB" for LocalDB, or @"localhost\SQLEXPRESS" / @"." for SQL Server
        private const string ServerName = @"(localdb)\MSSQLLocalDB";
        private const string DatabaseName = "db_OOP1";
        private const string TableName = "tbl_logInfos";

        private static string MasterConnectionString =>
            $"Server={ServerName};Database=master;Integrated Security=True;TrustServerCertificate=True;";

        public static string AppDbConnectionString =>
            $"Server={ServerName};Database={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";

        public static void EnsureDatabaseReady()
        {
            CreateDatabaseIfMissing();
            CreateLoginTableIfMissing();
        }

        private static void CreateDatabaseIfMissing()
        {
            using var connection = new SqlConnection(MasterConnectionString);
            connection.Open();

            string createDatabaseSql = $"""
                IF DB_ID(N'{DatabaseName}') IS NULL
                BEGIN
                    CREATE DATABASE [{DatabaseName}];
                END
                """;

            using var command = new SqlCommand(createDatabaseSql, connection);
            command.ExecuteNonQuery();
        }

        private static void CreateLoginTableIfMissing()
        {
            using var connection = new SqlConnection(AppDbConnectionString);
            connection.Open();

            string createTableSql = $"""
                IF OBJECT_ID(N'[dbo].[{TableName}]', N'U') IS NULL
                BEGIN
                    CREATE TABLE [dbo].[{TableName}]
                    (
                        [id_login]      INT           IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [user_name]     VARCHAR(150)  NOT NULL,
                        [pass_word]     VARCHAR(150)  NOT NULL,
                        [contact_no]    VARCHAR(150)  NOT NULL,
                        [email_address] VARCHAR(150)  NOT NULL,
                        [is_active]     BIT           NOT NULL
                    );
                END
                """;

            using var command = new SqlCommand(createTableSql, connection);
            command.ExecuteNonQuery();
        }

        public static int InsertUser(string username, string password, string contactNo, string email, bool isActive = true)
        {
            EnsureDatabaseReady();

            using var connection = new SqlConnection(AppDbConnectionString);
            connection.Open();

            string insertSql = $"""
                INSERT INTO [dbo].[{TableName}]
                    ([user_name], [pass_word], [contact_no], [email_address], [is_active])
                VALUES
                    (@user_name, @pass_word, @contact_no, @email_address, @is_active);
                """;

            using var command = new SqlCommand(insertSql, connection);
            command.Parameters.Add("@user_name", SqlDbType.VarChar, 150).Value = username;
            command.Parameters.Add("@pass_word", SqlDbType.VarChar, 150).Value = password;
            command.Parameters.Add("@contact_no", SqlDbType.VarChar, 150).Value = contactNo;
            command.Parameters.Add("@email_address", SqlDbType.VarChar, 150).Value = email;
            command.Parameters.Add("@is_active", SqlDbType.Bit).Value = isActive;

            return command.ExecuteNonQuery();
        }
    }
}