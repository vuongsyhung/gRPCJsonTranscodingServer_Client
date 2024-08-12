using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gRPCJsonTranscodingClient.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;
using System.Text;
using NuGet.Versioning;

namespace gRPCJsonTranscodingClient.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5244/api/customers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var x = JsonConvert.DeserializeObject<Dictionary<string, Customer[]>>(apiResponse);
                    return View(x);
                }
            }
        }

        // GET: Customers/Details/id
        public async Task<IActionResult> Details(int id = 0)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5244/api/customers/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var x = JsonConvert.DeserializeObject<Customer>(apiResponse);                    
                    return View(x);
                }
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,DateOfBirth,Email,StreesAddress,City,State,ZipCode,Country,Sex")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:5244/api/customers", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var x = JsonConvert.DeserializeObject<Customer>(apiResponse);
                        if (x == null)
                        {
                            return NotFound();
                        }
                    }                    
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Edit/id
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Customer customer;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5244/api/customers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var x = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    customer = x;
                }
            }

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/id        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,DateOfBirth,Email,StreesAddress,City,State,ZipCode,Country,Sex")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        HttpContent body = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                        using (var response = await httpClient.PutAsync("http://localhost:5244/api/customers/"+id, body))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<Customer>(apiResponse);
                            return View(result);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound(customer.CustomerId);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Customer customer;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5244/api/customers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var x = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    customer = x;
                }
            }
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5244/api/customers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
