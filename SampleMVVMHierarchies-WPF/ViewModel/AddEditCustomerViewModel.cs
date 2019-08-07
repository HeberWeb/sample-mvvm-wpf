using SampleMVVMHierarchies_WPF.Model;
using SampleMVVMHierarchies_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.ViewModel
{
    class AddEditCustomerViewModel : BindableBase
    {
        private ICustomersRepository _customersRepository;
        public AddEditCustomerViewModel(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
            CancelCommand = new MyICommand<string>(OnCancel);
            SaveCommand = new MyICommand<string>(OnSave, CanSave);
            this.GetCust();
        }

        private async void GetCust()
        {
            //var custGet = _customersRepository.GetCustomerAsync(0);
            //if (custGet != null)
            //{
            //    SetCustomer(custGet);
            //}
            //else
            //{
            //    SetCustomer(new Model.Customer());
            //}

            SetCustomer(new Model.Customer());
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

        private void UpdateCustumer(SimpleEditableCustomer source, Customer target)
        {
            target.Id = source.Id;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Phone = source.Phone;
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

        private async void OnSave(string t)
        {
            UpdateCustumer(Customer, _editingCustomer);
            if (EditMode)
            {
                await _customersRepository.UpdateCustomerAsync(_editingCustomer);
            }
            else
            {
                await _customersRepository.AddCustomerAsync(_editingCustomer);
            }
            Done();
        }

        private bool CanSave(string t)
        {
            return !Customer.HasErrors;
        }
    }
}
