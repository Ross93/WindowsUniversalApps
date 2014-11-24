using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Parse;

namespace FindMyCar.Models
{
    [Table("CarLefts")]
    public class CarLeftModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(150)]
        public string Username { get; set; }

        [MaxLength(10)]
        public string CarNumber { get; set; }

        public double PlaceLat { get; set; }

        public double PlaceLong { get; set; }
    }
}
