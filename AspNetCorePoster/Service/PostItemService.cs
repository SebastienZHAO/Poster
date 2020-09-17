using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AspNetCorePoster.Data;
using AspNetCorePoster.Models;

namespace AspNetCorePoster.Services
{
    public class PostItemService : IPostItemService
    {
        private readonly ApplicationDbContext _context;
        public PostItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PostItem[]> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _context.Items
            .Where(x => x.UserId == user.Id)
            .ToArrayAsync();
        }

        public async Task<bool> PostItemAsync(PostItem newItem, IdentityUser user)
        {
            newItem.PostDate = DateTimeOffset.Now;
            newItem.UserId = user.Id;
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}