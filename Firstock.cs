using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;

namespace thefirstock
{

  public class Firstock
    {
        private string token = string.Empty;
        private string userId = string.Empty;
        private string URL = "https://connect.thefirstock.com/apiV2/";

        #region Firstock Methods
        public dynamic login(string userId, string password, string DOBnPAN, string vendorCode, string apikey)
        {

            dynamic requestBody = new ExpandoObject();

            requestBody.userId = userId;

            requestBody.password = password;

            requestBody.DOBnPAN = DOBnPAN;

            requestBody.vendorCode = vendorCode;

            requestBody.apiKey = apikey;
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

        public dynamic cancelOrder(string norenordno)
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                norenordno = norenordno
            };
            var response = CallWebAPIAsync("cancelOrder", postObject);
            return response;
        }

        public dynamic singleOrderHistory(string norenordno)
        {
            var configData = ReadDataFromJson("config.json");
            PostObject postObject = new PostObject()
            {
                userId = configData.userId,
                jKey = configData.token,
                norenordno = norenordno
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
           string norenordno,
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
            requestBody.norenordno = norenordno;
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
            var response = CallWebAPIAsync("getQuotes", requestBody);
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
        string exchange,
        string instname,
        string symbolName,
        string expd,
        string optt,
        string strikePrice,
        string netQuantity,
        string buyQuantity,
        string sellQuantity,
        string product
 )
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();
            requestBody.userId = configData.userId;
            requestBody.actid = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.instname = instname;
            requestBody.symbolName = symbolName;
            requestBody.product = product;
            requestBody.expd = expd;
            requestBody.optt = optt;
            requestBody.strikePrice = strikePrice;
            requestBody.netQuantity = netQuantity;
            requestBody.buyQuantity = buyQuantity;
            requestBody.sellQuantity = sellQuantity;
            var response = CallWebAPIAsync("spanCalculators", requestBody);
            return response;
        }

        public dynamic timePriceSeries(
        string exchange,
        string token,
        string endTime,
        string startTime,
        string intrv
)
        {
            var configData = ReadDataFromJson("config.json");
            dynamic requestBody = new ExpandoObject();

            requestBody.userId = configData.userId;
            requestBody.jKey = configData.token;
            requestBody.exchange = exchange;
            requestBody.token = token;
            requestBody.endtime = endTime;
            requestBody.starttime = startTime;
            requestBody.intrv = intrv;
            var response = CallWebAPIAsync("timePriceSeries", requestBody);
            return response;
        }
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
