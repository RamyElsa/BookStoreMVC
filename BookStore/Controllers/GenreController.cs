using BookStoreDataAccess.Repositories.Abstract;
using BookStoreModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
          if(!ModelState.IsValid)
            {
                return View(model);
            }
          var result = _unitOfWork.Genre.Add(model);
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
            var record = _unitOfWork.Genre.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _unitOfWork.Genre.Update(model);
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
            var result = _unitOfWork.Genre.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _unitOfWork.Genre.GetAll();
            return View(data);
        }
    }
}
