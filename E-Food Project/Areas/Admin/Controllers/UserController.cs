using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> ActiveInactive([FromBody] string id)
        {
            var users = await _workUnit.User.getFirst(u => u.Id == id);
            if (users == null)
            {
                return Json(new { success = false, message = "Error de Usuario" });

            }
            if (users.LockoutEnd != null && users.LockoutEnd > DateTime.Now)
            {
                //Usuario Bloqueado
                users.LockoutEnd = DateTime.Now;
            }
            else
            {
                users.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            await _workUnit.Save();
            return Json(new { success = true, message = "Operacion Exitosa" });

        }

        #endregion
    }
}
