using BookStoreDataAccess.Repositories.Abstract;
using BookStoreModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _unitOfWork.Author.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            _unitOfWork.Save();
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = _unitOfWork.Author.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _unitOfWork.Author.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            _unitOfWork.Save();
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            var result = _unitOfWork.Author.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {

            var data = _unitOfWork.Author.GetAll();
            return View(data);
        }
    }
}
