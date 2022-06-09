import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PackageList } from '../../Models/package-list.model';
import { Package } from '../../Models/package.model';
import { EstimatorService } from '../../Services/estimator.service';

@Component({
    selector: 'app-estimator',
    templateUrl: './estimator.component.html',
    styleUrls: ['./estimator.component.css']
})
/** estimator component*/
export class EstimatorComponent implements OnInit, OnDestroy {
  private _subscriptions: Subscription[] = [];
  public allPackages: PackageList[] = [];
  public pkg: Package[] = [];

  public itemPrice: number[] = [];
  public total: number;

  /** estimator ctor */
  constructor(private _estimatorSvc: EstimatorService) { }

  ngOnInit() {
    this._subscriptions.push(this._estimatorSvc.getAllPackages().subscribe(res => {
      //console.log(res);
      this.allPackages = res;
    }, error => {
      console.log(error);
    }));
  }

  getPackage() {
    let pkg = (document.getElementById('package') as HTMLOptionElement).value;

    this._subscriptions.push(this._estimatorSvc.getPackage(pkg).subscribe(res => {
      this.pkg = res;
      console.log(this.pkg);
      for (let i = 0; i < this.pkg.length; i++) {
        this.itemPrice[i] = this.pkg[i].price * this.pkg[i].quantity;
        //console.log(this.pkg[i].description + " " + this.itemPrice[i]);
      }
      //console.log(this.itemPrice.reduce((a, b) => a + b, 0));
      let sub = this.itemPrice.reduce((a, b) => a + b, 0);
      let taxPercent = .095;
      let tax = sub * taxPercent;
      console.log(sub);
      console.log(tax);
      this.total = Math.round((sub + tax + Number.EPSILON) * 100) / 100;
    }, error => {
      console.log(error);
    }));
  }

  ngOnDestroy() {
    this._subscriptions.forEach(x => x.unsubscribe());
  }
}
