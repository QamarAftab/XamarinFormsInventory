using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Helper.Database
{
    public class Student
    {
        [PrimaryKey,AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
