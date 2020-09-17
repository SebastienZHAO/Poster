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
    public class CreatePostController : Controller
    {
        private readonly IPostItemService _postItemService;

        private readonly UserManager<IdentityUser> _userManager;
        public CreatePostController(IPostItemService postItemService, UserManager<IdentityUser> userManager)
        {
            _postItemService = postItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AddPostItem(PostItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("MyPostHistoryView");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _postItemService.PostItemAsync(newItem, currentUser);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("MyPostHistoryView");
        }
    } 
}