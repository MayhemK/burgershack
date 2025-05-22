export class Food {
  constructor(data) {
    // category
    this.id = data.id
    this.name = data.name
    this.price = data.price
    this.imgUrl = data.imgUrl
  }
}