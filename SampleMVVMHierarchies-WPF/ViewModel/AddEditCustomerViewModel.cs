using SampleMVVMHierarchies_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.ViewModel
{
    class AddEditCustomerViewModel : BindableBase
    {
        public AddEditCustomerViewModel()
        {
            CancelCommand = new MyICommand<string>(OnCancel);
            SaveCommand = new MyICommand<string>(OnSave, CanSave);
            SetCustomer(new Customer());
        }

        private bool _EditMode;

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableCustomer _Customer;

        public SimpleEditableCustomer Customer
        {
            get { return _Customer; }
            set { SetProperty(ref _Customer, value); }
        }

        private Customer _editingCustomer = null;

        public void SetCustomer(Customer cust)
        {
            _editingCustomer = cust;

            if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(cust, Customer);
        }

        private void CopyCustomer(Customer cust, SimpleEditableCustomer customer)
        {
            customer.Id = cust.Id;
            customer.FirstName = cust.FirstName;
            customer.LastName = cust.LastName;
            customer.Email = cust.Email;
            customer.Phone = cust.Phone;
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public MyICommand<string> CancelCommand { get; private set; }
        public MyICommand<string> SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel(string t)
        {
            Done();
        }

        private void OnSave(string t)
        {
            Done();
        }

        private bool CanSave(string t)
        {
            return !Customer.HasErrors;
        }
    }
}
