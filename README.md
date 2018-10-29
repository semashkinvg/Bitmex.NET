# Bitmex.NET [![Build Status](https://ci.appveyor.com/api/projects/status/32r7s2skrgm9ubva?svg=true)](https://ci.appveyor.com/project/semashkinvg/bitmex-net) [![NuGet](https://img.shields.io/nuget/v/Bitmex.NET.svg)](https://www.nuget.org/packages/Bitmex.NET/) [![Join the chat at https://gitter.im/Bitmex-Net](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Bitmex-Net?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Wrapper for BitMEX.com REST API

## Issue reporting
Feel free to report any bugs/issues you may find in the framework. It's all much appreciated!

## Quick Start

Install NuGet package `Install-Package Bitmex.NET`

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

Another, registering in a DI container (e.g. Unity). ![Example](/Bitmex.NET.IntegrationTests/BitmexNetUnityExtension.cs)
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
place an order ![Example](/Bitmex.NET.Example/MainWindowViewModel.cs):
```
private async void Sell()
{
  var posOrderParams = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", Size, OrderSide.Sell);
  await _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, posOrderParams).ContinueWith(ProcessPostOrderResult);
}
```

## Logging
The current lib uses ![LibLog](https://github.com/damianh/LibLog) to provide comprehensive logging for the most popular logging frameworks. Setting Debug logging level in your solution will bring about huge logging output because all the HTTP responses and WebSocket messages will be logged. I would recommend you yo forward the debug level logging from the lib into a separate file, but it's always up to you

```
  <targets>
    <target xsi:type="File" name="f" fileName="${basedir}/logs/${shortdate}.log"
            layout="${longdate} ${uppercase:${level}} ${message}" />
    <target xsi:type="File" name="bitmexDebug" fileName="${basedir}/logs/${shortdate}bitmexDebug.log"
            layout="${longdate} ${uppercase:${level}} ${message}" />
  </targets>

  <rules>
    <logger name="*" minlevel="Info" writeTo="f" />
    <logger name="Bitmex.NET.*" minlevel="Debug" writeTo="bitmexDebug" />
  </rules>
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
The following methods were implemented and covered with the ![integration tests](/Bitmex.NET.IntegrationTests)


Method|REST API Method
------------|------------
GET|execution
GET|execution/tradeHistory
GET|instrument
GET|instrument/active
GET|instrument/activeAndIndices
GET|instrument/activeIntervals
GET|instrument/compositeIndex
GET|instrument/indices
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


## Docs
Please checkout ![the following documents](/docs). During the time I will be adding solutions, best practices, life examples and some other information with peculiarities about Bitmex

## Examples

Please see example of simple Buy&Sell application ![here](/Bitmex.NET.Example)

### Integration Tests

You will find a live example for all the implemented APIs within integration tests project ![here](/Bitmex.NET.IntegrationTests)

## Other

API was taken from ![testnet.bitmex.com](https://testnet.bitmex.com/api/explorer/)
