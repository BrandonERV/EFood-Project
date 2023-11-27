using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using EFood.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin + "," + DS.Role_Advisory) ]
    public class OrderController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public OrderController(IWorkUnit unidadTrabajo)
        {
            _workUnit = unidadTrabajo;
        }


        public IActionResult Index()
        {
            return View();
        }


        #region API

        [HttpGet]
        public async Task<IActionResult> getAll() 
        { 
            var all = await _workUnit.Order.getAll();
            return Json(new { data = all });
        }

       
        #endregion


    }
}
