using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Factory.Ventas.SalesEntity
{
    public class SalesEntity
    {
        protected string Category {  get; set; }
        protected int Amount {  get; set; }
        protected decimal Balance { get; set; }
        protected int ID { get; set; }

        public string category => Category;
        public int amount => Amount;
        public decimal balance => Balance;
        public int id => ID;

        public SalesEntity(string category,int amount, decimal balance) 
        { 
            Category = category;
            Amount = amount;
            Balance = balance;
        }
        public void SetId(int id)
        {
            ID = id;
        }
    }
}
