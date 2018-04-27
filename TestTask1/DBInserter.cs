using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask1
{


    public delegate void setText(string str);
    public delegate void setProgressValue(int am);
    /// <summary>
    /// Class for background process to work with db
    /// </summary
    class DBInserter
    {
        public static Thread thred;
        public string connectionString = "Data Source=NASTYUHA;Initial Catalog=TestDB;Integrated Security=True";
        public DBInserter()
        {
            thred = new Thread(Insert);
            thred.IsBackground = true;
            //Connection to create a table and procedures
            SqlConnection thisConnection = new SqlConnection(connectionString);
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();
            try
            {
                //Creating
                thisConnection.Open();
                nonqueryCommand.CommandText = "DROP Table IF EXISTS FileLine";

                nonqueryCommand.ExecuteNonQuery();
                nonqueryCommand.CommandText = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'RX_CMMData' AND TABLE_NAME = 'FileLine') BEGIN CREATE TABLE [dbo].[FileLine] ([Id] INT IDENTITY(1, 1) NOT NULL, " +
                    "[Date] DATE NULL,[EngSymb] NCHAR(10) NULL,[RusSymb] NCHAR(10) NULL, [IntNum] INT NULL,[DoubleNum] FLOAT(53) NULL, PRIMARY KEY CLUSTERED([Id] ASC)); END";

                nonqueryCommand.ExecuteNonQuery();

                nonqueryCommand.CommandText = "IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountMedian]') AND type in (N'P', N'PC')) BEGIN " +
                    "EXEC('CREATE PROCEDURE [dbo].[CountMedian] AS SELECT MAX(d.DoubleNum) AS DoubleMedian FROM (SELECT TOP 50 PERCENT DoubleNum FROM FileLine ORDER BY DoubleNum) d; ')END ";
                nonqueryCommand.ExecuteNonQuery();
                nonqueryCommand.CommandText = "IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountSum]') AND type in (N'P', N'PC')) BEGIN " +
                    "EXEC('CREATE PROCEDURE [dbo].[CountSum] AS SELECT SUM(CAST(IntNum AS BIGINT)) AS SumOfInt FROM FileLine;')END";
                nonqueryCommand.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                thisConnection.Close();
            }
        }
        public static event setProgressValue SetProgressValueEvent;
        public static void SetProgress(int ammount)
        {
            if (SetProgressValueEvent != null)
                SetProgressValueEvent(ammount);
        }
        /// <summary>
        /// Inserting lines to database table
        /// </summary>
        public void Insert()
        {
            SqlConnection thisConnection = new SqlConnection(connectionString);
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();


            try
            {
                thisConnection.Open();

                nonqueryCommand.CommandText = "INSERT INTO FileLine VALUES (@date, @engsymb, @russymb, @intnum, @doublenum)";
                
                nonqueryCommand.Parameters.AddWithValue("@date", "1");
                nonqueryCommand.Parameters.AddWithValue("@engsymb", "2");
                nonqueryCommand.Parameters.AddWithValue("@russymb", "3");
                nonqueryCommand.Parameters.AddWithValue("@intnum", "4");
                nonqueryCommand.Parameters.AddWithValue("@doublenum", "5");

                int ammountOfLines = System.IO.File.ReadAllLines("all.txt").Length;
                int count = 0;
                SetProgress(ammountOfLines);
                using (StreamReader reader = File.OpenText("all.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] items = line.Split(new char[] { '|', '|' });
                        if (items.Length == 9)
                        {

                            nonqueryCommand.Parameters["@date"].Value = DateTime.Parse(items[0]);
                            nonqueryCommand.Parameters["@engsymb"].Value = items[2];
                            nonqueryCommand.Parameters["@russymb"].Value = items[4];
                            nonqueryCommand.Parameters["@intnum"].Value = Int32.Parse(items[6]);
                            nonqueryCommand.Parameters["@doublenum"].Value = Double.Parse(items[8]);
                            nonqueryCommand.ExecuteNonQuery();
                            count++;
                        }
                        Print(count,ammountOfLines-count);
                    }
                }
                
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            finally
            {
                thisConnection.Close();
            }
        }

        public void Run()
        {
            thred.Start();
        }
        public void Stop()
        {
            thred.Abort();
        }

        public bool isAlive()
        {
            if (thred.IsAlive)
                return true;
            else return false;
        }
        /// <summary>
        /// Send information about process to Form
        /// </summary>
        public static event setText SetTextEvent;
        public static void Print(int done, int left)
        {
            String text = "Inserted lines: " + done + " ; " + "Left lines: " + left + ". " ;
            if (left == 0) text = "Finished";
            if (SetTextEvent != null)
                SetTextEvent(text);
        }
    }
}
