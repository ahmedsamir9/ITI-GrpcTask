using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using OrderGetway.model;
using static InentoryService.Protos.InventoryService;
using static PaymentService.Protos.PaymentService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderGetway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly GrpcChannel _paymentChannel;
        private readonly GrpcChannel _productChannel;
        private readonly PaymentServiceClient _paymentServiceClient;
        private readonly InventoryServiceClient _inventoryServiceClient;
        public OrderController()
        {
            _paymentChannel = GrpcChannel.ForAddress("https://localhost:7193");
             _productChannel = GrpcChannel.ForAddress("https://localhost:7140");
            _inventoryServiceClient= new InventoryServiceClient(_productChannel);
            _paymentServiceClient= new PaymentServiceClient(_paymentChannel);
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Order order)
        {
            if (order == null) return BadRequest();
            double amount =0;
           foreach(var item in order.Items) {
                var result = await _inventoryServiceClient.checkItemAvaliabiltyAsync
                (new InentoryService.Protos.ItemData { ItemId = item.Id, ItemQuantity = item.Quantity });
                if (!result.IsAvaliable)
                {
                    return BadRequest();
                }
                amount += item.Quantity * item.Price;
           }
            var paymentResult = await _paymentServiceClient.PayHandlerAsync(
                new PaymentService.Protos.PayMessage { UserId = order.UserId, OrderAmount = amount });
            if (!paymentResult.Status) return BadRequest();
            return Created("",order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
