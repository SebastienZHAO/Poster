namespace AspNetCorePoster.Models
{
    public class PostViewModel
    {
        public PostItem[] Items{get; set; }

        public PostViewModel(PostItem[] Items)
        {
            this.Items = Items;
        }
    }
}