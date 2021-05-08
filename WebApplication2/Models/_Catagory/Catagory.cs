using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models._Catagory.Sub_Catagory;

namespace WebApplication2.Models._Catagory
{
    public class Catagory
    {
        public Catagory()
        {
            SubCatagories = new List<SubCatagory>();
        }
        public int Id { get; set; }

        [Column("Catagory_Name")]
        public string catagoryName { get; set; }

        [Column("Chid_Catagory")]
        public List<SubCatagory> SubCatagories { get; set; }
    }
}
