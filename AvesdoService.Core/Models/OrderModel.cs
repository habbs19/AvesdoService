using AvesdoService.Core.Interfaces;
using AvesdoService.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int OrderStatusID { get; set; }

       
    }
}
