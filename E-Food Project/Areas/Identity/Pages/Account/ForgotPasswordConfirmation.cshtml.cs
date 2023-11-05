// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EFood.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace E_Food_Project.Areas.Identity.Pages.Account
{
    public class ForgotPasswordConfirmation : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public string userSecurityQuestion;
        

        public ForgotPasswordConfirmation(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            public string SecurityAnswer { get; set; }

        }

        public IActionResult OnGet()
        {
            userSecurityQuestion = TempData["SecurityQuestion"] as string;
            ViewData["SecurityQuestion"] = TempData["SecurityQuestion"] as string;
            TempData["SecurityQuestion"] = userSecurityQuestion;
            return Page();
        }

        public IActionResult OnPost()
        {
            var userSecurityAnswer = TempData["SecurityAnswer"] as string;


            if (Input.SecurityAnswer.Equals(userSecurityAnswer))
            {
                return RedirectToPage("./ResetPassword"); 
            }
            else
            {
                ModelState.AddModelError("Input.SecurityAnswer", "La respuesta de seguridad es incorrecta.");
                return RedirectToPage("./ForgotPasswordConfirmation");
            }
        }
    }
}