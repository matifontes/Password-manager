using System;
using PasswordManager.Exceptions;

namespace PasswordManager
{
    public class CreditCard
    {
        const int LENGTH_FOR_VALID_NAME = 16;
        public Category Category { get; set; }
        private string _name;
        private string _type;
        private long _number;
        private short _ccvCode;
        public string Name
        {
            get { return _name; }
            set => SetName(value);
        }
        public string Type 
        { 
            get { return _type; }
            set => SetType(value); 
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

        public override bool Equals(object obj)
        {
            return Equals(obj as CreditCard);
        }

        public bool Equals(CreditCard creditCard) 
        {
            return this.Number == creditCard.Number;
        }

        private void SetName(string name) 
        {
            if (!IsValidName(name))
            {
                throw new InvalidCreditCardNameException("Largo del nombre de tarjeta de credito invalido, entre 3 y 25 caracteres");
            }
            else 
            {
                this._name = name;
            }
        }

        private void SetType(string type) 
        {
            if (!IsValidType(type))
            {
                throw new InvalidCreditCardTypeException("Largo del tipo de tarjeta de credito invalido, entre 3 y 25 caracteres");
            }
            else
            {
                this._type = type;
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
            return name.Length >= 3 && name.Length <= 25;
        }

        private bool IsValidType(string type) 
        {
            return type.Length >= 3 && type.Length <= 25;
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