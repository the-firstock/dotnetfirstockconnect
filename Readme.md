# The Firstock Connect API C# client - v3

To communicate with the Firstock Connect API using C#, you can use the official C# client library provided by Firstock.
<br /> Licensed under the MIT License.

## Documentation

- C# client documentation

## v3 - Changes

- Error code response structured has been changed
- Renamed

## Installing the client

Use the package manager [nuget](https://www.nuget.org/) to install thefirstock.

```bash
dotnet add package thefirstock
```

## API usage

```C#
using thefirstock;

class Program
{
public static void Main()
{
    Firstock firstock = new Firstock();
    """ Login using firstock account"""
    Firstock firstock = new Firstock();
    var result = firstock.login(
        userId: "",
        password: "",
        TOTP: "",
        vendorCode: "",
        apikey: ""
        );
    """Place an order"""
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
    """Fetch single order deatils"""
    var result = firstock.singleOrderHistory(orderNumber: "");
    """Order book"""
    var result = firstock.orderBook();
    """Cancel order"""
    var result = firstock.cancelOrder(orderNumber: "");
    """Historical data"""
    var result = firstock.timePriceSeries(
        exchange: "NSE",
        token: "22",
        endTime: "02/08/2022 15:30:08",
        startTime: "05/07/2022 10:30:08",
        intrv:"3"
      );
}
}
```

Refer to the [Firstock Connect Documentation](https://connect.thefirstock.com/)  for the complete list of supported methods.

## WebSocket usage

```C#
using thefirstock;

class Program
{
public static void Main()
{
//// Initializer ///
var exitEvent = new ManualResetEvent(false);
using (var client = firstock.initializeWebSocket())
{
    /// Establishment of connection for required symbol //
        client.MessageReceived.Subscribe(msg =>
        {
            /////Prints the message successfully////
            Console.WriteLine("Message received: " + msg);
            client.Send(firstock.subscribeTouchline("NSE|26000"));// Subscribe to NIFTY
            client.Send(firstock.subscribeTouchline("NSE|26009"));// Subscribe to BANKNIFTY
        });

        client.Start();
        client.Send(firstock.startWebsockets());
        exitEvent.WaitOne();
}
}
}
```

## Changelog

Check release notes.
