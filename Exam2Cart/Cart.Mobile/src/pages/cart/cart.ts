import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient, HttpHeaders } from '@angular/common/http';

/**
 * Generated class for the CartPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-cart',
  templateUrl: 'cart.html',
})
export class CartPage {

  productInCarts: any = [];
  sum: any = 0;
  sumByDisCount: any = 0;
  disCount: any = 0;

  constructor(public navCtrl: NavController, public navParams: NavParams, public http: HttpClient) {

  }

  ionViewDidLoad() {
    this.GetCart();
  }

  GetCart() {
    var url = "https://localhost:44312/api/Cart/GetProductInCart";
    this.http.get(url).subscribe(data => {
      this.productInCarts = data;
      for (let i = 0; i < this.productInCarts.length; i++) {
        var sumOfProduct = this.productInCarts[i].product.price * this.productInCarts[i].amount
        this.sum = this.sum + sumOfProduct;
        if (this.productInCarts[i].amount > 3) {
          var discountCount = Math.floor(this.productInCarts[i].amount / 4);
          var discount = discountCount * this.productInCarts[i].product.price;
          this.disCount += discount;
          this.sumByDisCount = sumOfProduct - discount;
        }
      }
    });
  }

  GoToProduct() {
    this.navCtrl.push("ProductPage");
  }
}
