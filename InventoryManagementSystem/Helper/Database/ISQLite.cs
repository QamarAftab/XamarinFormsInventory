using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Helper.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
