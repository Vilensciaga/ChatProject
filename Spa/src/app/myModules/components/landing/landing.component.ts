import { Component, EventEmitter, Output } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user';
import { Login } from '../../models/login';
import { Observable } from 'rxjs/internal/Observable';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent {

  modalTitle: string = '';
  auth:Login = {} as Login;
  token$!: Observable<string>;

  @Output('createUser')
  createUserEmitter = new EventEmitter<User>();

  constructor(private userService: UserService,private router:Router, private route:ActivatedRoute)
  {
    
  }

  onClickSignIn(email:string, password:string)
  {

    if(email!==undefined && password!=undefined)
    {
      this.auth.email = email;
      this.auth.password = password;

        this.userService.signInUser(this.auth)
            .subscribe(
              response => {
                // Handle the response from the API here, response is the token recieved
                console.log("Signed In!!", response);

                this.userService.SetUserLoggedIn(response);
                setTimeout(()=>{
                  this.router.navigate(["/home"]);

                }, 500)
              }, (error)=>{
                console.log(error);
              }
            );
    }
          
  }

  createUser(user:User)
  {
    
      this.userService.createUser(user)
          .subscribe(
            ()=> console.log("User Created!")
          );
  }


}
