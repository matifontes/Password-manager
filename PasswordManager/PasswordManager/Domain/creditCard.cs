using System;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class CreditCard
    {
        const int LENGTH_FOR_VALID_NAME = 16;
        public Category Category { get; set; }
        public string Type { get; set; }
        private long _number;
        private short _ccvCode;
        private string _name;
        public string Name
        {
            get { return _name; }
            set => SetName(value);
        }
        public long Number
        {
            get { return _number; }
            set => SetNumber(value);
        }
        public short CCVCode 
        {
            get { return _ccvCode; }
            set => SetCCVCode(value); 
        }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }


        public CreditCard(Category category, string name, string type, long creditCardNumber, short ccvCode, DateTime expDate, string note) {
            this.Category = category;
            this.Name = name;
            this.Type = type;
            this.Number = creditCardNumber;
            this.CCVCode = ccvCode;
            this.ExpiryDate = expDate;
            this.Note = note;
        }

        public override string ToString()
        {
            return this.Name;
        }

        private void SetName(string name) 
        {
            if (!IsValidName(name))
            {
                throw new EmptyCreditCardNameException("Nombre de tarjeta de creadito no puede ser vacio");
            }
            else 
            {
                this._name = name;
            }
        }

        private void SetNumber(long num)
        {
            if (!IsValidNumber(num))
            {
                throw new InvalidCreditCardNumberException("Largo del numero de tarjeta invalido");
            }
            else
            {
                this._number = num;
            }
        }

        private void SetCCVCode(short num) 
        {
            if (!IsValidCCV(num))
            {
                throw new InvalidCreditCardCCVCodeException("Código CCV invalido");
            }
            else 
            {
                this._ccvCode = num;
            }
        }

        private bool IsValidName(string name) 
        {
            return name != "";
        }

        private bool IsValidCCV(short num) 
        {
            return num <= 999 && num >= 000;
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