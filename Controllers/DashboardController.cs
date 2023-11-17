using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using real_estate.Data;
using real_estate.Models;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Bcpg.Sig;
using Property = real_estate.Models.Property;
using Features = real_estate.Models.Features;

namespace real_estate.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        // sprhmdmwwfndypll 
        public async Task<string> sendMassage()
        {
            var massage = new MimeMessage();
            massage.From.Add(new MailboxAddress ("Test Massage", "zainabhani703@gmail.com"));
            massage.To.Add(MailboxAddress.Parse("zainab1997522@gmail.com"));
            massage.Subject= "Test my ASP.net core mvc project";
            massage.Body = new TextPart("plain")
            {

                Text = "Welcome to My App!"

            };



            using (var client = new SmtpClient())

            {

                try
                {

                    client.Connect("smtp.gmail.com", 587);

                    client.Authenticate("zainabhani703@gmail.com", "sprhmdmwwfndypll");

                    await client.SendAsync(massage);

                    client.Disconnect(true);

                }

                catch(Exception e) 
                {
                    return e.Message.ToString();
                }

            }
            return "ok";
        }
        public IActionResult NewUser(Client client)
        {
            _context.client.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Signup");
        }

        public IActionResult Search(string searchString)
        {
            var client_result = _context.client.Where(x => x.city.Contains(searchString)).ToList();
            ViewBag.searchresult = client_result;
            return View();
        }
        public IActionResult Edit(int id)
        {
            var clientId = _context.client.SingleOrDefault(x => x.client_id == id);
            return View(clientId);
        }
        

        public IActionResult Update(Client updatedClient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Locate the target client
                    var client = _context.client.Find(updatedClient.client_id);

                    if (client != null)
                    {
                        // Log the client details before the update
                        Console.WriteLine($"Before Update - Client ID: {client.client_id}, Username: {client.username}");

                        // Update only specific properties
                        client.username = updatedClient.username;
                        client.name = updatedClient.name;
                        client.email = updatedClient.email;
                        client.city = updatedClient.city;
                        client.phone = updatedClient.phone;
                        client.password = updatedClient.password;

                        // Log the client details after the update
                        Console.WriteLine($"After Update - Client ID: {client.client_id}, Username: {client.username}");

                        _context.client.Update(client);
                        _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle the case when the client is not found
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions if any
                    return StatusCode(500, "Internal Server Error");
                }
            }

            // If ModelState is not valid, return to the Edit view with the model
            return View("Edit", updatedClient);
        }

        public IActionResult Delete(int id)
        {
            var clientDel = _context.client.SingleOrDefault(x => x.client_id == id);
            if (clientDel != null)
            {
                _context.client.Remove(clientDel);
                _context.SaveChanges();
                TempData["Del"] = "Ok";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Deletep(int pid)
        {
            var propertyDel = _context.property.SingleOrDefault(x => x.property_Id == pid);
            if (propertyDel != null)
            {
                _context.property.Remove(propertyDel);
                _context.SaveChanges();
                TempData["Del"] = "Ok";
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Index()
        {
            // Retrieve all clients initially
            var client = _context.client.ToList();
            // To Call and repersent the list in the view using ViewBag
            ViewBag.clients = client;
            
            // the bellow codes used to create a filter for the city column
            // Get the selected city from the query string
            var selectedCity = Request.Query["selectedCity"];

            // Apply the city filter if selectedCity is not null or empty
            if (!string.IsNullOrEmpty(selectedCity))
            {
                client = client.Where(x => x.city == selectedCity).ToList();
            }

            ViewBag.clients = client;
            // Populate the dropdown menu
            ViewBag.UniqueCities = _context.client.Select(x => x.city).Distinct().ToList();
            return View();
        }


        //public IActionResult NewProperty(int initializedId, Property property, Houses house, Apartments apartment, Property_image image, Features feature)
        //{
        //    // Set the initialized ID to the property
        //    property.property_Id = initializedId;

        //    // Add property first
        //    _context.property.Add(property);
        //    _context.SaveChanges();

        //    // Assign the property id for further use to create house/apartment
        //    int propertyId = property.property_Id;

        //    // The property either be a house or apartment to handle the correct one based on p_type
        //    if (property.p_type == "House")
        //    {
        //        house.property_Id = propertyId;
        //        _context.houses.Add(house);
        //    }
        //    else if (property.p_type == "Apartment")
        //    {
        //        apartment.property_Id = propertyId;
        //        _context.apartments.Add(apartment);
        //    }


        //    // Property_image 
        //    image.property_Id = propertyId;
        //    _context.property_image.Add(image);

        //    // Features 
        //    feature.property_Id = propertyId;
        //    _context.features.Add(feature);

        //    _context.SaveChanges();

        //    // Check if ModelState is not valid
        //    if (!ModelState.IsValid)
        //    {
        //        // You can pass the property model back to the view
        //        return View("Property", property);
        //    }

        //    return RedirectToAction("Property");
        //}



        //public IActionResult FirstAction(Property property)
        //{
        //    // Add property first
        //    _context.property.Add(property);
        //    _context.SaveChanges();

        //    // Get the generated propertyId
        //    int propertyId = property.property_Id;

        //    // Store propertyId in TempData
        //    TempData["PropertyId"] = propertyId;

        //    // Redirect to the next form (House or Apartment)
        //    if (property.p_type == "house")
        //    {
        //        return RedirectToAction("HouseAction");
        //    }
        //    else if (property.p_type == "apartment")
        //    {
        //        return RedirectToAction("ApartmentAction");
        //    }

        //    return RedirectToAction("FirstAction");
        //}

        //// Action for the House form
        //[HttpPost]
        //public IActionResult HouseAction(Houses house)
        //{
        //    // Retrieve propertyId from TempData
        //    int? propertyId = TempData["PropertyId"] as int?;

        //    // Check if propertyId is null
        //    if (!propertyId.HasValue)
        //    {
        //        // Handle the case where propertyId is null
        //        // Redirect or return an error view
        //        return RedirectToAction("FirstAction");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        house.property_Id = propertyId.Value;
        //        _context.houses.Add(house);
        //        _context.SaveChanges();

        //        // Store propertyId in TempData
        //        TempData["PropertyIdh"] = house.property_Id;

        //        return RedirectToAction("PropertyImageAction");
        //    }

        //    return View("HouseAction", house);
        //}

        // Action for the Apartment form
        //[HttpPost]
        //public IActionResult ApartmentAction(Apartments apartment)
        //{
        //    // Retrieve propertyId from TempData
        //    int? propertyId = TempData["PropertyId"] as int?;

        //    // Check if propertyId is null
        //    if (!propertyId.HasValue)
        //    {
        //        // Handle the case where propertyId is null
        //        // Redirect or return an error view
        //        return RedirectToAction("FirstAction");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        apartment.property_Id = propertyId.Value;
        //        _context.apartments.Add(apartment);
        //        _context.SaveChanges();

        //        // Store propertyId in TempData
        //        TempData["PropertyIdap"] = apartment.property_Id;

        //        return RedirectToAction("PropertyImageAction");
        //    }

        //    return View("ApartmentAction", apartment);
        //}

        //// Action for the Property Image form
        //[HttpPost]
        //public IActionResult PropertyImageAction(Property_image images)
        //{
        //    // Retrieve propertyId from TempData
        //    int? propertyIdph = TempData["PropertyIdh"] as int?;
        //    int? propertyIdpar = TempData["PropertyIdap"] as int?;

        //    if (ModelState.IsValid)
        //    {
        //        int propertyIdpi;

        //        if (propertyIdph.HasValue)
        //        {
        //            propertyIdpi = propertyIdph.Value;
        //        }
        //        else if (propertyIdpar.HasValue)
        //        {
        //            propertyIdpi = propertyIdpar.Value;
        //        }
        //        else
        //        {
        //            // Handle the case where both propertyIdph and propertyIdpar are null
        //            return RedirectToAction("FirstAction");
        //        }

        //        images.property_Id = propertyIdpi;
        //        _context.property_image.Add(images);
        //        _context.SaveChanges();

        //        // Store propertyId in TempData
        //        TempData["PropertyIdpi"] = images.property_Id;

        //        return RedirectToAction("FeatureAction");
        //    }

        //    // Return the view with model state errors
        //    return View("PropertyImageAction", images);
        //}

        //// Action for the Feature form
        //[HttpPost]
        //public IActionResult FeatureAction(Features feature)
        //{
        //    // Retrieve propertyId from TempData
        //    int? propertyIdfe = TempData["PropertyIdpi"] as int?;

        //    if (ModelState.IsValid)
        //    {
        //        feature.property_Id = propertyIdfe.Value;
        //        _context.features.Add(feature);
        //        _context.SaveChanges();
        //        return RedirectToAction("Property");
        //    }

        //    // Return the view with model state errors
        //    return View("Property", feature);
        //}

        public IActionResult FirstAction(Property property)
        {
            _context.property.Add(property);
            _context.SaveChanges();
            return RedirectToAction("Property");
        }

        public IActionResult HouseAction(Houses house) {
            _context.houses.Add(house);
            _context.SaveChanges();
            return RedirectToAction("Property");
        }
        public IActionResult ApartmentAction(Apartments apartment)
        {
            _context.apartments.Add(apartment);
            _context.SaveChanges();
            return RedirectToAction("Property");
        }

        public IActionResult Property()
        {
            var clients = _context.client.ToList();
            var admins = _context.admins.ToList();
            var property = _context.property.ToList();
            var house = _context.houses.ToList();
            var apartment = _context.apartments.ToList();

            ViewBag.UniqueClients = clients;
            ViewBag.UniqueAdmins = admins;
            ViewBag.Propertylist = property;
            ViewBag.House = house;
            ViewBag.Apartment = apartment;


            return View(property);
        }
    }
}
