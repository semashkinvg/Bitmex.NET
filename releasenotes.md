# Release Notes

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
