import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { User } from 'src/app/myModules/models/user';

@Component({
  selector: 'app-createuser',
  templateUrl: './createuser.component.html',
  styleUrls: ['./createuser.component.css']
})
export class CreateuserComponent implements OnInit {
  @Input()
  user:User = {} as User;

  firstName: string = ''
  lastName:string = ''
  email:string = ''
  password:string = ''
  

  @Output('createUser')
    createUserEmitter = new EventEmitter<User>();


  constructor() { }

  ngOnInit(): void {
  }


  onClickCreate()
  {

    this.user.lastName = this.lastName;
    this.user.firstName = this.firstName;
    this.user.email = this.email;
    this.user.password = this.password;

    

    this.createUserEmitter.emit({...this.user});
  }


}
