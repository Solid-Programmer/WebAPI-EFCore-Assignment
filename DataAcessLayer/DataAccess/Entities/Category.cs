using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAcessLayer.DataAccess.Entities
{
    [Table("Categories", Schema = "dbo")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
    }
}
