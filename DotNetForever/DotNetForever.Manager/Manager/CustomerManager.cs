using DotNetForever.Model.Model;
using DotNetForever.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetForever.Manager.Manager
{
    public class CustomerManager
    {
        readonly CustomerRepository _customerRepository = new CustomerRepository();

        public bool UniqueEmail(Customer customer)
        {
            return _customerRepository.UniqueEmail(customer);
        }

        public bool UniqueContact(Customer customer)
        {
            return _customerRepository.UniqueContact(customer);
        }

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
        public List<Customer> Search(string search)
        {
            return _customerRepository.Search(search);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public int GetCount()
        {
            return _customerRepository.GetCount();
        }

        public int GetLoyaltyPointById(int customerId)
        {
            return _customerRepository.GetLoyaltyPointById(customerId);
        }

        public string GetLastCustomerCode()
        {
            return _customerRepository.GetLastCustomerCode();
        }

    }
}
