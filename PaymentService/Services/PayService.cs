using Grpc.Core;
using PaymentService.Model;
using PaymentService.Protos;
using static PaymentService.Protos.PaymentService;

namespace PaymentService.Services
{
    public class PayService :PaymentServiceBase
    {
        public static List<User> Users = new List<User>()
        {
            new User { UserId = 1 , UserName ="ahmed" , Amount = 45.0 },
            new User { UserId = 2 , UserName ="ali" , Amount = 50.0 },
            new User { UserId = 3 , UserName ="mohamed" , Amount = 45.0 },
        };
        public override Task<PayResponse> PayHandler(PayMessage request, ServerCallContext context)
        {
           var currentUser =Users.FirstOrDefault(x => x.UserId == request.UserId);
            if (currentUser == null)return Task.FromResult(new PayResponse() { Status = false , Message ="User is not avalible"});
            if(currentUser.Amount < request.OrderAmount) return Task.FromResult(new PayResponse() { Status = false, Message = "User Amount is Not Enough" });
            currentUser.Amount -=request.OrderAmount;
            return Task.FromResult(new PayResponse() { Status = true, Message = "Payment Done successfully" });
        }
    }
}
