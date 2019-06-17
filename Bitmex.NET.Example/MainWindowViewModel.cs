using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Example.Annotations;
using Bitmex.NET.Example.Models;
using Bitmex.NET.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Bitmex.NET.Example
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IBitmexApiSocketService _bitmexApiSocketService;
        private readonly object _syncObj = new object();
        private readonly object _syncObjOrders = new object();
        private readonly object _syncObjOrderBook10 = new object();
        private readonly object _syncObjOrderBookL2 = new object();
        private int _size;
        private string _key;
        private string _secret;
        private bool _isConnected;

        public ObservableCollection<InstrumentModel> Instruments { get; }
        public ObservableCollection<OrderUpdateModel> OrderUpdates { get; }
        public ObservableCollection<OrderBookModel> OrderBookL2 { get; }
        public List<OrderBookModel> OrderBook10 { get; private set; }

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
            _bitmexApiSocketService = BitmexApiSocketService.CreateDefaultApi(_bitmexAuthorization);
            BuyCmd = new DelegateCommand(Buy);
            SellCmd = new DelegateCommand(Sell);
            StartLoadSymbolsCmd = new DelegateCommand(StartLoad, CanStart);
            Size = 1;
            Instruments = new ObservableCollection<InstrumentModel>();
            OrderUpdates = new ObservableCollection<OrderUpdateModel>();
            OrderBookL2 = new ObservableCollection<OrderBookModel>();
            BindingOperations.EnableCollectionSynchronization(Instruments, _syncObj);
            BindingOperations.EnableCollectionSynchronization(OrderUpdates, _syncObjOrders);
            BindingOperations.EnableCollectionSynchronization(OrderBookL2, _syncObjOrderBookL2);
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
                _bitmexApiSocketService.Subscribe(BitmetSocketSubscriptions.CreateInstrumentSubsription(
                    message =>
                    {
                        foreach (var instrumentDto in message.Data)
                        {
                            lock (_syncObj)
                            {
                                var existing = Instruments.FirstOrDefault(a => a.Symbol == instrumentDto.Symbol);
                                if (existing != null && message.Action == BitmexActions.Update)
                                {
                                    Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto, existing);
                                }
                                else if (message.Action != BitmexActions.Partial && message.Action != BitmexActions.Delete)
                                {
                                    Instruments.Add(Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto));
                                }
                            }
                        }
                    }));

                _bitmexApiSocketService.Subscribe(BitmetSocketSubscriptions.CreateOrderSubsription(
                    message =>
                    {
                        foreach (var order in message.Data)
                        {
                            lock (_syncObjOrders)
                            {
                                var existing = OrderUpdates.FirstOrDefault(a => a.OrderId == order.OrderId);
                                if (existing != null && message.Action == BitmexActions.Update)
                                {
                                    Mapper.Map<OrderDto, OrderUpdateModel>(order, existing);
                                }
                                else if (message.Action != BitmexActions.Partial && message.Action != BitmexActions.Delete)
                                {
                                    OrderUpdates.Add(Mapper.Map<OrderDto, OrderUpdateModel>(order));
                                }
                            }

                            OnPropertyChanged(nameof(OrderUpdates));
                        }
                    }));

                _bitmexApiSocketService.Subscribe(BitmetSocketSubscriptions.CreateOrderBook10Subsription(
                    message =>
                    {
                        foreach (var dto in message.Data)
                        {
                            if (dto.Symbol != "XBTUSD")
                            {
                                continue;
                            }

                            lock (_syncObjOrderBook10)
                            {
                                OrderBook10 = dto.Asks.Select(a =>
                                    new OrderBookModel { Direction = "Sell", Price = a[0], Size = a[1] })
                                    .Union(dto.Asks.Select(a =>
                                        new OrderBookModel { Direction = "Buy", Price = a[0], Size = a[1] })).ToList();
                            }

                            OnPropertyChanged(nameof(OrderBook10));
                        }
                    }));

                _bitmexApiSocketService.Subscribe(BitmetSocketSubscriptions.CreateOrderBookL2Subsription(
                    message =>
                    {
                        foreach (var dto in message.Data)
                        {
                            if (dto.Symbol != "XBTUSD")
                            {
                                continue;
                            }

                            lock (_syncObjOrderBookL2)
                            {
                                if (message.Action == BitmexActions.Insert || message.Action == BitmexActions.Partial)
                                {
                                    OrderBookL2.Add(Mapper.Map<OrderBookDto, OrderBookModel>(dto));
                                }
                                if (message.Action == BitmexActions.Delete)
                                {
                                    var existing = OrderBookL2.FirstOrDefault(a => a.Id == dto.Id);
                                    if (existing != null)
                                    {
                                        OrderBookL2.Remove(existing);
                                    }
                                }

                                if (message.Action == BitmexActions.Update)
                                {
                                    var existing = OrderBookL2.FirstOrDefault(a => a.Id == dto.Id);
                                    if (existing == null)
                                    {
                                        OrderBookL2.Add(Mapper.Map<OrderBookDto, OrderBookModel>(dto));
                                    }
                                    else
                                    {
                                        Mapper.Map<OrderBookDto, OrderBookModel>(dto, existing);
                                    }


                                }
                            }

                            OnPropertyChanged(nameof(OrderBook10));

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
            var bitmexApiService = BitmexApiService.CreateDefaultApi(_bitmexAuthorization);
            await bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
        }

        private async void Buy()
        {
            var posOrderParams = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", Size, OrderSide.Buy);
            var bitmexApiService = BitmexApiService.CreateDefaultApi(_bitmexAuthorization);
            await bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
        }

        private void ProcessPostOrderResult(Task<BitmexApiResult<OrderDto>> task)
        {
            if (task.Exception != null)
            {
                MessageBox.Show((task.Exception.InnerException ?? task.Exception).Message);
            }
            else
            {
                MessageBox.Show($"order has been placed with Id {task.Result.Result.OrderId}");
            }
        }
    }
}
