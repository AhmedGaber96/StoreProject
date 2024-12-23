using Microsoft.AspNetCore.Mvc;
using StoreProject.BLL.Interface;
using StoreProject.DAL.Models;

namespace StoreProject.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public IActionResult Index()
        {
            var store  = _storeRepository.GetAll();
            return View(store);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Store store)
        {
           if (ModelState.IsValid)
            {
                _storeRepository.Add(store);
                return  RedirectToAction(nameof(Index));    
            }
            else
            {
                return View(store);  

            }
        }
        [HttpGet]
        public IActionResult Edit( int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            else
            {
                var store = _storeRepository.GetById(id.Value);
                if(store is null)
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
        public IActionResult Edit(Store store  ,[FromRoute] int id)
        {
            //if user edit id by inspect or add hidden id contain id
            if(id != store.Id)
            {
                return BadRequest();
            }
            if(ModelState.IsValid)
            {
              
               try
                {
                    _storeRepository.Update(store);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.Message);
                }
               
            }
         
                return View(store);
            
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
         
            _storeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
