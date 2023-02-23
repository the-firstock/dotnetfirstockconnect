
namespace thefirstock
{
    public class PostObject
    {
        public string userId { get; set; }
        public string jKey { get; set; }

        public string orderNumber { get; set; }

        public string actid { get; set; }
    }
    public class spanCalcualtorObject
    {
        public string exchange { get; set; }
        public string instname { get; set; }
        public string symbolName { get; set; }
        public string expireDate { get; set; }
        public string optionType { get; set; }
        public string strikePrice { get; set; }
        public string netQuantity { get; set; }
        public string buyQuantity { get; set; }
        public string sellQuantity { get; set; }
        public string product { get; set; }

        public spanCalcualtorObject(string exchange, string instname, string symbolName, string expireDate, string optionType, string strikePrice, string netQuantity,
            string buyQuantity, string sellQuantity, string product
            )
        {
            this.exchange = exchange;
            this.instname = instname;
            this.symbolName = symbolName;
            this.expireDate = expireDate;
            this.optionType = optionType;
            this.strikePrice = strikePrice;
            this.netQuantity = netQuantity;
            this.buyQuantity = buyQuantity;
            this.sellQuantity = sellQuantity;
            this.product = product;




        }

    }
}




