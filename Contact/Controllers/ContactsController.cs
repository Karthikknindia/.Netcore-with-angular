using Microsoft.AspNetCore.Mvc;
using static contact.Data.ContactDbContext;

using Microsoft.EntityFrameworkCore;
using contact.Models;
using contact.Data;

namespace contact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContactsController : Controller
    {

        private readonly ContactDbContext contactsDbcontext;

        public ContactsController(ContactDbContext contactsDbcontext)
        {
            this.contactsDbcontext = contactsDbcontext;
        }

        // Get All contacts
        [HttpGet]

        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await contactsDbcontext.Contacts.ToListAsync();
            return Ok(contacts);
        }

        // Get single contacts
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetContact")]
        public async Task<IActionResult> GetContacts([FromRoute] Guid id)
        {
            var contact = await contactsDbcontext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound("Contacts not Found");
        }
        //add contact
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await contactsDbcontext.Contacts.AddAsync(contact);
            await contactsDbcontext.SaveChangesAsync();
            var result = await contactsDbcontext.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);
            if (result != null)
            {
                return Ok(result);
            }
            return  NotFound("Contact not found") ;
        }

        //Update Contact
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Contact contact)
        {
            var existingContact = await contactsDbcontext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.Address = contact.Address;
                existingContact.contact = contact.contact;
                existingContact.city = contact.city;
                
                existingContact.State = contact.State;
                


                await contactsDbcontext.SaveChangesAsync();
                return Ok(existingContact);
            }
            return NotFound("Contact Not Found");
        }

        //Deletet contact
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var existingCard = await contactsDbcontext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                contactsDbcontext.Contacts.Remove(existingCard);
                await contactsDbcontext.SaveChangesAsync();
                return Ok(existingCard);
            }
            return NotFound("Contact Not Found");
        }
    }
}
