import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PackageList } from "../Models/package-list.model";
import { Package } from "../Models/package.model";

@Injectable({
  providedIn: 'root'
})
export class EstimatorService {
  private _baseUrl: string;

  constructor(
    private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getAllPackages(): Observable<PackageList[]> {
    return this._http.get(this._baseUrl + 'Estimator/GetAllPackages').pipe(map(res => <PackageList[]>res));
  }

  public getPackage(pkg: string): Observable<Package[]> {
    console.log(pkg);
    return this._http.get(this._baseUrl + 'Estimator/GetPackage/' + pkg).pipe(map(res => <Package[]>res));
  }
}
