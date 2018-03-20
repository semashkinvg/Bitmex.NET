# Bitmex.NET
Wrapper for BitMEX.com REST API

## Quick Start

Install NuGet package

Create default API service:

First approach, creating default instance
```
var bitmexAuthorization = new BitmexAuthorization() 
{
  BitmexEnvironment = Bitmex.NET.Models.BitmexEnvironment.Test,
  Key = "your api key",
  Secret = "your api secret"
};
var bitmexApiService = BitmexApiService.CreateDefaultApi(bitmexAuthorization);
```

Another, registering in a DI container (e.g. Unity)
```
Container.RegisterType<IBitmexApiProxy, BitmexApiProxy>();
Container.RegisterType<IBitmexApiService, BitmexApiService>();

var authorization = new BitmexAuthorization
{
  BitmexEnvironment = Bitmex.NET.Models.BitmexEnvironment.Test,
  Key = "your api key",
  Secret = "your api secret"
};

Container.RegisterInstance<IBitmexAuthorization>(authorization);
```

place an order:
```
private async void Sell()
{
  var posOrderParams = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", Size, OrderSide.Sell);
  await _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
}
```

## Extensibility
I haven't implemented and tested all the existing methods yet so that you might want to call BitMEX APIs that haven't been done so far. To make you be able to call all APIs using the existing service I've tried to make the classes extensible.
So...
To implement your own API method please create your own parameters class (or use existing) deriving it from `QueryStringParams` (for GET requests) or `JsonQueryParams`(for POST/PUT/DELETE requests) and a class for requests (or use existing)

```
private class SomeQueryStringParams : QueryStringParams
{
  [DisplayName("val")]
  public string Value { get; set; }
}

private class SomeJsonParams : QueryJsonParams
{
  [JsonProperty("symbol")]
  public string Symbol { get; set; }
}

private class AResult
{
  [JsonProperty("value")]
  public string Value { get; set; }
}
```
Call it
```
var result = await bitmexApiService.Execute(new ApiActionAttributes<SomeJsonParams, AResult>("anApiMethod", HttpMethods.POST), new SomeJsonParams(){Symbol = "XBTUSD"});

// if the method returns an array of objects
var result = await bitmexApiService.Execute(new ApiActionAttributes<SomeJsonParams, List<AResult>>("anApiMethod", HttpMethods.POST), new SomeJsonParams(){Symbol = "XBTUSD"});
```


## Progress
The following methods were implemented and covered with integration tests


Method|REST API Method
------------|------------
GET |order
PUT |order
POST |order
DELETE |order
DELETE |order/all
PUT |order/bulk
POST |order/bulk
POST |order/cancelAllAfter
POST |order/closePosition
GET |orderBook/L2|yes
GET |position|yes
POST |position/isolate
POST |position/leverage
POST |position/riskLimit
POST |position/transferMargin
GET |quote
GET |quote/bucketed
GET |trade
GET |trade/bucketed
