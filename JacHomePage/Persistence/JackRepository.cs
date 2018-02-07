using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JacHomePage.Models;
using Microsoft.EntityFrameworkCore;

namespace JacHomePage.Persistence
{
    public class JackRepository : IJackRepository
    {
        private readonly JackDbContext _jackDbContext;

        public JackRepository(JackDbContext jackDbContext)
        {
            _jackDbContext = jackDbContext;
        }

        public async Task AddContact(Contact contact)
        {
            _jackDbContext.Add(contact);
            await _jackDbContext.SaveChangesAsync();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _jackDbContext.Contacts.SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<List<Contact>> GetContacts()
        {
            return await _jackDbContext.Contacts
                .Include(c => c.Offer).ToListAsync();
        }
    }
}
