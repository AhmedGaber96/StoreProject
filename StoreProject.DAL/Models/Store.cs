using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.DAL.Models
{
    public class Store
    {
        public int Id { get; set; } //PK

        [Required(ErrorMessage = "Name of store is required")]
        public string Name { get; set; }

        public ICollection<StoreItem> StoreItems { get; set; } = new HashSet<StoreItem>();   
    }
}
