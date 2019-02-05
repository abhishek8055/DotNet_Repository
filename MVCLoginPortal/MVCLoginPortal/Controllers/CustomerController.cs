using MVCLoginPortal.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using MVCLoginPortal.ViewModel;

namespace MVCLoginPortal.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Customer
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {      
            if (!ModelState.IsValid)
            {              
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };              
                return View("New", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var dataInDB = _context.Customers.Single( c => c.Id == customer.Id);
                dataInDB.Name = customer.Name;
                dataInDB.DateofBirth = customer.DateofBirth;
                dataInDB.MembershipType = customer.MembershipType;
                dataInDB.MembershipTypeId = customer.MembershipTypeId;
                dataInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }         
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault( c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}