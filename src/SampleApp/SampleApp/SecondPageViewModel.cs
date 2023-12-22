using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleApp
{
    public class SecondPageViewModel
    {
        public SecondPageViewModel()
        {
            DeleteCmd = new RelayCommand(Delete);
        }

        public ICommand DeleteCmd { get; set; }
        private void Delete() 
        {
            var isDelete = WeakReferenceMessenger.Default.Send<DeleteMessage>();
        }
    }
}
