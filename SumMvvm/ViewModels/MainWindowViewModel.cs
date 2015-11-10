using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumMvvm.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private int _x = 1;
        private int _y = 2;
        private int _z = 3;
        public int X
        {
            get { return _x; }
            set
            {
                SetProperty(ref _x, value);
                OnPropertyChanged(()=> Z);
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                SetProperty(ref _y, value);
                OnPropertyChanged(() => Z);
            }
        }

        public int Z
        {
            get { return _x + _y; }
            set
            {
                SetProperty(ref _z, value);
            }
        }

        public ICommand SumCommand { get; private set; }

        public MainWindowViewModel()
        {
            SumCommand = new DelegateCommand(onSum);
        }

        private void onSum()
        {
            Z = X + Y;
        }
    }
}
