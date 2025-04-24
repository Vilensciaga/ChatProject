import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import {SignalRData} from '../models/SignalRData'; 
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SRConnectionData } from '../models/SignalRC';
import { UserService } from '../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRClientService {

//npm install @microsoft/signalr
private hubConnection!: HubConnection;
public data!: SignalRData[];
public sentData!: SignalRData[];
private connectionId!:string;
private userId!:string;

private url = "https://localhost:7269/hub";
private reqUrl = "https://localhost:7269/SignalR";

// private url = "http://172.20.10.2:7269/hub";
// private reqUrl = "http://172.20.10.2:7269/SignalR";


// private url = 'https://192.168.0.62:7269/hub';
// private reqUrl = "https://192.168.0.62:7269/SignalR";

  constructor( private http: HttpClient, private userService: UserService, private router:Router, private route:ActivatedRoute) { }

  //connecting
  public startConnection = () => {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.url,
        {
          //skipNegotiation: true,
          //transport: this.hubConnection.HttpTransportType.WebSockets,
          headers: {
            "Access-Control-Allow-Origin": "http://172.20.10.2:4200"
          }
        }) // Replace with your SignalR hub URL
        .withAutomaticReconnect()
      .build();
  
    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started.'))
      .then(() => this.getConnectionId())
      .catch(err => console.error('Error while starting SignalR connection: ', err));


      // setTimeout(() => {
      //   if (this.hubConnection.state === signalR.HubConnectionState.Disconnected) {
      //     console.log('Reconnecting to SignalR...');
      //     this.startConnection();
      //   }
      // }, 5000);


    
  }


  //recieving data from the server
  public addTransferDataListener = () => {
    this.hubConnection.on('transferdata', (data) => {
      console.log("Server Data: ", data);   
      this.data = data;
    });
  }


//listener waiting for data from the server
  public addBroadcastDataListener = () =>
    {
      this.hubConnection.on('broadcastchartdata', (data) =>
      {
        this.sentData = data;
        console.log(data);
        var token = data.replace(/^"(.*)"$/, '$1');
        this.userService.SetUserLoggedIn(token);
                setTimeout(()=>{
                  this.router.navigate(["/home"]);

                }, 1000)

       
      })
    }



    // public addBroadcastDataUserListener = () =>
    // {
    //   this.hubConnection.on('broadcasttouser', (data) =>
    //   {
    //     this.sentData = data;
    //     console.log(data);
    //   })
    // }



  //sending data to the server
  public broadcastData = (data:SignalRData) =>
  {
      this.hubConnection.invoke('broadcastchartdata', data, this.connectionId)
      .catch(err => console.error(err));
  }

  public broadcastDataUserId = (data:SignalRData) =>
  {
      this.hubConnection.invoke('broadcasttouser', data, this.userId)
      .catch(err => console.error(err));
  }

  //get current connectionid
  private getConnectionId = () =>
  {
    this.hubConnection.invoke('getconnectionid')
    .then((data) => {
      console.log(data);
      this.connectionId = data;
    });
  }

  private getUserId = () =>
  {
    this.hubConnection.invoke('getuserid')
    .then((data) => {
      console.log(data);
      this.userId = data;
    });
  }

//start a request to get info from server, plz fuix
 public StartRequest = () =>{
    this.http.get<any>(this.reqUrl)
    .subscribe(res => {
      console.log(res);
    });
  }


  public storeConnection = (data:SRConnectionData) =>{
    data.connectionId = this.connectionId;
    this.http.post<SRConnectionData>(`${this.reqUrl}`, data)
    .subscribe(res => {
      console.log(res);
    });
  }

  public storeToken = (data:SRConnectionData) =>{
    data.connectionId = this.connectionId;
    this.http.post<SRConnectionData>(`${this.reqUrl}/token`, data)
    .subscribe(res => {
      console.log(res);
    });
  }
}
