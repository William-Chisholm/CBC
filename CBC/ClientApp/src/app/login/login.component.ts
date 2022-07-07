import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserInfo } from '../../Models/user-info.model';
import { LoginService } from '../../Services/login.service';
import { UserManagementService } from '../../Services/user-management.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
/** login component*/
export class LoginComponent {
  // Class variables
  private _subscriptions: Subscription[] = [];

  public userInfo: UserInfo[];

  /** login ctor */
  constructor(
    private _lgnSvc: LoginService,
    private _usrMgmtSvc : UserManagementService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnDestory() {
    this._subscriptions.forEach((subscription) =>
      subscription.unsubscribe());
  }

  login() {
    let userName = (document.getElementById('userName') as HTMLInputElement).value;
    let password = (document.getElementById('password') as HTMLInputElement).value;
    let ep;

    this._subscriptions.push(this._lgnSvc.getUserInfo(userName).subscribe((data: any) => {
      const userObj = JSON.parse((data.replace("[", "").replace("]", "")));
      ep = this._usrMgmtSvc.set(userObj.key, password);

      if (ep !== userObj.password) {
        alert('Please check your credentials...');
      }
      else {
        alert('Login successful!');
      }
    }));
  }
}
