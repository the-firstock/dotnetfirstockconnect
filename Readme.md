# thefirstock

thefirstock is a C# library for calling firstock apis. 
Please visit [firstock documentation website](https://connect.thefirstock.com/) for further documentation.

## Installation

Use the package manager [nuget](https://www.nuget.org/) to install thefirstock.

```bash
dotnet add package thefirstock  
```

## Login

Firstock APIs allow the user authentication using the Login API. A valid Firstock Trading Account and subscription to Firstock API Services is a pre-requisite for successful authentication.

To use this Firstock API, you need an API key. Please login to your Firstock API module to get your own API Key

The login flow is as follows:

1. Navigate to the Login API endpoint: [login](https://connect.thefirstock.com/api/login)
2. After successful login, user is redirected to the redirect uri with the auth_code 
3. POST the auth_code and appIdHash (SHA-256 of api_id + app_secret) to Validate Authcode API endpoint 
4. Obtain the access_token use that for all the subsequent requests 

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.login(
            userId: "",
            password: "",
            DOBnPAN: "",
            vendorCode: "",
            apikey: ""
            );
    }
}
```

## Logout

The API session is destroyed by this call and it invalidates the access_token. The user will be sent through a new login flow after this.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var logout = firstock.logout();
    }
}
```

## User Details

This allows to fetch the complete information of the logged in user.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var userDetails = firstock.getUserDetails();
    }
}
```

## Place Order

The place order APIs allow you to place your orders in our system.

You will get the order confirmation instantly with order_id.

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.placeOrder(
            exchange: "NSE",
            tradingSymbol: "ITC-EQ",
            quantity: "1",
            price: "240",
            product: "C",
            transactionType: "B",
            priceType: "LMT",
            retention: "DAY",
            triggerPrice: "",
            remarks: "Strategy1");
    }
}

```

## Order Margin

You can view the margin requirement for the selected order before placing the order.
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.orderMargin(
            exchange: "NSE",
            tradingSymbol: "ITC-EQ",
            quantity: "10",
            price: "260",
            product: "C",
            transactionType: "B",
            priceType: "LMT"
          );
    }
}
```

## Order Book

When an order is placed, the status of the order can be viewed in the order book (Open, Executed, canceled, rejected)

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.orderBook();
    }
}
```

## Cancel Order

As long as an order is open or pending in the system, it can be canceled.

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.cancelOrder(norenordno: "");
    }
}
```

## Modify Order

As long as an order is open or pending in the system, certain attributes of it may be modified.
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.modifyOrder(
            norenordno: "22060400000811",
            price: "240",
            quantity: "1",
            triggerPrice: "265",
            tradingSymbol: "ITC-EQ",
            exchange: "",
            priceType: "LMT"
            );
    }
}
```

## Single Order History

Successful placement of an order via the API does not imply its successful execution. To know the true status of a placed order, you should retrieve the particular order's current status using its order_id.

```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.singleOrderHistory(norenordno: "");
    }

}
```

## Trade Book

It provides the executed trades details for the current trading day.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.tradeBook();
    }
}
```

## Positions Book

The positions book contains the user's portfolio of short to medium-term derivatives (futures and options contracts) and intraday equity stocks. Instruments in the position’s portfolio remain there until they're sold, or until expiry. Equity positions carried overnight moves to the holding’s portfolio the next day.

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.positionBook();
    }
}
```

## Product Conversion

Position conversion is the process of converting the Intraday position to overnight and the overnight position to Intraday
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.productConversion(
           exchange: "NFO",
           tradingSymbol: "BANKNIFTY28APR22C37400",
           quantity: "250",
           product: "I",
           previousProduct: "M",
           transactionType: "B",
           positionType: "CF"
            );
    }
}
```

## Holdings

Holdings contain long and short-term equity delivery stocks. You will be able to see Demat Holdings, Collateral Holding, and Unsettled holding which is supposed to get delivered from the exchange.
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.holdings(product: "I");
    }
}
```

## Limits

Limits contain all the details about cash available, margin used, collateral margin, pay in for the day, etc.
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.limits();
    }
}
```

## Get Quotes

The market quotes APIs enable you to retrieve market data snapshots of various instruments. These are snapshots gathered from the exchanges at the time of the request. For realtime streaming market quotes, use the WebSocket API.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.getQuotes(exchange: "NSE", token: "26000");
    }
}
```

## Search Scripts

The Search Scripts APIs enable you to search instruments using key words.
```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.searchScripts(stext: "ITC");
    }
}
```

## Get Security Info
The Get SecurityInfo APIs enable you to get comliate information about the instruments .

```C#
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.getSecurityInfo(exchange: "NSE", token: "22");
    }
}
```

## Get Index List

The Get Index List APIs enable you to find all index name and sript code for getting index value.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.getIndexList(exchange: "NSE");
    }
}
```

## Get Option Chain

The Get Option Chain APIs enable you to find all option scrip code for the underlaying instrument.

using scrip code you can subscribe for websocket data
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock();
        var result = firstock.getOptionChain(exchange: "NFO", tradingSymbol: "BANKNIFTY28APR22C37400", strikePrice: "37400", count: "5");
    }
}
```

## Span Calculator

The Span Calculator APIs enable you to calculate margin requirement for the portfolio before placing order.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock(); 
        var result = firstock.spanCalculator(
            exchange: "NFO",
            instname: "OPTIDX",
            symbolName: "BANKNIFTY",
            expd: "",
            optt: "CE",
            strikePrice: "",
            netQuantity: "",
            buyQuantity: "",
            sellQuantity: "",
            product: "M");
    }
}
```

## Time Price Series
The Get Time Price Data APIs enable you to get chart data for analysis.
```C# 
using thefirstock;

class Program
{
    public static void Main()
    {
        Firstock firstock = new Firstock(); 
        var result = firstock.timePriceSeries(
            exchange: "NSE",
            token: "22",
            endTime: "02/08/2022 15:30:08",
            startTime: "05/07/2022 10:30:08"
          );
    }
}
```
## WebSockets

## General Guidelines
The WebSocket API uses WebSocket protocol to establish a single long standing TCP connection after an HTTP handshake to receive streaming quotes. The WebSocket API is the most efficient way to receive quotes for instruments across all exchanges during live market hours.

In addition to market data, alerts, and order updates are also streamed. To connect to the Firstock WebSocket API, you will need a WebSocket client library in your choice of programming language.

Connect to 
```
wss://norenapi.thefirstock.com/NorenWSTP/
```

Keep It in Mind

(1) As soon as connection is done, a connection request should be sent with User id and login session id.  

(2) All input and output messages will be in json format.  

## Subscribe Touchline

Websocket TouchLine subscription API will provide multiple instruments available actions and possible values at once.
```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.subscribeTouchline("NSE|26000#NSE|26009#NSE|26017"))
}); 
```

## Unsubscribe Touchline

```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.unsubscribeTouchline("NSE|26000#NSE|26009#NSE|26017"))
}); 
```

## Subscribe Order Update

Websocket Order Status API will function in providing order status updates through websocket server connection and provide Order responses similar to the one received in Postback/Webhook.
```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.subscribeOrderUpdate("#actid" //Replace with actid))
});  
```

## Unsubscribe Order Update

```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.unsubscribeOrderUpdate())
});  
```

## Subscribe Depth

Websocket Subscribe Depth API will provide multiple instruments market information at once.(5 Depth,high, low, close, etc..)
```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.subscribeDepth("NSE|26000#NSE|26009#NSE|26017"))
});  
```

## Unsubscribe Depth

```C# 
const Firstock = require('thefirstock');
const firstock = new Firstock();


const ws = firstock.initializeWebSocket();

ws.on('open', function open() {
    firstock.getWebSocketDetails((err, result) => {
        if (!err) {
            ws.send(result)
        }
    })
});

ws.on("error", function error(error) {
    console.log(`WebSocket error: ${error}`)
})

ws.on('message', function message(data) {
    const result = firstock.receiveWebSocketDetails(data)
    console.log('Result: ', result)
    ws.send(firstock.unsubscribeDepth("NSE|26000#NSE|26009#NSE|26017"))
});  
```




## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
