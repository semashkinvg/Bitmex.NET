using System;
using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Annotations;
using Bitmex.NET.Example.Models;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Unity.Interception.Utilities;

namespace Bitmex.NET.Example
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IBitmexApiService _bitmexApiService;
        private readonly IBitmexApiSocketService _bitmexApiSocketService;
        private readonly object _syncObj = new object();
        private readonly object _syncObjOrders = new object();
        private int _size;
        private string _key;
        private string _secret;
        private bool _isConnected;

        public ObservableCollection<InstrumentModel> Instruments { get; }
        public ObservableCollection<OrderUpdateModel> OrderUpdates { get; }
        public string Secret
        {
            get { return _secret; }
            set
            {
                _secret = value;
                OnPropertyChanged();
                _bitmexAuthorization.Secret = _secret;
                StartLoadSymbolsCmd.RaiseCanExecuteChanged();
            }
        }

        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged();
                _bitmexAuthorization.Key = _key;
                StartLoadSymbolsCmd.RaiseCanExecuteChanged();
            }
        }

        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotConnected));
            }
        }

        public bool IsNotConnected => !IsConnected;

        public ICommand BuyCmd { get; }
        public ICommand SellCmd { get; }
        public DelegateCommand StartLoadSymbolsCmd { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            _bitmexAuthorization = new BitmexAuthorization { BitmexEnvironment = BitmexEnvironment.Test };
            _bitmexApiService = BitmexApiService.CreateDefaultApi(_bitmexAuthorization);
            _bitmexApiSocketService = BitmexApiSocketService.CreateDefaultApi(_bitmexAuthorization);
            BuyCmd = new DelegateCommand(Buy);
            SellCmd = new DelegateCommand(Sell);
            StartLoadSymbolsCmd = new DelegateCommand(StartLoad, CanStart);
            Size = 1;
            Instruments = new ObservableCollection<InstrumentModel>();
            OrderUpdates = new ObservableCollection<OrderUpdateModel>();
            BindingOperations.EnableCollectionSynchronization(Instruments, _syncObj);
            BindingOperations.EnableCollectionSynchronization(OrderUpdates, _syncObjOrders);
        }

        private bool CanStart()
        {
            return !string.IsNullOrWhiteSpace(Key) && !string.IsNullOrWhiteSpace(Secret);
        }

        private void StartLoad()
        {
            try
            {
                IsConnected = _bitmexApiSocketService.Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (IsConnected)
            {
                _bitmexApiSocketService.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<InstrumentDto>>.Create(SubscriptionType.instrument,
                    dtos =>
                    {
                        foreach (var instrumentDto in dtos)
                        {
                            lock (_syncObj)
                            {
                                var existing = Instruments.FirstOrDefault(a => a.Symbol == instrumentDto.Symbol);
                                if (existing != null)
                                {
                                    Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto, existing);
                                }
                                else
                                {
                                    Instruments.Add(Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto));
                                }
                            }
                        }
                    }));

                _bitmexApiSocketService.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<OrderDto>>.Create(SubscriptionType.order,
                    dtos =>
                    {
                        foreach (var order in dtos)
                        {
                            lock (_syncObjOrders)
                            {
                                var existing = OrderUpdates.FirstOrDefault(a => a.OrderId == order.OrderId);
                                if (existing != null)
                                {
                                    Mapper.Map<OrderDto, OrderUpdateModel>(order, existing);
                                }
                                else
                                {
                                    OrderUpdates.Add(Mapper.Map<OrderDto, OrderUpdateModel>(order));
                                }
                            }

                            OnPropertyChanged(nameof(OrderUpdates));
                        }
                    }));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Sell()
        {
            var posOrderParams = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", Size, OrderSide.Sell);
            await _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
        }

        private async void Buy()
        {
            var posOrderParams = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", Size, OrderSide.Buy);
            await _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
        }

        private void ProcessPostOrderResult(Task<OrderDto> task)
        {
            if (task.Exception != null)
            {
                MessageBox.Show((task.Exception.InnerException ?? task.Exception).Message);
            }
            else
            {
                MessageBox.Show($"order has been placed with Id {task.Result.OrderId}");
            }
        }
    }
}
