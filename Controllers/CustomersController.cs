using MovieApplication.Models;
using MovieApplication.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                
                customer = new Customer(),
                MembershipTypes = membershipTypes

            };
            return View("NewCustomer", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //now I am adding validations to my customer
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("NewCustomer",viewModel);
            }
            if (customer.Id == 0)
            {
                Console.Write("This is the membership Id of the selected Customer : "+customer.membershipNameId);
                _context.customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.membershipTypeId = customer.membershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;

            }

            _context.SaveChanges();
            return RedirectToAction("Customer", "Customers");
        }
       
        public ActionResult Customer()
        {
            //var customers = _context.customers.Include(c => c.membershipType).ToList();

            return View();

        }
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)

        {
            var customer = _context.customers.Include(c => c.membershipType).SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
            
        }
       
        
        public ActionResult Edit(int id)
        {
            var customers = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel()
            {
                customer = customers,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("NewCustomer", viewModel);
        }

        /*public ActionResult CustomerDetails(int Id)
        {
            //I know what was wrong now
            return View();
        }
        
        public ActionResult Customer()
        {
            var movie1 = new Movie { Name="Finding Nimo"};
            var customers1 = new List<Customer>
            {
                new Customer{ Name ="first Customer" },
                new Customer{ Name ="Second Customer"}

            };
            var cvm = new CustomerViewModel
            {
                movie = movie1,
                Customers = customers1
                
            };
            return View(cvm);
        }*/
    }
}