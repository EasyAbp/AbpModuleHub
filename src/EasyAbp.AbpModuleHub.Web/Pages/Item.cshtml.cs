using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.AbpModuleHub.Web.Pages
{
    public class ItemModel : AbpModuleHubPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        public IActionResult OnGet()
        {
            if (Id == Guid.Empty)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}