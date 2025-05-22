import { AppState } from "@/AppState.js";
import { logger } from "@/utils/Logger.js";

class OrderService {
addItemToOrder(newItem) {
const existingItem = AppState.clickedItems.find(item => item.id === newItem.id)

  if (existingItem) {
    existingItem.quantity++;
  } else {
    AppState.clickedItems.push({ ...newItem, quantity: 1});
  }
logger.log('Order Updated', AppState.clickedItems)
}

clearOrder() {
  AppState.clickedItems = [];
  logger.log('Order Cleared');
}
}

export const orderService = new OrderService();