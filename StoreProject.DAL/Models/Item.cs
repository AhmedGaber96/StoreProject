using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.DAL.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of item is required")]
        public string Name { get; set; }
        public ICollection<StoreItem> StoreItems { get; set; } = new HashSet<StoreItem>();   
    }
}
