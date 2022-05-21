using Grpc.Core;
using Grpc.Net.Client;
using OrderGetway.Proto;
using static InentoryService.Protos.InventoryService;
using static OrderGetway.Proto.OrderCheckService;
using static PaymentService.Protos.PaymentService;

namespace OrderGetway
{
    public class OrderCheckerSerivce : OrderCheckServiceBase {

        private readonly GrpcChannel _paymentChannel;
        private readonly GrpcChannel _productChannel;
        private readonly PaymentServiceClient _paymentServiceClient;
        private readonly InventoryServiceClient _inventoryServiceClient;

        public OrderCheckerSerivce() {
            _paymentChannel = GrpcChannel.ForAddress("https://localhost:7193");
            _productChannel = GrpcChannel.ForAddress("https://localhost:7140");
            _inventoryServiceClient = new InventoryServiceClient(_productChannel);
            _paymentServiceClient = new PaymentServiceClient(_paymentChannel);
        }
        public override async Task<OrderResponse> MakeOrder(OrderItem request, ServerCallContext context)
        {
            double amount = 0;
            foreach (var item in request.Items)
            {
                var result = await _inventoryServiceClient.checkItemAvaliabiltyAsync
                (new InentoryService.Protos.ItemData { ItemId = item.Id, ItemQuantity = item.Quantity });
                if (!result.IsAvaliable)
                {
                    return new OrderResponse { IsDone = false }; 
                }
                amount += item.Quantity * item.Price;
            }
            var paymentResult = await _paymentServiceClient.PayHandlerAsync(
                new PaymentService.Protos.PayMessage { UserId = request.UserId, OrderAmount = amount });
            if (!paymentResult.Status) return new OrderResponse { IsDone = false };
            return new OrderResponse { IsDone = true } ;
        }
    }
    
}
