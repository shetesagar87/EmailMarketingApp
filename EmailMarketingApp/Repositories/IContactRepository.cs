using EmailMarketingApp.Models;

namespace EmailMarketingApp.Repositories
{
    public interface IContactRepository
    {
        Task AddAsync(Contact contact);
        Task<bool> EmailExistsAsync(string email);
        Task<List<Contact>> GetActiveContactsAsync();
    }
}
