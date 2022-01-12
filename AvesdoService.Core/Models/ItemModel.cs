using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AvesdoService.Core.Models
{
    public class ItemModel : IModel<int>
    {
        public int ItemId { get => Id; set => Id = value; }
        public string Name { get; set;}
        public string Description { get; set;}
        public decimal UnitCost { get; set;}
    }
}
