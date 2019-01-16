import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AlertController } from 'ionic-angular';

/**
 * Generated class for the ProductPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-product',
  templateUrl: 'product.html',
})
export class ProductPage {

  products: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, public http: HttpClient, private alertCtrl: AlertController) {
  }

  ionViewDidLoad() {
    this.GetProduct();
  }

  GetProduct() {
    var url = "https://localhost:44312/api/Cart/GetProducts";
    this.http.get(url).subscribe(data => {
      this.products = data;
    });
  }

  ShowAddProductDialog() {
    let alert = this.alertCtrl.create({
      title: 'กรุณากรอกข้อมูลสินค้า',
      inputs: [
        {
          name: 'Name',
          placeholder: 'ชื่อสินค้า'
        },
        {
          name: 'Price',
          placeholder: 'ราคา',
          type: 'number'
        }
      ],
      buttons: [
        {
          text: 'ยกเลิก',
          role: 'cancel',
          handler: data => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'ตกลง',
          handler: data => {
            this.AddProduct(data);
          }
        }
      ]
    });
    alert.present();
  }

  ShowAddProductToCartDialog(itemid) {
    let alert = this.alertCtrl.create({
      title: 'กรุณากรอกจำนวนที่ต้องการ',
      inputs: [
        {
          name: 'amount',
          placeholder: 'จำนวน',
          type: 'number'
        }
      ],
      buttons: [
        {
          text: 'ยกเลิก',
          role: 'cancel',
          handler: data => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'ตกลง',
          handler: data => {
            this.AddProductTocart(itemid, data.amount);
          }
        }
      ]
    });
    alert.present();
  }

  AddProduct(request) {
    let option = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    this.http.post("https://localhost:44312/api/Cart/AddNewProduct",
      request,
      option)
      .subscribe(data => {
        this.GetProduct();
      });
  }

  AddProductTocart(id, amount) {
    let option = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    this.http.put("https://localhost:44312/api/Cart/AddProductToCart/" + id + "/" + amount,
      null,
      option)
      .subscribe(() => { this.GoToCart() });
  }

  GoToCart() {
    this.navCtrl.push("CartPage");
  }
}
