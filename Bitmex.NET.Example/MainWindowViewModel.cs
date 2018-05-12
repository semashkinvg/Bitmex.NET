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

namespace Bitmex.NET.Example
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly IBitmexAuthorization _bitmexAuthorization;
		private readonly IBitmexApiService _bitmexApiService;
		private readonly IBitmexApiSocketService _bitmexApiSocketService;
		private readonly object _syncObj = new object();
		private int _size;
		private string _key;
		private string _secret;

		public ObservableCollection<InstrumentModel> Instruments { get; }
		public string Secret
		{
			get { return _secret; }
			set
			{
				_secret = value;
				OnPropertyChanged();
				_bitmexAuthorization.Secret = _secret;
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

		public ICommand BuyCmd { get; }
		public ICommand SellCmd { get; }
		public ICommand StartLoadSymbolsCmd { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindowViewModel()
		{
			_bitmexAuthorization = new BitmexAuthorization { BitmexEnvironment = BitmexEnvironment.Test };
			_bitmexApiService = BitmexApiService.CreateDefaultApi(_bitmexAuthorization);
			_bitmexApiSocketService = BitmexApiSocketService.CreateDefaultApi(_bitmexAuthorization);
			BuyCmd = new DelegateCommand(Buy);
			SellCmd = new DelegateCommand(Sell);
			StartLoadSymbolsCmd = new DelegateCommand(StartLoad);
			Size = 1;
			Instruments = new ObservableCollection<InstrumentModel>();
			BindingOperations.EnableCollectionSynchronization(Instruments, _syncObj);
		}

		private void StartLoad()
		{
			var result = _bitmexApiSocketService.Connect();
			_bitmexApiSocketService.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<InstrumentDto>>.Create(SubscriptionType.instrument,
				dtos =>
				{
					foreach (var instrumentDto in dtos)
					{
						var existing = Instruments.FirstOrDefault(a => a.Symbol == instrumentDto.Symbol);
						if (existing != null)
						{
							Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto, existing);
						}
						else
						{
							lock (_syncObj)
							{
								Instruments.Add(Mapper.Map<InstrumentDto, InstrumentModel>(instrumentDto));
							}
						}
					}
				}));
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
