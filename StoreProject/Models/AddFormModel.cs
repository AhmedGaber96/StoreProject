using StoreProject.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Models
{
    public class AddFormModel
    {
        [Display(Name ="Item")]
        public int ItemId { get; set; }
        public IEnumerable<Item>? Items { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public IEnumerable<Store>? Store { get; set; }

     
        public int Quantity { get; set; }
    }
}
