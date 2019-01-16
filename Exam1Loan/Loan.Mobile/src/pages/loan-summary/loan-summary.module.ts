import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { LoanSummaryPage } from './loan-summary';

@NgModule({
  declarations: [
    LoanSummaryPage,
  ],
  imports: [
    IonicPageModule.forChild(LoanSummaryPage),
  ],
})
export class LoanSummaryPageModule {}
