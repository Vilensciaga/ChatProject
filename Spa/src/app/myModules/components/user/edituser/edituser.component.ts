import { HttpHeaders } from '@angular/common/http';
import { outputAst } from '@angular/compiler';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { User } from 'src/app/myModules/models/user';
import { UserService } from 'src/app/myModules/services/user.service';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent {
  @Input()
  currentUser!: User;



  @Output('userEdited')
  userEdited = new EventEmitter<User>();

constructor(private userService: UserService)
{

}



  onClickEdit(firstName:string, lastName:string, email:string)
  {
      this.currentUser.firstName = firstName;
      this.currentUser.lastName = lastName;
      this.currentUser.email = email;
      //this.user.password = password;

      var token = this.userService.getUserToken()?.toString();
    
      if(token)
      {
        var tokenString =  JSON.parse(token);
        var s = "Bearer ";

        var authToken = s.concat(tokenString);

        //authToken = JSON.stringify(authToken);

        console.log(authToken);


        const headers = new HttpHeaders()
          .set("authorization", authToken)
          // .set("content-type", "application/json")
          // .set("origin", "https://localhost:7269")
          // .set("referer", "http://localhost:4200/home")
          // .set("scheme", "http")
          // .set("sec-fetch-mode","cors")


      this.userService.editUser(this.currentUser.id,this.currentUser, headers)
      .subscribe(
        ()=> console.log("User Edited!")
      );

      }
      else{
        console.log("You are not logged in")
      }

      this.userService.GetLoggedInUser();

  }

}
