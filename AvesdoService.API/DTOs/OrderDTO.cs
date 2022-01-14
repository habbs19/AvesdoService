using AvesdoService.Core.Specifications;
using System.ComponentModel.DataAnnotations;

namespace AvesdoService.API.DTOs
{
    public class OrderDTO
    {

        [Required]
        public int CustomerID { get; set; }
        [DateTimeRange]
        public DateTime OrderDate { get; set; }
    }
}
