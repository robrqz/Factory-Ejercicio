using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;

namespace Ejercicio_Factory.Report.EntityReport
{
    public class ReportEntity
    {
        protected int Id { get; set; }
        protected string Category { get; set; } 
        protected int Amount { get; set; }
        protected decimal Balance { get; set; }
        protected string Format { get; set; }
        
        public int id => Id;
        public string category => Category;
        public int amount => Amount;
        public decimal balance => Balance;
        public string format => Format;

        public ReportEntity(string category,int amount, decimal balance, string format)
        {
            Category = category;
            Amount = amount;
            Balance = balance;
            Format = format;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
