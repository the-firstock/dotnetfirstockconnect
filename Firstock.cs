using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;
using Websocket.Client;

namespace thefirstock
{


    public class Firstock
    {
        private string token = string.Empty;
        private string userId = string.Empty;
        private string URL = "https://connect.thefirstock.com/api/V3/";
        private string connection = "wss://norenapi.thefirstock.com/NorenWSTP/";

        #region Firstock Methods
        public dynamic login(string userId, string password, string TOTP, string vendorCode, string apiKey)
        {

            dynamic requestBody = new ExpandoObject();

            requestBody.userId = userId;

            requestBody.password = password;

            requestBody.TOTP = TOTP;

            requestBody.vendorCode = vendorCode;

            requestBody.apiKey = apiKey;
            dynamic responseBody = new ExpandoObject();
            var response = CallWebAPIAsync("login", requestBody);
            if (!(response is ExpandoObject))
            {
                dynamic _data = new ExpandoObject();
                _data.token = response.data.susertoken;
                _data.userId = userId;
                WriteDataIntoJson(_data, "config.json");
                responseBody = response;
                //var data = ReadDataFromJson("config.json");
            }

            return responseBody;

        }

        public dynamic logout()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
            };


            var response = CallWebAPIAsync("logout", postObject);
            dynamic empty = new ExpandoObject();
            WriteDataIntoJson(empty, "config.json");
            return response;
        }
        public dynamic getUserDetails()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
            };


            var response = CallWebAPIAsync("userDetails", postObject);
            return response;
        }

        public dynamic placeOrder(
           string exchange,
           string tradingSymbol,
           string quantity,
           string price,
           string product,
           string transactionType,
           string priceType,
           string retention,
           string triggerPrice,
           string remarks
            )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.tradingSymbol = tradingSymbol;
            requestBody.quantity = quantity;
            requestBody.price = price;
            requestBody.product = product;
            requestBody.transactionType = transactionType;
            requestBody.priceType = priceType;
            requestBody.retention = retention;
            requestBody.remarks = remarks;
            requestBody.triggerPrice = triggerPrice;
            var response = CallWebAPIAsync("placeOrder", requestBody);
            return response;

        }
        public dynamic orderMargin(
           string exchange,
           string tradingSymbol,
           string quantity,
           string price,
           string product,
           string transactionType,
           string priceType
            )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.tradingSymbol = tradingSymbol;
            requestBody.quantity = quantity;
            requestBody.price = price;
            requestBody.product = product;
            requestBody.transactionType = transactionType;
            requestBody.priceType = priceType;
            var response = CallWebAPIAsync("orderMargin", requestBody);
            return response;
        }
        public dynamic orderBook()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
            };

            var response = CallWebAPIAsync("orderBook", postObject);
            return response;
        }

        public dynamic cancelOrder(string orderNumber)
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                orderNumber = orderNumber
            };
            var response = CallWebAPIAsync("cancelOrder", postObject);
            return response;
        }

        public dynamic singleOrderHistory(string orderNumber)
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                orderNumber = orderNumber
            };
            var response = CallWebAPIAsync("singleOrderHistory", postObject);
            return response;
        }

        public dynamic tradeBook()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                actid = configData.userId
            };
            var response = CallWebAPIAsync("tradeBook", postObject);
            return response;
        }
        public dynamic positionBook()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                actid = configData.userId
            };
            var response = CallWebAPIAsync("positionBook", postObject);
            return response;
        }
        public dynamic modifyOrder(
           string orderNumber,
           string price,
           string quantity,
           string triggerPrice,
           string tradingSymbol,
           string exchange,
           string priceType
           )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.orderNumber = orderNumber;
            requestBody.tradingSymbol = tradingSymbol;
            requestBody.quantity = quantity;
            requestBody.price = price;
            requestBody.priceType = priceType;
            requestBody.exchange = exchange;
            requestBody.triggerPrice = triggerPrice;
            var response = CallWebAPIAsync("modifyOrder", requestBody);
            return response;
        }
        public dynamic productConversion(
   string exchange,
   string tradingSymbol,
   string quantity,
   string product,
   string transactionType,
   string positionType,
   string previousProduct
   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.tradingSymbol = tradingSymbol;
            requestBody.quantity = quantity;
            requestBody.product = product;
            requestBody.transactionType = transactionType;
            requestBody.positionType = positionType;
            requestBody.previousProduct = previousProduct;
            var response = CallWebAPIAsync("productConversion", requestBody);
            return response;
        }
        public dynamic holdings(
        string product
        )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.product = product;
            var response = CallWebAPIAsync("holdings", requestBody);
            return response;
        }
        public dynamic limits()
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                actid = configData.userId,
                jKey = configData.token,
            };

            var response = CallWebAPIAsync("limit", postObject);
            return response;
        }

        public dynamic basketMargin(
        List<basketMarginObject> basket
   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
           
            requestBody.basket = basket;
            var response = CallWebAPIAsync("basketMargin", requestBody);
            return response;
        }

        public dynamic getQuotes(
          string exchange,
          string token
         )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.token = token;
            var response = CallWebAPIAsync("getQuote", requestBody);
            return response;
        }
        public dynamic searchScripts(
            string stext
         )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.stext = stext;
            var response = CallWebAPIAsync("searchScrips", requestBody);
            return response;
        }
        public dynamic getSecurityInfo(
            string exchange,
            string token
         )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.token = token;
            var response = CallWebAPIAsync("securityInfo", requestBody);
            return response;
        }
        public dynamic getIndexList(
        string exchange
     )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            var response = CallWebAPIAsync("indexList", requestBody);
            return response;
        }

        public dynamic getOptionChain(
        string exchange,
         string tradingSymbol,
         string strikePrice,
         string count
     )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.tradingSymbol = tradingSymbol;
            requestBody.strikePrice = strikePrice;
            requestBody.count = count;
            var response = CallWebAPIAsync("optionChain", requestBody);
            return response;
        }

        public dynamic spanCalculator(
            List<spanCalculatorObject> list

 )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.data = list;

            var response = CallWebAPIAsync("spanCalculators", requestBody);
            return response;
        }

        public dynamic timePriceSeries(
        string exchange,
        string token,
        string endTime,
        string startTime,
        string interval
)
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.token = token;
            requestBody.endTime = endTime;
            requestBody.startTime = startTime;
            requestBody.interval = interval;
            var response = CallWebAPIAsync("timePriceSeries", requestBody);
            return response;
        }

        public dynamic optionGreek(
            string expiryDate,
            string strikePrice,
            string spotPrice,
            string initRate,
            string volatility,
            string optionType
    )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.expiryDate = expiryDate;
            requestBody.strikePrice = strikePrice;
            requestBody.spotPrice = spotPrice;
            requestBody.initRate = initRate;
            requestBody.volatility = volatility;
            requestBody.optionType = optionType;
            var response = CallWebAPIAsync("optionGreek", requestBody);
            return response;
        }

        public dynamic multiPlaceOrder(
          List<multiPlaceOrderObject> data
    )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.data = data;
            var response = CallWebAPIAsync("strategies/multiPlaceOrders", requestBody);
            return response;
        }

        public dynamic bearPutSpread(
            string symbol,
            string putBuyStrikePrice,
            string putSellStrikePrice,
            string expiry,
            string product,
            string quantity,
            string remarks
          
    )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.jKey = configData.token;
            requestBody.symbol = symbol;
            requestBody.putBuyStrikePrice = putBuyStrikePrice;
            requestBody.putSellStrikePrice = putSellStrikePrice;
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
            requestBody.userId = configData.userId;
            var response = CallWebAPIAsync("strategies/bearPutSpread", requestBody);
            return response;
        }

        public dynamic bullCallSpread(
           string symbol,
           string callBuyStrikePrice,
           string callSellStrikePrice,
           string expiry,
           string product,
           string quantity,
           string remarks
      
   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.jKey = configData.token;
            requestBody.symbol = symbol;
            requestBody.callBuyStrikePrice = callBuyStrikePrice;
            requestBody.callSellStrikePrice = callSellStrikePrice;
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
            requestBody.userId = configData.userId;
            var response = CallWebAPIAsync("strategies/bullCallSpread", requestBody);
            return response;
        }

        public dynamic longStraddle(
           string symbol,
           string strikePrice,
           //string callSellStrikePrice,
           string expiry,
           string product,
           string quantity,
           string remarks

   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.symbol = symbol;
            requestBody.strikePrice = strikePrice;
            //requestBody.callSellStrikePrice = callSellStrikePrice;
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            var response = CallWebAPIAsync("strategies/longStraddle", requestBody);
            return response;
        }

        public dynamic shortStraddle(
           string symbol,
           string strikePrice,
           //string callSellStrikePrice,
           string expiry,
           string product,
           string quantity,
           string remarks,
           int hedgeValue,
           Boolean hedge

   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.jKey = configData.token;
            requestBody.userId = configData.userId;
            requestBody.symbol = symbol;
            requestBody.strikePrice = strikePrice;
           
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
            requestBody.hedgeValue = hedgeValue;
            requestBody.hedge = hedge;

            var response = CallWebAPIAsync("strategies/shortStraddle", requestBody);
            return response;
        }



        public dynamic longStrangle(
           string symbol,
           string callStrikePrice,
           string putStrikePrice,
           string expiry,
           string product,
           string quantity,
           string remarks
         

   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.jKey = configData.token;
            requestBody.userId = configData.userId;
            requestBody.symbol = symbol;
            requestBody.callStrikePrice = callStrikePrice;
            requestBody.putStrikePrice = putStrikePrice;
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
         

            var response = CallWebAPIAsync("strategies/longStrangle", requestBody);
            return response;
        }


        public dynamic shortStrangle(
           string symbol,
           string callStrikePrice,
           string putStrikePrice,
           string expiry,
           string product,
           string quantity,
           string remarks,
             int hedgeValue,
           Boolean hedge


   )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.jKey = configData.token;
            requestBody.userId = configData.userId;
            requestBody.symbol = symbol;
            requestBody.callStrikePrice = callStrikePrice;
            requestBody.putStrikePrice = putStrikePrice;
            requestBody.expiry = expiry;
            requestBody.product = product;
            requestBody.quantity = quantity;
            requestBody.remarks = remarks;
            requestBody.hedgeValue = hedgeValue;
            requestBody.hedge = hedge;


            var response = CallWebAPIAsync("strategies/shortStrangle", requestBody);
            return response;
        }
        #endregion

        #region Websockets
        public WebsocketClient initializeWebSocket()
        {
            var url = new Uri(connection);
            var client = new WebsocketClient(url);
            client.ReconnectTimeout = TimeSpan.FromSeconds(0.3);

            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.t = "c";
            requestBody.uid = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.susertoken = configData.token;
            requestBody.source = "API";
            string authorizeBody = JsonConvert.SerializeObject(requestBody);

            client.ReconnectionHappened.Subscribe(info =>
            { 
                if (info.Type.ToString() == "NoMessageReceived")
                {
                    client.Send(authorizeBody);

                }
            });

            return client;
        }

        #region Websockets Methods
        public string startWebsockets()
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.t = "c";
            requestBody.uid = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.susertoken = configData.token;
            requestBody.source = "API";
            string authorizeBody = JsonConvert.SerializeObject(requestBody);
            return authorizeBody;
        }

        public string subscribeFeed(string k)
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "tf";
            messageData.k = k;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }
        public string subscribeFeedAcknowledgement(string k)
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "t";
            messageData.k = k;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }

        public string unsubscribeFeed(string k)
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "u";
            messageData.k = k;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }

        public string subscribeDepth(string k)
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "d";
            messageData.k = k;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }

        public string subscribeDepthAcknowledgement()
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "dk";
           
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }

        public string unsubscribeDepth(string k)
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "dk";
            messageData.k = k;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }
        public string subscribeOrderUpdate(string k)
        {
            dynamic messageData = new ExpandoObject();
            var configData = ReadDataFromJson("config.json");
            messageData.t = "o";
            messageData.actid = configData.userId;
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }
        public string subscribeOrderAcknowledgement()
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "ok";
          
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }
        public string unsubscribeOrderUpdate()
        {
            dynamic messageData = new ExpandoObject();
            messageData.t = "uo";
          
            string requestBody = JsonConvert.SerializeObject(messageData);
            return requestBody;
        }
        #endregion

        #endregion

        #region Old Method
        private dynamic APICall(string urlParameters, dynamic requestBodyData, string type = "POST")
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            dynamic json = new ExpandoObject();


            if (type == "GET")
            {
                var response = client.GetAsync(urlParameters);

                response.Wait();// Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsCompleted)
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var messageTask = result.Content.ReadAsStringAsync();

                        messageTask.Wait();
                        json = JsonConvert.DeserializeObject(messageTask.Result);




                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
                    }
                }
            }
            if (type == "POST")
            {




                var myContent = JsonConvert.SerializeObject(requestBodyData);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(urlParameters, byteContent).Result;



                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    var result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    var stringData = result.Result;
                    dynamic jsonDdata = JObject.Parse(stringData);
                    json = jsonDdata;
                }
            }

            return json;
        }
        #endregion

        #region API Call Method
        private dynamic CallWebAPIAsync(string urlParameters, dynamic requestBodyData, string type = "POST")
        {
            using (var client = new HttpClient())
            {
                dynamic response = new ExpandoObject();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (type == "POST")
                {
                    var myContent = JsonConvert.SerializeObject(requestBodyData);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage res = client.PostAsync(urlParameters, byteContent).Result;
                    res.EnsureSuccessStatusCode();
                    response = returnJsonSerialisedData(res);

                }
                if (type == "GET")
                {
                    HttpResponseMessage res = client.GetAsync(urlParameters).Result;
                    res.EnsureSuccessStatusCode();
                    response = returnJsonSerialisedData(res);

                }



                return response;
            }
        }
        private dynamic returnJsonSerialisedData(HttpResponseMessage res)
        {
            var jsonString = res.Content.ReadAsStringAsync();
            var responseString = jsonString.Result;
            var token = JToken.Parse(responseString);
            dynamic response = new ExpandoObject();

            if (token is JArray)
            {
                response = token.ToObject<List<dynamic>>();
            }
            else if (token is JObject)
            {
                response = token.ToObject<dynamic>();
            }
            return response;
        }
        #endregion 
        private void WriteDataIntoJson(dynamic data, string fileName)
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(currentDirectory + "/" + fileName, json);
        }
        private dynamic ReadDataFromJson(string fileName)
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = currentDirectory + "/" + fileName;
            var JSON = File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(JSON);
            return jsonObj;
        }

    }

}
