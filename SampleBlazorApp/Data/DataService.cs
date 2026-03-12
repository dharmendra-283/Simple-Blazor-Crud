using SampleBlazorApp.Models;

namespace SampleBlazorApp.Data
{
    public class DataService
    {
        private DataAccessLayer objDal;

        public DataService(DataAccessLayer _objDal)
        {
            this.objDal = _objDal;
        }

        public List<Customer> GetCustomers()
        {
            return this.objDal.GetAllCustomers().ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return this.objDal.GetCustomerById(customerId);
        }

        public string Create(Customer customer)
        {
            this.objDal.AddCustomer(customer);
            return "Customer Added Successfully.";
        }

        public string UpdateCustomer(Customer customer)
        {
            this.objDal.UpdateCustomer(customer);
            return "Customer Updated Successfully.";
        }

        public string DeleteCustomer(int customerId)
        {
            this.objDal.DeleteCustomer(customerId);
            return "Customer Deleted Successfully.";
        }
    }
}
