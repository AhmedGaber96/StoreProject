using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.DAL.Models
{
    public class StoreItem
    {
 
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ItemId { get; set; } 
        public Item Item { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; } 
    }
}
