using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models._Catagory.Sub_Catagory
{
    public class SubCatagory
    {
        public int Id { get; set; }

        [Column("Child_Catagory_Name")]
        public string SubCatgoriesName { get; set; }
    }
}
