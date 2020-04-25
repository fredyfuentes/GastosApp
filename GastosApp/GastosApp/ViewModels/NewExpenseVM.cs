using GastosApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace GastosApp.ViewModels
{
    public class NewExpenseVM : INotifyPropertyChanged
    {
        private string expenseName;
        public string ExpenseName
        {
            get => expenseName;
            set
            {
                expenseName = value;
                OnPropertyChanged();
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get => expenseDescription;
            set
            {
                expenseDescription = value;
                OnPropertyChanged();
            }
        }

        private float expenseAmmount;
        public float ExpenseAmmount 
        {
            get => expenseAmmount;
            set
            {
                expenseAmmount = value;
                OnPropertyChanged();
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate 
        {
            get => expenseDate;
            set
            {
                expenseDate = value;
                OnPropertyChanged();
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get => expenseCategory;
            set
            {
                expenseCategory = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SaveExpenseCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }        
        
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            var vm = this;
            Expense expense = new Expense()
            {
                Name = expenseName,
                Ammount = expenseAmmount,
                Category = expenseCategory,
                Date = expenseDate,
                Description = expenseDescription
            };

            int response = Expense.InsertExpense(expense);
            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserter", "Ok");
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random",
                Status = false
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}
