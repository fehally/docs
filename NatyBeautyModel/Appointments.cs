using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatyBeautyModel
{
    public class Appointments
    {
        public int ID { get; set; }
        public int idCustomer { get;}
        public int idPaymentType { get;}
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Value {  get; set; }
        public int idEmproyee {  get;}
        public decimal Tip {  get; set; }
        public decimal Discount {  get; set; }
        public string Comments {  get; set; }

    }
}
