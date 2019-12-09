using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetForever.DatabaseContext.DatabaseContext;
using DotNetForever.Model.Model;

namespace DotNetForever.Repository.Repository
{
    public class SupplierRepository
    {

        public bool UniqueEmail(Supplier supplier)
        {
            using (var context = new SMSDbContext())
            { 
                var suppliers = (dynamic) null;
                if (supplier.Id !=0)
                {
                    suppliers = context.Suppliers.Where(x => x.Email.Equals(supplier.Email) && x.Id != supplier.Id).ToList();
                }
                else
                {
                    suppliers = context.Suppliers.Where(x => x.Email.Equals(supplier.Email)).ToList();
                }
                
                return suppliers.Count > 0;
            }
        }

        public bool UniqueContact(Supplier supplier)
        {
            using (var context = new SMSDbContext())
            {
                var suppliers = (dynamic)null;
                if (supplier.Id != 0)
                {
                    suppliers = context.Suppliers.Where(x => x.Contact.Equals(supplier.Contact) && x.Id != supplier.Id).ToList();
                }
                else
                {
                    suppliers = context.Suppliers.Where(x => x.Contact.Equals(supplier.Contact)).ToList();
                }

                return suppliers.Count > 0;
            }
        }
        public bool Add(Supplier supplier)
        {
            using (var context = new SMSDbContext())
            {
                context.Suppliers.Add(supplier);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Supplier supplier)
        {
            using (var context = new SMSDbContext())
            {
                Supplier model = new Supplier();
                model = context.Suppliers.Find(supplier.Id);

                if (model != null)
                {
                    model.Id = supplier.Id;
                    model.Code = supplier.Code;
                    model.Name = supplier.Name;
                    model.Address = supplier.Address;
                    model.Email = supplier.Email;
                    model.Contact = supplier.Contact;
                    model.ContactPerson = supplier.ContactPerson;
                   
                }


                return context.SaveChanges() > 0;
                //return true;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new SMSDbContext())
            {
                Supplier supplier = context.Suppliers.Find(id);
                context.Suppliers.Remove(supplier);
                return context.SaveChanges() > 0;
            }
        }
        public Supplier GetById(int id)
        {
            using (var context = new SMSDbContext())
            {
                return context.Suppliers.Find(id);
            }
        }
        public List<Supplier> Search(string search)
        {
            using (var context = new SMSDbContext())
            {
                return context.Suppliers.Where(x => (x.Name.ToLower().Contains(search.ToLower()) || x.Code.Contains(search))).ToList();


            }
        }
        public List<Supplier> GetAll()
        {
            using (var context = new SMSDbContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public int GetCount()
        {
            using (var context = new SMSDbContext())
            {
                return context.Suppliers.Count();
            }
        }

        public string GetLastSupplierCode()
        {
            using (var context = new SMSDbContext())
            {
                return context.Suppliers.OrderByDescending(x => x.Id).Select(x => x.Code).FirstOrDefault();

            }


        }
    }
}
