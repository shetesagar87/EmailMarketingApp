using EmailMarketingApp.Models;
using EmailMarketingApp.Repositories;

namespace EmailMarketingApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contact contact)
        {
            if (!await EmailExistsAsync(contact.Email))
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> EmailExistsAsync(string email)
            => _context.Contacts.AnyAsync(x => x.Email == email);

        public Task<List<Contact>> GetActiveContactsAsync()
        {
            throw new NotImplementedException();
        }
    }

}
