
namespace thefirstock
{
    public class PostObject
    {
        public string userId { get; set; }
        public string jKey { get; set; }

        public string orderNumber { get; set; }

        public string actid { get; set; }
    }
    public class basketMarginObject
    {
        public string exchange { get; set; }

        public string tradingSymbol { get; set; }
        public string quantity { get; set; }
        public string transactionType { get; set; }
        public string price { get; set; }
        public string product { get; set; }
        public string priceType { get; set; }
    }

    public class spanCalculatorObject
    {
        public string exchange { get; set; }
        public string instrumentName { get; set; }
        public string symbolName { get; set; }
        public string expireDate { get; set; }
        public string optionType { get; set; }
        public string strikePrice { get; set; }
        public string netQuantity { get; set; }
        public string buyQuantity { get; set; }
        public string sellQuantity { get; set; }
        public string product { get; set; }

    }

    public class  multiPlaceOrderObject
    {
        public string exchange { get; set; }
        public string tradingSymbol { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string product { get; set; }
        public string transactionType { get; set; }
        public string priceType { get; set; }
        public string retention { get; set; }
        public string triggerPrice { get; set; }
        public string remarks { get; set; }

    }
}




