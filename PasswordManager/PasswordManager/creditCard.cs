using System;

namespace PasswordManager
{
    public class CreditCard
    {

        public Category CreditCardCategory { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Number { get; set; }
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

    }
}