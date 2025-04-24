import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  title = 'VilensSpaFrontend';

  modalTitle: string = '';
  users$!: Observable<User[]>;
  user!:User;
  selectedIndex!:number;
  selectedUser!: User|undefined;

constructor(private http:HttpClient, private userService: UserService, route:ActivatedRoute, private router:Router)
{
  
}


  ngOnInit() {
    this.users$ = this.userService.getUsers();
    console.log("list of users", this.users$)
  }

  

  createUser(user:User)
  {
    
      this.userService.createUser(user)
          .subscribe(
            ()=> console.log("User Created!")
          );
  }

  
  userSelected(user:User)
  {
    // ine 46 is testing to make edit button disappear
    //this.userIsClicked.buttonClicked.emit();
    console.log("User component - user clicked...", user);
    this.user = user;    
  }

  editUser()
  {

  }


  setRow(i:number)
  {
    this.selectedIndex = i;
  }



  userWasSelected(user:User){
    console.log("User component new selection model - user clicked...", user);
    this.user = user;
    this.users$.subscribe(users =>{

      for(let b of users){
        if(b.id ==  user.id){
          this.selectedUser = b;
          this.selectedUser.hl = true;

        
        }
        else{
          b.hl = false;
        }

      }
    })

  }


}
