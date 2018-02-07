using System.Collections.Generic;
using System.Threading.Tasks;
using JacHomePage.Models;

namespace JacHomePage.Persistence
{
    public interface IJackRepository
    {
        Task AddContact(Contact contact);

        Task<Contact> GetContact(int id);

        Task<List<Contact>> GetContacts();
    }
}