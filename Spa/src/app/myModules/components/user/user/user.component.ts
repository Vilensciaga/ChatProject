import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { UserService } from 'src/app/myModules/services/user.service';
import { CreateuserComponent } from 'src/app/myModules/components/user/createuser/createuser.component';
import { User } from 'src/app/myModules/models/user';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  @Input()
  user!: User;



  @Output('userSelected')
  userSelected = new EventEmitter<User>();

  //testing to make edit button disappear
  public isButtonVisible = false;
  private subscription!: Subscription;




  constructor(private userService: UserService) { }


  ngOnInit() {
    // //testing to make edit button disappear
    // this.subscription = this.userIsClicked.buttonClicked.subscribe(() => {
    //   this.isButtonVisible = true;
    // });
    
  }

  // //testing to make edit button disappear
  // ngOnDestroy(): void {
  //   this.subscription.unsubscribe();
  // }


  //Create user properties
  modalTitle: string = '';
  activateCreateUserComponent: boolean = false;

  userSelectedTrue()
  {  
    this.userSelected.emit({...this.user});
    this.user = {...this.user}
  
  }




  editUser()
  {  
    console.log("edit button clicked");
  }

}
