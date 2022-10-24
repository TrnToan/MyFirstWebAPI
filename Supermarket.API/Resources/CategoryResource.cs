namespace Supermarket.API.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

// map data that client applications send to this endpoint (in this case, the category name) to a class of our application.