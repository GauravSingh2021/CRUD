using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDOperations.Models;

namespace CRUDOperations.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDbContext dbContext;
        public CustomerController(CustomerDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            var customers = dbContext.customers.ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var customer = dbContext.customers.SingleOrDefault(e => e.Id == Id);
            if(customer!=null)
            {
                dbContext.customers.Remove(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int Id)
        {
            var customer = dbContext.customers.SingleOrDefault(e => e.Id == Id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer cust)
        {
            dbContext.customers.Update(cust);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            var customer = dbContext.customers.SingleOrDefault(e => e.Id == Id);
            return View(customer);
        }

    }
}
