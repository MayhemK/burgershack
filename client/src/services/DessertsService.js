import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Dessert } from "@/models/Dessert.js"

class DessertsService {
async GetAll() {
  const res = await api.get('api/desserts')
  logger.log('Got Zerts!', res.data)
  const d = res.data.map(pojo => new Dessert(pojo))
  AppState.desserts = d
}
}

export const dessertsService = new DessertsService()