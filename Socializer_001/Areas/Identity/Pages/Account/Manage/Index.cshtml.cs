// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Socializer_001.Models;
using Socializer_001.Services;

namespace Socializer_001.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GetUserOptionalDataAsync getUserOptionalDataAsync;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            GetUserOptionalDataAsync userOptionalDataAsync)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            getUserOptionalDataAsync = userOptionalDataAsync;

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Family Name")]
            public string FamilyName { get; set; }

            [Display(Name = "Country")]
            public string Country { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Field of Study")]
            public string Field { get; set; }

            [Display(Name = "Entered Year")]
            public string EnteredYear { get; set; }

            [Display(Name = "Sex")]
            public short? Sex { get; set; }

            [Display(Name = "Arrival Date")]
            [DataType(DataType.Date)] 
            public DateOnly? ArrivalDate { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var FullUser = await getUserOptionalDataAsync.GetUserFullDataAsync(user);
            
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = FullUser.FirstName,
                FamilyName = FullUser.FamilyName,
                Country = FullUser.Country,
                Address = FullUser.Address,
                Field = FullUser.Field,
                Sex = FullUser.sex,
                EnteredYear = FullUser.EnteredYear,
                ArrivalDate = FullUser.ArrivalDate,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var fulluser = await getUserOptionalDataAsync.GetUserFullDataAsync(user);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(fulluser);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            user.FirstName = Input.FirstName;
            user.FamilyName = Input.FamilyName;
            user.Country = Input.Country;
            user.Address = Input.Address;
            user.Field = Input.Field;
            user.EnteredYear = Input.EnteredYear;
            user.sex = Input.Sex;
            user.ArrivalDate = Input.ArrivalDate;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
