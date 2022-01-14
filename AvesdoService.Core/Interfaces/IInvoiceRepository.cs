using AvesdoService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Interfaces
{
    public interface IInvoiceRepository<T> where T : IModel<int>
    {
        Task<IEnumerable<T>> GetInvoicesAsync();
        Task<T> GetInvoiceByOrderIDAsync(int orderID);
        Task<T> GetInvoiceByInvoiceIDAsync(int invoiceID);
        Task<T> CreateInvoiceAsync(int orderID, int addressID);
        Task<Address> CreateAddress(Address address);

    }
}
