import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { AddProductToCartPage } from './add-product-to-cart';

@NgModule({
  declarations: [
    AddProductToCartPage,
  ],
  imports: [
    IonicPageModule.forChild(AddProductToCartPage),
  ],
})
export class AddProductToCartPageModule {}
