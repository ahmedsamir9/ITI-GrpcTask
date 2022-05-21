// package: 
// file: src/app/protos/OrderService.proto

import * as jspb from "google-protobuf";

export class OrderItem extends jspb.Message {
  getId(): number;
  setId(value: number): void;

  getUserid(): number;
  setUserid(value: number): void;

  clearItemsList(): void;
  getItemsList(): Array<ProductItem>;
  setItemsList(value: Array<ProductItem>): void;
  addItems(value?: ProductItem, index?: number): ProductItem;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderItem.AsObject;
  static toObject(includeInstance: boolean, msg: OrderItem): OrderItem.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: OrderItem, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderItem;
  static deserializeBinaryFromReader(message: OrderItem, reader: jspb.BinaryReader): OrderItem;
}

export namespace OrderItem {
  export type AsObject = {
    id: number,
    userid: number,
    itemsList: Array<ProductItem.AsObject>,
  }
}

export class ProductItem extends jspb.Message {
  getId(): number;
  setId(value: number): void;

  getQuantity(): number;
  setQuantity(value: number): void;

  getName(): string;
  setName(value: string): void;

  getPrice(): number;
  setPrice(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): ProductItem.AsObject;
  static toObject(includeInstance: boolean, msg: ProductItem): ProductItem.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: ProductItem, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): ProductItem;
  static deserializeBinaryFromReader(message: ProductItem, reader: jspb.BinaryReader): ProductItem;
}

export namespace ProductItem {
  export type AsObject = {
    id: number,
    quantity: number,
    name: string,
    price: number,
  }
}

export class OrderResponse extends jspb.Message {
  getIsdone(): boolean;
  setIsdone(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderResponse.AsObject;
  static toObject(includeInstance: boolean, msg: OrderResponse): OrderResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: OrderResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderResponse;
  static deserializeBinaryFromReader(message: OrderResponse, reader: jspb.BinaryReader): OrderResponse;
}

export namespace OrderResponse {
  export type AsObject = {
    isdone: boolean,
  }
}

