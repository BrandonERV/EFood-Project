using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Food_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IWorkUnit _workUnit;
        private readonly ApplicationDbContext _db;

        public UserController(IWorkUnit workUnit, ApplicationDbContext db)
        {
            _workUnit = workUnit;
            _db = db;
        }



        public IActionResult Index()
        {
            return View();
        }

        #region API

        public async Task<IActionResult> getAll()
        {
            var userList = await _workUnit.User.getAll();
            var userRole = await _db.UserRoles.ToListAsync();
            var roles = await _db.Roles.ToListAsync();

            foreach (var user in userList) 
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return Json(new { data = userList });
        }

        #endregion
    }
}
