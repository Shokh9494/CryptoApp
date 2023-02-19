using CryptoAppXamarin.Common.Base;
using CryptoAppXamarin.Common.Controllers;
using CryptoAppXamarin.Common.Modals;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CryptoAppXamarin.Models.Wallet
{
    public class WalletViewModel : BaseViewModel
    {
        //Charts
        private Chart _portfolioView;
        public Chart PortfolioView
        {
            get => _portfolioView;
            set { SetProperty(ref _portfolioView, value); }
        }

        //Coins
        private int _coinsHeight;
        public int CoinsHeight
        {
            get => _coinsHeight;
            set { SetProperty(ref _coinsHeight, value); }
        }
        private ObservableCollection<Coin> _assets;
        public ObservableCollection<Coin> Assets
        {
            get => _assets;
            set
            {
                SetProperty(ref _assets, value);
                if (_assets is null)
                {
                    return;
                }
                CoinsHeight = _assets.Count * 85;
            }
        }

        //Transactions
        private int _transactionHeight;
        public int TransactionHeight
        {
            get => _transactionHeight;
            set { SetProperty(ref _transactionHeight, value); }
        }
        private ObservableCollection<Transaction> _latestTransacions;
        public ObservableCollection<Transaction> LatestTransactions
        {
            get => _latestTransacions;
            set
            {
                SetProperty(ref _latestTransacions, value);
                if (_latestTransacions is null)
                {
                    return;
                }
                HasTransactions = _latestTransacions.Count > 0;
                if (_latestTransacions.Count == 0)
                {
                    TransactionHeight = 430;
                    return;
                }
                TransactionHeight = _latestTransacions.Count * 85;
            }
        }



        private IWalletController _walletController;
        public WalletViewModel(IWalletController walletController)
        {
            _walletController = walletController;
        }

        public ICommand AddNewTransactionCommand { get => new Command(async () => await AddNewTransaction()); }

        private Task AddNewTransaction()
        {
            throw new NotImplementedException();
        }

        public override async Task InitializeAsync(object parameter)
        {
            bool reload=(bool)parameter;
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            IsRefreshing= true;
            var transactions = await _walletController.GetTransactions(reload);
            LatestTransactions=new ObservableCollection<Transaction>(transactions.Take(3));

            var assets = await _walletController.GetCoins(reload);
            Assets=new ObservableCollection<Coin>(assets.Take(3));
            BuildChatt(assets);
            PortfolioValue = assets.Sum(x => x.DollarValue);

            IsRefreshing= false;
            IsBusy = false;
        }

        private void BuildChatt(List<Coin> assets)
        {
            var whiteColor = SKColor.Parse("#ffffff");
            List<ChartEntry> entries = new List<ChartEntry>();
            var color = Coin.GetAvailableAssets();
            foreach (var item in assets)
            {
                entries.Add(new ChartEntry((float)item.DollarValue)
                {
                    TextColor = whiteColor,
                    ValueLabel = item.Name,
                    Color = SKColor.Parse(color.First(x => x.Symbol == item.Symbol).HexColor)
                });
            }
            var chart = new DonutChart { Entries = entries };
            chart.BackgroundColor = whiteColor;
            PortfolioView = chart;
        }

        private bool _hasTransactions;
        public bool HasTransactions
        {
            get => _hasTransactions;
            set { SetProperty(ref _hasTransactions, value); }
        }
        private decimal _portfolioValue;
        public decimal PortfolioValue
        {
            get => _portfolioValue;
            set { SetProperty(ref _portfolioValue, value); }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value); }
        }

        public ICommand RefreshAssetsCommand { get=>new Command(async ()=>await InitializeAsync(true)); }


    }
}
