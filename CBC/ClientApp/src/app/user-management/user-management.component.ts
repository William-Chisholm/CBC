import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserManagementService } from '../../Services/user-management.service';

@Component({
    selector: 'app-user-management',
    templateUrl: './user-management.component.html',
    styleUrls: ['./user-management.component.css']
})
/** user-management component*/
export class UserManagementComponent implements OnInit, OnDestroy {
  private _subscriptions: Subscription[] = [];
    /** user-management ctor */
  constructor(private _userManagementSvc: UserManagementService) { }

  ngOnInit() {
    let text = this._userManagementSvc.generateUserText();
    console.log(text);
  }

  addUser() {
    let firstName = (document.getElementById('firstName') as HTMLInputElement).value;
    let lastName = (document.getElementById('lastName') as HTMLInputElement).value;
    let userName = (document.getElementById('userName') as HTMLInputElement).value;
    let password = (document.getElementById('password') as HTMLInputElement).value;
    let access = (document.getElementById('access') as HTMLInputElement).value;
    let createButton = document.getElementById('createBtn') as HTMLButtonElement;
    let form = document.getElementById('addUserForm') as HTMLFormElement;


    let altMessage = 'Please enter user info...';
    let successMessage = 'A new user was successfully created!';
    let errorMessage = 'The application encountered an error while trying to create a new user...';
    let errorMessage2 = 'The application encountered an error while generating a key for the user...';

    if (firstName === '' || lastName === '' || userName === '' || password === '' || access === 'none') {
      this.showBackdrop();
      this.showModal(altMessage);
    }
    else {
      createButton.disabled = false;
      this._subscriptions.push(this._userManagementSvc.generateUserText().subscribe(key => {
        let ep: string = this._userManagementSvc.set(key.toString(), password);
        this._subscriptions.push(this._userManagementSvc.createNewUser(firstName, lastName, userName, key, ep, access).subscribe(data => {
          console.log(data);
        },
          err => {
            this.showBackdrop();
            this.showModal(errorMessage);
            console.log(err);
          }));
        form.reset();
        access = 'none';
        this.showBackdrop();
        this.showModal(successMessage);
      })),
        err => {
          this.showBackdrop();
          this.showModal(errorMessage2);
        };
    }
  }

  showPass() {
    let password = document.getElementById('password') as HTMLInputElement;
    let checkbox = document.getElementById('show-pass') as HTMLInputElement;
    if (checkbox.checked) {
      password.type = 'text';
    }
    else {
      password.type = 'password';
    }
  }

  showBackdrop() {
    let backdrop = document.getElementById('backdrop');
    backdrop.style.display = 'flex';
  }

  hideBackdrop() {
    let backdrop = document.getElementById('backdrop');
    backdrop.style.display = 'none';
  }

  showModal(message) {
    let modal = document.getElementById('modal');
    let modal_message = (document.getElementById('modal-message') as HTMLParagraphElement);
    modal_message.innerHTML = message;
    modal.style.display = 'flex';
  }

  hideModal() {
    let modal = document.getElementById('modal');
    modal.style.display = 'none';
  }

  ngOnDestroy() {
    this._subscriptions.forEach(x => x.unsubscribe());
  }
}
