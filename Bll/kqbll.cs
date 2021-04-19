using System;
using System.Collections.Generic;

namespace Bll
{
    public class kqbll
    {
        public List<kq> Show()
        {
            string sql = $"select * from kq";
            return DBHelper.GetList<kq>(sql);
        }
    }
    public class kq
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public int gh { get; set; }
        public DateTime ctime { get; set; }
        public DateTime ttime { get; set; }
        public string bz { get; set; }
        public string bm { get; set; }
    }
}
