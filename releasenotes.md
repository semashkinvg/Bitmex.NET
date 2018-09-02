# Release Notes
## 2.0.64.0
added events on close and error
got rid of usage of obsolete method in tests

## 2.0.58.0
ignored quote test (Because /Quote endpoint doesn't work know issue #16)
add resp API for stats, user, leaderboard
enhanced error handling (handling of HTML response)

## 2.0.43.0
added handling actions
added order book L2 handling docs
OrderBookSocketDto renamed to OrderBook10Dto (for orderBook10 web socket subscription)

## 2.0.41.0
fixed issue ![#5](https://github.com/semashkinvg/Bitmex.NET/issues/5)
added logging. Please check out ![readme](https://github.com/semashkinvg/Bitmex.NET#Logging)

## 2.0.39.0
fixed bug #7
added Bitmex WebSocket Limit Reached Exception. For the time being the limit provided by Bitmex is 20. It's not hardcoded value, the current framework takes it from WebSocket welcome message.

## 2.0.30.0
Fixed authentication issues. Currently, nonce became in seconds rather than in milliseconds, according to the official reference

## 2.0.2.*

WEBSOCKET subscription available!! (See [Example](https://github.com/semashkinvg/Bitmex.NET/tree/master/Bitmex.NET.Example) project or [BitmexApiSocketService*Tests.cs](https://github.com/semashkinvg/Bitmex.NET/blob/master/Bitmex.NET.IntegrationTests/Tests/))

Fixed issues #3 #4

## 1.0.3
fixed bug #2 (the types of sums and quantities are chaned to decimal)
added WebSocket nuget packge dependency for future changes

## 1.0.2
fixed bug #1

## 1.0.1
Added the follow APIs

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


## 1.0.0
Initial release with the following methods implemented and covered with the integration tests


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
