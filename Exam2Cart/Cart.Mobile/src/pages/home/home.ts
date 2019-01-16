import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(public navCtrl: NavController) {

  }

  GoToCart()
  {
    this.navCtrl.push("CartPage");
  }
  GoToProduct()
  {
    this.navCtrl.push("ProductPage");
  }
}
