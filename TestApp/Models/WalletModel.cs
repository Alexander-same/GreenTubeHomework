namespace TestApp.Models
{
    public class WalletModel
    {
        public Guid GuidId { get; set; }
        public Guid PlayerId { get; set; }
        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value >= 0)
                {
                    this._amount = value;
                }
                else throw new Exception("Currency can't be less then 0");
            }
        }

    }
}
