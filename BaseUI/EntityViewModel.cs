using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using TestApp.Entity;
using System.Linq.Expressions;
using TestApp.Util;
using System.Windows;

namespace TestApp.BaseUI
{
    public class EntityViewModel : INotifyPropertyChanged
    {
        public Window View { get; set; }

        private EntityObject entity;
        public EntityObject Entity
        {
            get { return entity; }
            set 
            { 
                entity = value;
                OnPropertyChange(() => Entity);
            }
        }


        public EntityViewModel()
        {
            this.Entity = null;
        }

        public EntityViewModel(EntityObject entity, Window view)
        {
            this.Entity = entity;
            this.View = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Attempts to raise the PropertyChanged event, and 
        /// invokes the virtual AfterPropertyChanged method.
        /// </summary>
        /// <typeparam name="T">Class type - no need to provide any more (see example)</typeparam>
        /// <param name="propertyPointer">Property expression, for example (() => CallTypeRestrictionId)</param>
        protected void OnPropertyChange<T>(Expression<Func<T>> property)
        {
            string propertyName = property.GetPropertyName<T>();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
