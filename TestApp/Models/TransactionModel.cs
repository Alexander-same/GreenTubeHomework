using TestApp.Models.Enums;

namespace TestApp.Models
{
    public class TransactionModel
    {
        public Guid GuidId { get; set; }
        public Guid WalletId { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PlayerId { get; set; }
        private decimal _amount { get; set; }
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
                else throw new Exception("Ammount can't be less then 0");
            }
        }
    }
}
