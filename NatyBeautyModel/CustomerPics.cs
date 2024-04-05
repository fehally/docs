using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatyBeautyModel
{
    public class CustomerPics
    {
        public int ID {  get; set; }
        public int idCustomer {  get; set; }
        public string Picture {  get; set; }
        public DateTime Date {  get; set; }
        public string Comments {  get; set; }
    }
}
