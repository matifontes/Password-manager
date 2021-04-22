using System;

namespace PasswordManager
{
    public class CreditCard
    {
        const int LENGTH_FOR_VALID_NAME = 16;
        public Category CreditCardCategory { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Number
        {
            get { return Number; }
            private set
            {
                if (!IsValidNumber(value))
                {
                    throw new InvalidCreditCardNumberException();
                }
                else
                {
                    this.Number = value;
                }
            }
        }
        public short CCVCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }


        public CreditCard(Category category, string name, string type, long creditCardNumber, short ccvCode, DateTime expDate, string note) {
            this.CreditCardCategory = category;
            this.Name = name;
            this.Type = type;
            this.Number = creditCardNumber;
            this.CCVCode = ccvCode;
            this.ExpiryDate = expDate;
            this.Note = note;
        }

        public bool IsValidNumber(long value)
        {
            return false;
        }

    }
}