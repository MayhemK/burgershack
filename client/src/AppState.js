import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Food.js').Food[]} */
  burgers: [],
  /** @type {import('./models/Food.js').Food[]} */
  salads: [],
  /** @type {import('./models/Food.js').Food[]} */
  desserts: [],
  /** @type {{ id: string, name: string, price: number, quantity: number }[]} */
  clickedItems: []
})

