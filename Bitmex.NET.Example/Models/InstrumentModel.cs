using Prism.Mvvm;

namespace Bitmex.NET.Example.Models
{
	public class InstrumentModel : BindableBase
	{
		private string _symbol;
		private string _rootSymbol;
		private string _state;
		private string _typ;
		private decimal? _highPrice;
		private decimal? _lowPrice;
		private decimal? _lastPrice;
		private decimal? _lastChangePcnt;

		public string Symbol
		{
			get { return _symbol; }
			set { SetProperty(ref _symbol, value); }
		}

		public string RootSymbol
		{
			get { return _rootSymbol; }
			set { SetProperty(ref _rootSymbol, value); }
		}

		public string State
		{
			get { return _state; }
			set { SetProperty(ref _state, value); }
		}

		public string Typ
		{
			get { return _typ; }
			set { SetProperty(ref _typ, value); }
		}

		public decimal? HighPrice
		{
			get { return _highPrice; }
			set { SetProperty(ref _highPrice, value); }
		}

		public decimal? LowPrice
		{
			get { return _lowPrice; }
			set { SetProperty(ref _lowPrice, value); }
		}

		public decimal? LastPrice
		{
			get { return _lastPrice; }
			set { SetProperty(ref _lastPrice, value); }
		}

		public decimal? LastChangePcnt
		{
			get { return _lastChangePcnt; }
			set { SetProperty(ref _lastChangePcnt, value); }
		}
	}
}
