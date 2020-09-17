using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCorePoster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCorePoster.Models;

namespace AspNetCorePoster.Controllers
{
    [Authorize]
    public class MyPostController : Controller
    {
        // Actions go here
        private readonly IPostItemService _postItemService;

        private readonly UserManager<IdentityUser> _userManager;
        public MyPostController(IPostItemService postItemService, UserManager<IdentityUser> userManager)
        {
            _postItemService = postItemService;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> MyPost()
        {
            // Get to-do items from database
            // Put items into a model
            // Render view using the model
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var items = await _postItemService.GetIncompleteItemsAsync(currentUser);
            var model = new PostViewModel(items);
            //{
           //    Items = items
            //};
            return View(model);
        }
    }
}