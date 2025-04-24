import { Component, OnInit } from '@angular/core';
import { User } from './myModules/models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserService } from './myModules/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  


  constructor() { }

  ngOnInit(): void {
    
  }




  //change to localhost in user.service.ts and wsclient.service.ts
  //or to the computers ip


}
