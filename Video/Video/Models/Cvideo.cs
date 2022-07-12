using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Video.Models
{
  public  class Cvideo
    {

        [PrimaryKey, AutoIncrement]
        public int cod { get; set; }

        [MaxLength(120)]
        public String nom { get; set; }

        [MaxLength(255)]
        public String descripcion { get; set; }

        public String pathVideo { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
