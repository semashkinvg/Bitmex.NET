using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Annotations;
using Bitmex.NET.Models;
using Prism.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bitmex.NET.Example
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly IBitmexAuthorization _bitmexAuthorization;
		private readonly IBitmexApiService _bitmexApiService;
		private int _size;
		private string _key;
		private string _secret;

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

		public event PropertyChangedEventHandler PropertyChanged;

		public MainWindowViewModel()
		{
			_bitmexAuthorization = new BitmexAuthorization() { BitmexEnvironment = BitmexEnvironment.Test };
			_bitmexApiService = BitmexApiService.CreateDefaultApi(_bitmexAuthorization);
			BuyCmd = new DelegateCommand(Buy);
			SellCmd = new DelegateCommand(Sell);
			Size = 1;
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
