// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using EFood.DataAccess.Repository;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace E_Food_Project.Areas.Identity.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkUnit _workUnit;

        public ResetPasswordModel(UserManager<IdentityUser> userManager, IWorkUnit workUnit)
        {
            _userManager = userManager;
            _workUnit = workUnit;
        }


        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {



            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string newPassword { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("newPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmNewPassword { get; set; }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userEmail = TempData["UserName"] as string;
            var user = await _workUnit.User.getUserName(userEmail);
            

            if (user == null)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = await _userManager.ResetPasswordAsync(user, token, Input.newPassword);
            if (result.Succeeded)
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}
