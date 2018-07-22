using Bitmex.NET.Example.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bitmex.NET.Example.Models
{
    public class OrderBookModel : INotifyPropertyChanged
    {
        private string _direction;
        private decimal _size;
        private decimal? _price;
        private long _id;

        public long Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public decimal? Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public decimal Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        public string Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
