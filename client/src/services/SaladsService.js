import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Salad } from "@/models/Salad.js"
import { AppState } from "@/AppState.js"

class SaladsService {
async GetAll() {
  const res = await api.get('api/salads')
  logger.log('Got Salds!', res.data)
  const salads = res.data.map(pojo => new Salad(pojo))
  AppState.salads = salads
}
}

export const saladsService = new SaladsService()