import { Component } from '@angular/core';

import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { SignalRClientService } from '../../SignalRService/signal-rclient.service';
import { HttpClient } from '@angular/common/http';
import {SignalRData} from '../../models/SignalRData'; 
import { SRConnectionData } from '../../models/SignalRC';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-signal-r',
  templateUrl: './signal-r.component.html',
  styleUrls: ['./signal-r.component.css']
})
export class SignalRComponent {

  private message:SignalRData = {} as SignalRData;
  private storeData:SRConnectionData = {} as SRConnectionData;
  userIsLoggedIn= false;
  constructor(private signalRService: SignalRClientService, private userSvc: UserService)
   {


    let userLoggedIn = this.userSvc.GetLoggedInUser();
    if(userLoggedIn!==null)
    {
      this.userIsLoggedIn = true;
    }

    this.userSvc.UserStateChanged.subscribe((userLogedInMsg)=>{
      this.userIsLoggedIn = userLogedInMsg;
    })

    }


  public sendMessage = (userName:string, txtMsg:string) => {
    //userName:string, txtMsg:string
    this.message.UserName = userName;
    this.message.TxtMsg = txtMsg;
    this.signalRService.broadcastData(this.message);
    //this.signalRService.broadcastDataUserId(this.message);
  }

  public sendToken(room:string)
  {
    this.storeData.room = room;
    this.storeData.connectionId = "";
    this.storeData.token = this.userSvc.getUserToken();
    if(this.storeData.token)
    {
      this.signalRService.storeToken(this.storeData);
    }
    
  }



  public sendRoom(room:string)
  {
    this.storeData.room = room;
    this.storeData.connectionId = "";
    this.storeData.token = "";

      this.signalRService.storeConnection(this.storeData);
    
  }

}

//npm install ng2-charts --save
//npm install chart.js --save