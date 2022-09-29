using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    // service is basically a class or interface that defines methods to handle some business logic
    // isolate the request and response handling from the real logic needed to complete tasks
    // The service we’re going to create initially will define a single behavior
    // this method returns all existing categories in the database.
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}

//Task class, encapsulating the return, indicates asynchrony. 
//We need to think in an asynchronous method due to the fact that 
//we have to wait for the database to complete some operation to return the data 
//this process can take a while