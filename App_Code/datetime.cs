using System;
using System.Collections.Generic;

namespace tourismAPi.App_Code
{
    public class datetime
    {
        public string sqldate(string dataname, string sqlstring)
        {
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>(); // "select convert(varchar,getdate(),111);"
            switch (dataname)
            {
                case "mssql":
                    return database.selectMsSql(database.connectionString(sqlstring), "select convert(varchar,getdate(),111);", dbparamlist).Rows[0][0].ToString().TrimEnd();
                case "postgresql":
                    return database.selectPostgreSql(database.connectionString(sqlstring), "select to_char(now(),'YYYY/MM/DD');", dbparamlist).Rows[0][0].ToString().TrimEnd();
                default:
                    return null;
            }
        }

        public string sqltime(string dataname, string sqlstring)
        {
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();  //"select convert(varchar,getdate(),108);"
            switch (dataname)
            {
                case "mssql":
                    return database.selectMsSql(database.connectionString(sqlstring), "select convert(varchar,getdate(),108);", dbparamlist).Rows[0][0].ToString().TrimEnd();
                case "postgresql":
                    return database.selectPostgreSql(database.connectionString(sqlstring), "select to_char(now(),'HH:MM:SS');", dbparamlist).Rows[0][0].ToString().TrimEnd();
                default:
                    return null;
            }
        }

        public int differentday(DateTime afterDate, DateTime beforeDate)
        {
            int ago = afterDate.Year - beforeDate.Year;
            if (beforeDate > afterDate.AddYears(-ago)) return ago;
            return ago;
        }

        public string differentime(string beforedate)
        {
            DateTime beforeDate = DateTime.Parse(beforedate), nowDate = DateTime.Now;
            TimeSpan ts = nowDate.Subtract(beforeDate);
            switch (ts.Days)
            {
                case 0:
                    switch (ts.Hours)
                    {
                        case 0:
                            switch (ts.Minutes)
                            {
                                case 0:
                                    return $"{ts.Seconds} Secs Before";
                            }
                            return $"{ts.Minutes} Mins Before";
                    }
                    return $"{ts.Hours} Hours Before";
            }
            return $"{ts.Days} Days Before";
        }
    }
}