using SQLite;
using System;

namespace TestProj.Models
{
    public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }
        public int Expire_in { get; set; }
        public Token() { }
    }
}
