 import * as cuid from "cuid"

  export interface PlannerItem {
    id: number
    exhibitName: string
    price: number
    pictureUrl: string
    type: string
  }

  export interface Planner {
    id: string
    items: PlannerItem[]
  }

  export class Planner implements Planner {
    id = cuid()
    items: PlannerItem[] = [];
  }

 /* export interface BasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
  } */
  