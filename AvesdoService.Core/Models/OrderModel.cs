using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Models
{
    public class OrderModel : IModel<int>
    {
        public int OrderID { get => Id; set => Id = value; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
