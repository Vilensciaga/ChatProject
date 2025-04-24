import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Login } from '../models/login';
import { Token } from '../models/token';
import { JwtHelperService } from '@auth0/angular-jwt';
//import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = 'https://localhost:7188';
  //private url = 'http://172.20.10.2:7188';
  //private url = 'https://192.168.0.62:7188';

  userIsLoggedIn: boolean =false;

  @Output() UserStateChanged = new EventEmitter<boolean>();

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    const params = new HttpParams()
    .set("page", "1")
    .set("pageSize", "5");

    //return this.http.get<any>(`${this.url}`);
    return this.http.get<User[]>(this.url + '/users');
  }

  createUser(user:User): Observable<User>{
    return this.http.post<User>(`${this.url}/users`, user);
  }

  signInUser(auth:Login): Observable<string>{
    return this.http.post<string>(`${this.url}/api/Login/authenticate`, auth);
  }

  editUser(userId:number, user:User, headers:HttpHeaders): Observable<User>{
    return this.http.put<User>(`${this.url}/users/${userId}`,user,{headers})
  }
  

  SetUserLoggedIn(userToken:string)
  {
    localStorage.setItem('token',JSON.stringify(userToken));
    this.UserStateChanged.emit(true);
  }

  SetUserAsLoggedOff()
  {
    localStorage.removeItem('token');
    this.UserStateChanged.emit(false);
  }

  getUserToken()
  {
    return localStorage.getItem('token')?.toString();   
  }

  GetLoggedInUser()
  {
    
    let tokenString= localStorage.getItem('token');

    const jwtHelper = new JwtHelperService();

    if(tokenString!==null)
    {
      //let tokenObj = JSON.parse(tokenString) as {token:string};
      //let tokenInfo =<Token>jwt_decode(tokenObj.token);

      const decodedToken = jwtHelper.decodeToken(tokenString);
      // const isExpired = jwtHelper.isTokenExpired(tokenString);
      // const expirationDate = jwtHelper.getTokenExpirationDate(tokenString);
      
      return decodedToken;
    }
    else
      return null;
  }



  

}


