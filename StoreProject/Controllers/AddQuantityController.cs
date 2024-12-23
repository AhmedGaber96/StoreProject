using Microsoft.AspNetCore.Mvc;
using StoreProject.BLL.Interface;
using StoreProject.Models;

namespace StoreProject.Controllers
{
    public class AddQuantityController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IAddQuantity _addQuantity;

        public AddQuantityController(IItemRepository itemRepository, IStoreRepository storeRepository, IAddQuantity addQuantity)
        {
            _itemRepository = itemRepository;
            _storeRepository = storeRepository;
            _addQuantity = addQuantity;
        }

        public IActionResult Index()
        {
            var v = new AddFormModel
            {
                Items = _itemRepository.GetAll(),
                Store = _storeRepository.GetAll()

            };

            return View(v);
        }
        public JsonResult GetQuantity(int storeId, int itemId)
        {
            var quantity = _addQuantity.GetQuantity(storeId, itemId);
            return Json(new { quantity });
        }
        [HttpPost]
        public IActionResult AddStoreItem(int storeId, int itemId, int quantity)
        {
            if (quantity <= 0)
            {
                return Json(new { success = false, error = "You can't add a negative number or zero as quantity." });
            }
            _addQuantity.AddStoreItem(storeId, itemId, quantity); 
            return Json(new { success = true });


        }
    }
}
