using AvesdoService.Core.Interfaces;
using AvesdoService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvesdoService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository<InvoiceModel> _repository;
        public InvoiceController(IInvoiceRepository<InvoiceModel> repository)
        {
            _repository = repository;
        }

        // GET api/Invoice/GetInvoiceByOrderID/4
        [HttpGet("[action]/{orderID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvoiceModel>> GetInvoiceByOrderID(int orderID)
        {
            var result = await _repository.GetInvoiceByOrderIDAsync(orderID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(orderID);
        }

        // GET api/Invoice/GetInvoiceByInvoiceID/4
        [HttpGet("[action]/{invoiceID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InvoiceModel>> GetInvoiceByInvoiceID(int invoiceID)
        {
            var result = await _repository.GetInvoiceByInvoiceIDAsync(invoiceID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(invoiceID);
        }

        // POST api/<OrderController>
        [HttpPost("[action]/{orderID}/{addressID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InvoiceModel>> CreateInvoice(int orderID,int addressID)
        {
            var result = await _repository.CreateInvoiceAsync(orderID,addressID);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(orderID);
        }
    }
}
