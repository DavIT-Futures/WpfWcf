using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using TestApp.BaseUI;
using TestApp.Entity;
using TestApp.TestAppUI.View;
using TestApp.Client;

namespace TestApp.TestAppUI.ViewModel
{
    public class ProductViewModel : EntityViewModel
    {
        public ProductViewModel(EntityObject entity, Window view) : base(entity, view)
        {

        }

        private ICommand displayCommand;
        public ICommand DisplayCommand
        {
            get
            {
                if (displayCommand == null)
                {
                    displayCommand = new RelayCommand(Display, CanDisplay);
                }
                return displayCommand;
            }
            set
            {
                displayCommand = value;
            }
        }

        public bool CanDisplay(object execute)
        {
            return string.IsNullOrEmpty(Entity.Error);
        }

        public void Display(object execute)
        {
            MessageBox.Show(Entity.ToString());
        }
    }
}
