import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import * as CryptoJS from 'crypto-js'

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {
  private _baseUrl: string;

  constructor(
    private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  set(keys, value) {
    console.log(keys);
    console.log(value);
    let key = CryptoJS.enc.Utf8.parse(keys);
    let iv = CryptoJS.enc.Utf8.parse(keys);
    let encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(value.toString()), key,
      {
        keySize: 256,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
      });
    return encrypted.toString();
  }

  public generateUserText() {
    return this._http.get(this._baseUrl + 'UserManagement/GenerateUserText', { responseType: 'text' });
  }

  public createNewUser(firstName, lastName, userName, key, password, access) {
    return this._http.post<any>(this._baseUrl + 'UserManagement/AddUser/' + firstName + '/' + lastName + '/' + userName + '/' + key + '/' + password + '/' + access, { responseType: 'text' });
  }
}
