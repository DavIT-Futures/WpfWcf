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
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using TestApp.Util;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace TestApp.TestAppUI.ViewModel
{
    public class MainViewModel : EntityViewModel
    {
        #region fields/properties
        public ProductEntity SelectedProduct { get; set; }
        public EmployeeEntity SelectedEmployee { get; set; }

        private List<ProductEntity> products;
        public List<ProductEntity> Products
        {
            get { return products; }
            set 
            { 
                products = value;
                OnPropertyChange(() => Products);
            }
        }

        private List<EmployeeEntity> employees;
        public List<EmployeeEntity> Employees
        {
            get { return employees; }
            set 
            { 
                employees = value;
                OnPropertyChange(() => Employees);
            }
        }

        private int progressValue;
        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                OnPropertyChange(() => ProgressValue);
            }
        }

        private Color progressColor;
        public Color ProgressColor
        {
            get { return progressColor; }
            set
            {
                progressColor = value;
                OnPropertyChange(() => ProgressColor);
            }
        }

        #endregion fields/properties

        public MainViewModel(EntityObject entity, Window view): base(entity, view)
        {

        }

        #region commands
        private ICommand openProductCommand;
        public ICommand OpenProductCommand
        {
            get
            {
                if (openProductCommand == null)
                {
                    openProductCommand = new RelayCommand(OpenProduct, CanOpenProduct);
                }
                return openProductCommand;
            }
            set
            {
                openProductCommand = value;
            }
        }

        public bool CanOpenProduct(object execute)
        {
            return SelectedProduct != null;
        }

        public void OpenProduct(object execute)
        {
            ProductView view = new ProductView();
            ProductViewModel vm = new ProductViewModel(SelectedProduct, view);
            view.DataContext = vm;
            view.ShowDialog();
        }

        private ICommand openEmployeeCommand;
        public ICommand OpenEmployeeCommand
        {
            get
            {
                if (openEmployeeCommand == null)
                {
                    openEmployeeCommand = new RelayCommand(OpenEmployee, CanOpenEmployee);
                }
                return openEmployeeCommand;
            }
            set
            {
                openEmployeeCommand = value;
            }
        }

        public bool CanOpenEmployee(object execute)
        {
            return SelectedEmployee != null;
        }

        public void OpenEmployee(object execute)
        {
            EmployeeView view = new EmployeeView();
            EmployeeViewModel vm = new EmployeeViewModel(SelectedEmployee, view);
            view.DataContext = vm;
            view.ShowDialog();
        }

        private ICommand openCovarianceCommand;
        public ICommand OpenCovarianceCommand
        {
            get
            {
                if (openCovarianceCommand == null)
                {
                    openCovarianceCommand = new RelayCommand(OpenCovariance, CanOpenCovariance);
                }
                return openCovarianceCommand;
            }
            set
            {
                openCovarianceCommand = value;
            }
        }

        public bool CanOpenCovariance(object execute)
        {
            return true;
        }

        public void OpenCovariance(object execute)
        {
            List<EntityObject> entities = EntityCommunicator.GetAll<ProductEntity>().ToList<EntityObject>();
            List<ProductEntity> products2 = entities.Cast<ProductEntity>().ToList();
        }

        private ICommand searchEntitiesCommand;
        public ICommand SearchEntitiesCommand
        {
            get
            {
                if (searchEntitiesCommand == null)
                {
                    searchEntitiesCommand = new RelayCommand(DoSearchEntities, CanSearchEntitiesCommand);
                }
                return searchEntitiesCommand;
            }
            set
            {
                searchEntitiesCommand = value;
            }
        }

        public bool CanSearchEntitiesCommand(object execute)
        {
            return true;
        }

        public void DoSearchEntities(object execute)
        {
            //SearchEntitiesThreadPool();
            //SearchEntitiesBackgroudWorker();
            //SearchEntitiesThread();
            SearchEntitiesTask();
        }

        private ICommand anonymousMethodsCommand;
        public ICommand AnonymousMethodsCommand
        {
            get
            {
                if (anonymousMethodsCommand == null)
                {
                    anonymousMethodsCommand = new RelayCommand(DoAnonymousMethodsCommand, CanAnonymousMethodsCommand);
                }
                return anonymousMethodsCommand;
            }
            set
            {
                anonymousMethodsCommand = value;
            }
        }

        public bool CanAnonymousMethodsCommand(object execute)
        {
            return true;
        }

        delegate void Del();
        delegate void Delx(int x);
        public void DoAnonymousMethodsCommand(object execute)
        {
            Del del = delegate()
            {
                int i = 1;
                i++;
            };
            del();

            Delx delx = (x) =>
            {
                x++;
            };
            delx(10);

            Action act = () =>
            {
                int i = 1;
                i++;
            };
            act();

            Predicate<int> pred = (x) =>
            {
                return x < 5;
            };
            bool result = pred(4);

            Func<ProductEntity, int> getId = (p) =>
            {
                return p.Id;
            };
            int id = getId(new ProductEntity() { Id = 10 });


        }

        private ICommand testCommand;
        public ICommand TestCommand
        {
            get
            {
                if (testCommand == null)
                {
                    testCommand = new RelayCommand(DoTest, CanTest);
                }
                return testCommand;
            }
            set
            {
                testCommand = value;
            }
        }

        public bool CanTest(object execute)
        {
            return true;
        }

        public void DoTest(object execute)
        {


        }

        #endregion commands

        private void SearchEntitiesTask()
        {
            Task task = new Task(GetAll);
            task.Start();
        }

        private void SearchEntitiesThread()
        {
            ThreadInfo threadInfo = new ThreadInfo(10, GetAll, Callback);
            Thread thread = new Thread(new ThreadStart(threadInfo.ThreadProcedure));
            thread.Start();
        }

        private void SearchEntitiesBackgroudWorker()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.ReportProgress(10);
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void SearchEntitiesThreadPool()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetAll), 50);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressValue = e.ProgressPercentage;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            GetProducts(null);
            bw.ReportProgress(50);
            GetEmployees(null);
            bw.ReportProgress(100);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Callback();
        }

        private void Callback()
        {
            View.Dispatcher.Invoke(() => { MessageBox.Show(View, "Completed"); });
        }

        private void GetAll()
        {
            GetAll(null);
        }

        private void GetAll(object obj)
        {
            GetProducts(null);
            GetEmployees(null);
        }

        private void GetProducts(Object percentage)
        {
            //List<ProductEntity> tmp = EntityCommunicator.GetAll<ProductEntity>();
            //tmp.Add(EntityCommunicator.GetById<ProductEntity>(3));
            //tmp.Add(EntityCommunicator.GetById<ProductEntity>(4));
            //Products = tmp;
            //OnPropertyChange(() => Products);

            //ProgressValue = 5;
            //Products = EntityCommunicator.GetAll<ProductEntity>();
            //ProgressValue = 30;
            //Products.Add(EntityCommunicator.GetById<ProductEntity>(3));
            //ProgressValue = 40;
            //Products.Add(EntityCommunicator.GetById<ProductEntity>(4));
            //ProgressValue = 50;
            //OnPropertyChange(() => Products);

            ProgressValue = 5;

            Products = EntityCommunicator.GetAll<ProductEntity>();
            ProgressValue = 20;

            Products.Add(EntityCommunicator.GetById<ProductEntity>(3));
            Products = null;
            ProgressValue = 30;

            Products = new List<ProductEntity>() { EntityCommunicator.GetById<ProductEntity>(4) };
            ProgressValue = 40;

            Products = EntityCommunicator.GetByTemplate<ProductEntity>(new ProductEntity() { ProductType="Product type 1" });
            ProgressValue = 50;
        }
        private void GetEmployees(Object percentage)
        {
            Employees = EntityCommunicator.GetByTemplate<EmployeeEntity>(new EmployeeEntity() { Description = "admin" });
            ProgressValue = 80;
            Employees.Add(EntityCommunicator.GetById<EmployeeEntity>(2));
            ProgressValue = 90;
            Employees.Add(EntityCommunicator.GetById<EmployeeEntity>(3));
            ProgressValue = 100;
            OnPropertyChange(() => Employees);
        }
    }
}
