import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  increasePercentage: any;

  constructor(public navCtrl: NavController) { }

  goCalculator() {
    this.navCtrl.push("LoanSummaryPage", {
      param: this.increasePercentage
    });
  }

}
