using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Repository.Repository
{
    public class CustomerRepository
    {
        public bool CheckEmailAvailability(string email)
        {
            using (var context = new SMSDbContext())
            {
                var customer = context.Customers.Where(x => x.Email.Contains(email) ).ToList();

                if (customer.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Add(Customer customer)
        {
            using (var context = new SMSDbContext())
            {
                context.Customers.Add(customer);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update (Customer customer)
        {
            using (var context = new SMSDbContext())
            {
                Customer model = new Customer();
                model = context.Customers.Find(customer.Id);
                if (model != null)
                {
                    model.Id = customer.Id;
                    model.Code = customer.Code;
                    model.Name = customer.Name;
                    model.Address = customer.Address;
                    model.Email = customer.Email;
                    model.Contact = customer.Contact;
                    model.LoyaltyPoint = customer.LoyaltyPoint;
                }

                return context.SaveChanges() > 0;
               
            }
        }

        public bool Delete(int id)
        {
            using (var context = new SMSDbContext())
            {
                Customer customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                return context.SaveChanges() > 0;
            }
        }
        public Customer GetById(int id)
        {
            using (var context = new SMSDbContext())
            {
                return context.Customers.Find(id);
            }
        }
        public List<Customer> Search(string search)
        {
            using (var context = new SMSDbContext())
            {
                return context.Customers.Where(x => (x.Name.ToLower().Contains(search.ToLower()) || x.Code.Contains(search))).ToList();


            }
        }
        public List<Customer> GetAll()
        {
            using (var context = new SMSDbContext())
            {
                return context.Customers.ToList();
            }
        }
        public int GetCount()
        {
            using (var context = new SMSDbContext())
            {
                return context.Customers.Count();
            }
        }

        public int GetLoyaltyPointById(int customerId)
        {
            int loyaltyPoint = 0;
            using (var context=new SMSDbContext())
            {
                loyaltyPoint = context.Customers
                                .Where(x => x.Id == customerId)
                                .Select(x => x.LoyaltyPoint)
                                .FirstOrDefault();
            }

            return loyaltyPoint;
        }

        public string GetLastCustomerCode()
        {
            using (var context = new SMSDbContext())
            {
                return context.Customers.OrderByDescending(x => x.Id).Select(x => x.Code).DefaultIfEmpty("").FirstOrDefault();

            }


        }
    }
}
