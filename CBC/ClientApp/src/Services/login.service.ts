import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private _baseUrl: string;

  constructor(
    private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getUserInfo(userName: string) {
    return this._http.get(this._baseUrl + 'Login/GetUserInfo/' + userName, { responseType: 'text'});
  }
}
