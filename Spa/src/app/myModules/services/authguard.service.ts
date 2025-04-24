import { Injectable } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate{

  constructor(  private userService: UserService, route:ActivatedRoute, private router:Router) { }


  //check if user is logged in
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let userInfo = this.userService.GetLoggedInUser();

    if(userInfo===null || new Date(userInfo.exp*1000)< new Date())
    {
      this.userService.SetUserAsLoggedOff();
      this.router.navigate(['/',{msg:'You must be logged in to access this page!'}]);
      return false;
    }
    else
      return true;

  }
}
