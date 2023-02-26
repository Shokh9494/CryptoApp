using CryptoAppXamarin.Common.Base;
using CryptoAppXamarin.Common.Controllers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CryptoAppXamarin.Common.Modals;
using System.Windows.Input;
using Xamarin.Forms;

namespace CryptoAppXamarin.Models.AddTransaction
{
    class TransactionViewModel :BaseViewModel
    {
        private IWalletController _walletController;

        public TransactionViewModel(IWalletController walletController)
        {
            _walletController = walletController;
            Transactions =new ObservableCollection<Transaction>();
        }
        public override async Task InitializeAsync(object parameter)
        {
            IsRefreshing= true;  
            var transaction = await _walletController.GetTransactions();
            Transactions = new ObservableCollection<Transaction>(transaction);
            IsRefreshing= false;
        }

        private ObservableCollection<Transaction> _transaction;
        public ObservableCollection<Transaction> Transactions
        {
            get { return _transaction; }
            set { SetProperty(ref _transaction, value); }
        }
        public ICommand RefreshTransactionCommand { get => new Command(async () => await RefreshTransaction()); }

        private async Task RefreshTransaction()
        {
          await  InitializeAsync(null);
        }

        private Transaction _selectedTransaction;
        public Transaction  SelectedTransaction
        {
            get { return _selectedTransaction; }
            set { SetProperty(ref _selectedTransaction, value); }
        }

        public ICommand TransactionSelectCommand { get => new Command(async () => await TransactionSelect()); }

        private async Task TransactionSelect()
        {
            
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value); }
        }
    }
}
