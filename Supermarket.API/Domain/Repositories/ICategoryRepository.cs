using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);       // persist data into the database
    }
}

// We need to access the database and return all categories, then we need to return this data to the client.
// Reposotory pattern is used to manage data access
// When using the Repository Pattern, we define repository classes, that basically encapsulate all logic to handle data access. 
// These repositories expose methods to list, create, edit and delete objects of a given model
// these methods talk to the database to perform CRUD operations, isolating the database access from the rest of the application.