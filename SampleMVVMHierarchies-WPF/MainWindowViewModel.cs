using SampleMVVMHierarchies_WPF.Services;
using SampleMVVMHierarchies_WPF.ViewModel;
using SampleMVVMHierarchies_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF
{
    class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private CustomerListViewModel custListViewModel = new CustomerListViewModel();

        private OrderViewModel orderViewModelModel = new OrderViewModel();

        private AddEditCustomerViewModel addEditCustomerViewModel = new AddEditCustomerViewModel(new CustomersRepository());

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "orders":
                    CurrentViewModel = orderViewModelModel;
                    break;
                case "addCustomer":
                    CurrentViewModel = addEditCustomerViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = custListViewModel;
                    break;
            }
        }
    }
}
