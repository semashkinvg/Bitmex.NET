
The first message within the subscription for each currency pair contains the maximum depth of the order book. Action equals `Partial` in this case. It's recommended push the data into some list.
The next steps are pretty straightforward: depends on the action (`Insert`, `Update`  And `Delete`) make appropriate changes for each item.
Check out full ![example](https://github.com/semashkinvg/Bitmex.NET/blob/master/Bitmex.NET.Example/MainWindowViewModel.cs)

```
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
}
```

`Update` action is quite interesting. Most of the properties can be NULL or default, so it worth updating only the props that have some values. See below, how to handle the case with ![AutoMapper](https://github.com/AutoMapper/AutoMapper) (.Condition)

```
CreateMap<OrderBookDto, OrderBookModel>()
	.ForMember(a => a.Price, a => a.MapFrom(b => b.Price))
	.ForMember(a => a.Price, a => a.Condition(b => b.Price != 0))
	.ForMember(a => a.Size, a => a.MapFrom(b => b.Size))
	.ForMember(a => a.Price, a => a.Condition(b => b.Size != 0))
	.ForMember(a => a.Direction, a => a.MapFrom(b => b.Side))
	.ForMember(a => a.Id, a => a.MapFrom(b => b.Id));
```