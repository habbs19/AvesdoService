using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Models
{
    public class OrderItemModel : IModel<int>
    {
        public int OrderItemId { get => Id; set => Id = value; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}
