using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using JacHomePage.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using JacHomePage.Models;
using JacHomePage.Persistence;
using JacHomePage.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using Microsoft.Extensions.Localization.Internal;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace JacHomePage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IJackRepository _jackRepository;
        private readonly IHostingEnvironment _host;
        private readonly IToastNotification _toastNotification;
        private readonly OfferSettings _offerSettings;

        public HomeController(IMapper mapper, IJackRepository jackRepository, IOptionsSnapshot<OfferSettings> options, IHostingEnvironment host, IToastNotification toastNotification)
        {
            _mapper = mapper;
            _jackRepository = jackRepository;
            _host = host;
            _toastNotification = toastNotification;
            _offerSettings = options.Value;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("/api/contact")]
        public async Task<IActionResult> ResumeOffer(IFormFile file, ContactResource contactForm)
        {
            Offer offer = new Offer();
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            if (file != null)
            {
                if (file.Length == 0) return BadRequest("Pusty plik");
                if (file.Length > _offerSettings.MaxBytes) return BadRequest("Przekroczono maksymalny rozmiar pliku");
                if (!_offerSettings.IsSupported(file.FileName)) return BadRequest("Błedne rozszerzenie pliku");

                var uploadPath = Path.Combine(_host.WebRootPath, "uploads");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // generwujemy nowa nazwe zeby zapobiec podmian pliku na serwerze
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                offer.Name = filePath;
            }
            

            var contact = _mapper.Map<ContactResource, Contact>(contactForm);
            contact.ContactDate = DateTime.Now;
            if (!String.IsNullOrWhiteSpace(offer.Name))
            {
                contact.Offer = offer;
            }

            await _jackRepository.AddContact(contact);

            contact = await _jackRepository.GetContact(contact.ID);

            //return Ok(_mapper.Map<Contact, ContactResource>(contact));
            _toastNotification.AddSuccessToastMessage("Dziękuje za przesłanie wiadomości!", "Sukces", null);
            return RedirectToAction("Index");
        }

        [HttpGet("/api/contacts")]
        public async Task<List<ContactResource>> GetContacts()
        {

            var contacts =await _jackRepository.GetContacts();

            return _mapper.Map<List<Contact>, List<ContactResource>>(contacts);
        }
     
    }
}
