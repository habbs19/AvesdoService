using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AvesdoService.Core.Models
{
    public class InvoiceModel : IModel<int>
    {
        public int InvoiceID { get=> Id; set => Id = value; }
        public int OrderID { get; set; }
    }
}
