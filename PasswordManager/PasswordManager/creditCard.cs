using System;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class CreditCard
    {
        const int LENGTH_FOR_VALID_NAME = 16;
        public Category CreditCardCategory { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        private long _number;
        public long Number
        {
            get { return _number; }
            private set
            {
                if (!IsValidNumber(value))
                {
                    throw new InvalidCreditCardNumberException();
                }
                else
                {
                    this._number = value;
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

        private bool IsValidNumber(long creditCardNumber)
        {
            return (AmountOfDigitsOnCreditCard(creditCardNumber) == LENGTH_FOR_VALID_NAME);
        }

        private int AmountOfDigitsOnCreditCard(long creditCardNumber) 
        { 
            return (int)Math.Floor(Math.Log10(creditCardNumber) + 1);
        }
    }
}