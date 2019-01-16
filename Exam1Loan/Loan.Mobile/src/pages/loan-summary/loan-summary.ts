import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

/**
 * Generated class for the LoanSummaryPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-loan-summary',
  templateUrl: 'loan-summary.html',
})
export class LoanSummaryPage {

  increasePercentage: any;
  debtAmount: any;
  totalYears: any;
  loadSummary: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, public http: HttpClient) {
    this.increasePercentage = navParams.get('param');
  }

  getLoanDetail() {
    var url = "https://localhost:44328/api/Loan/GetTotalDebtAmount/" + this.debtAmount + "/" + this.increasePercentage + "/" + this.totalYears;
    this.http.get(url).subscribe(data => {
      this.loadSummary = data;
    });
  }

}
