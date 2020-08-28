using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;


namespace MineSweeper
{
    [Table(Name = "Scores")]
    public class Score
    {
        [Column(Name = "PayerID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int PlayerID { get; set; }
        [Column(Name = "Name", DbType = "TEXT")]
        public String Name { get; set; }
        [Column(Name = "Result" , DbType = "INTEGER")]
        public int Result { get; set; }
        [Column(Name = "Difficulty", DbType = "TEXT")]
        public String Difficulty { get; set; }
    }
}