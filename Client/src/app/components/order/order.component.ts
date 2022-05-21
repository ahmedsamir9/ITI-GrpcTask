import { Component, OnInit } from '@angular/core';
import { grpc } from '@improbable-eng/grpc-web';
import { OrderItem, ProductItem } from 'src/app/generated/src/app/protos/OrderService_pb';
import { OrderCheckService } from 'src/app/generated/src/app/protos/OrderService_pb_service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  constructor() { }
  logs : string [] = [];
  ngOnInit(): void {
  }
  submitOrder(){
    var order = new OrderItem();
    order.setId(1);
    order.setUserid(1);
    var firstProuduct = new ProductItem();
    firstProuduct.setId(1);
    firstProuduct.setName("aa");
    firstProuduct.setPrice(10);
    firstProuduct.setQuantity(1);
    order.addItems(firstProuduct);
    var secondProuduct = new ProductItem();
    secondProuduct.setId(2);
    secondProuduct.setName("b");
    secondProuduct.setPrice(2);
    secondProuduct.setQuantity(2);
    order.addItems(secondProuduct);
    grpc.unary(OrderCheckService.MakeOrder,{
      request:order,
      host:"https://localhost:7194",
      onEnd:result=>{
        const {status,message}=result;
        if(status==grpc.Code.OK&&message){
          this.logs.push(JSON.stringify(message.toObject()));
        }
      }
    });
  }

}
