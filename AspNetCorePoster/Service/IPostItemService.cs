using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCorePoster.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCorePoster.Services
{
/*    public class ApplicationUser : IdentityUser
    {
    }
*/
    public interface IPostItemService
    {
        Task<PostItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> PostItemAsync(PostItem newItem, IdentityUser user);
    }
}