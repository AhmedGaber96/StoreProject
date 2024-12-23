using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreProject.BLL.Interface;
using StoreProject.BLL.Repository;
using StoreProject.DAL.Models;
using StoreProject.Models;

namespace StoreProject.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
          
            var item = _itemRepository.GetAll();
       
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.Add(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(item);

            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            else
            {
                var store = _itemRepository.GetById(id.Value);
                if (store is null)
                {

                    return NotFound();
                }
                else
                {
                    return View(store);
                }
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]//if user try access by postman
        public IActionResult Edit(Item item, [FromRoute] int id)
        {
            //if user edit id by inspect or add hidden id contain id
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _itemRepository.Update(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.Message);
                }

            }

            return View(item);

        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {

            _itemRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
  

    }
}
