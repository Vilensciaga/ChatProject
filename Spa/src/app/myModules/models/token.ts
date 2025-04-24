import { User } from "./user";



export class Token {
  userData = {} as User;
  firstName:string = "";
  laststName:string = "";
  email:string = "";
  exp: number = 0;

}