import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Burger } from "@/models/Burger.js"
import { AppState } from "@/AppState.js"

class BurgersService {
async GetAll() {
  const res = await api.get('api/burgers')
  logger.log('Got Burgs!', res.data)
  const burgers = res.data.map(pojo => new Burger(pojo))
  AppState.burgers = burgers
}
}

export const burgersService = new BurgersService()