import { Address } from "./user";

export interface Tour {
    id: number;
    userData: Address;
    tourItems: TourItem[];
    userEmail: string;
    status: string;
    tourDate: Date; 
    subtotal: number; 
     //time: number;
  }
  
  export interface TourItem {
    price: number;
    exhibitItemId: number;
    exhibitName: string;
    pictureUrl: string;
  }
  export interface TourToCreate {
    //time: number;
    //mislim da se sam postavlja  //status: string;
    userData: Address;
    tourItems: TourItem[];
    userEmail: string;
  }
  /*export interface TourToCreate{
    basketId: string;
    userData: Address;
}
 */ 
  // exhibit-item-toured.model.ts
 
