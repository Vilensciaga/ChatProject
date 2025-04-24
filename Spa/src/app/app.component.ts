import { Component, OnInit } from '@angular/core';
import { User } from './myModules/models/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserService } from './myModules/services/user.service';
import { SignalRClientService } from './myModules/SignalRService/signal-rclient.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  


  constructor(private signalRService: SignalRClientService, userSvc:UserService) { }

  ngOnInit(): void {
    //this.signalRService.startConnection();
    //this.signalRService.addTransferDataListener();
    //this.signalRService.addBroadcastDataListener();
    //this.signalRService.addBroadcastDataUserListener();
    


    
    //this.signalRService.StartRequest();
  }




  //change to localhost in user.service.ts and wsclient.service.ts
  //or to the computers ip


}
