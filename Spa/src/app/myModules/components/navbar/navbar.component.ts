import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {faSignInAlt, faUserPlus, faSignOutAlt} from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';   
import { UserService } from '../../services/user.service';
import { Token } from '../../models/token';
import { User } from '../../models/user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
signInIcon = faSignInAlt;
  registerIcon= faUserPlus;
  signOutIcon = faSignOutAlt;
  userIsLoggedIn= false;
  currentUser!:Token;
  firstName!:string;

  constructor(private userSvc: UserService, private router:Router) {

    let userLoggedIn = this.userSvc.GetLoggedInUser();
    if(userLoggedIn!==null)
    {
      this.userIsLoggedIn = true;
      this.currentUser = userLoggedIn;
      //this.firstName = this.currentUser.firstName.replace(/^"(.*)"$/, '$1');
     
    }

    this.userSvc.UserStateChanged.subscribe((userLogedInMsg)=>{
      this.userIsLoggedIn = userLogedInMsg;
      this.currentUser = userLoggedIn;

      this.firstName;
      
      console.log(this.currentUser.firstName.replace(/^"(.*)"$/, '$1'));
    })


  }

  LogoutUser()
  {
    this.userSvc.SetUserAsLoggedOff();
    this.userIsLoggedIn=false;
    this.router.navigate(['/']);
  }
}

///$ npm install @fortawesome/free-solid-svg-icons
//npm install @fortawesome/fontawesome-svg-core