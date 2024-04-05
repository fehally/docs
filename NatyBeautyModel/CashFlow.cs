using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatyBeautyModel
{
    public class CashFlow
    {
        public int ID {  get; set; }
        public int Type {  get; set; }
        public DateTime Date {  get; set; }
        public decimal Value {  get; set; }
        public int idOutflow {  get;}
        public string Comments {  get; set; }
    }
}
