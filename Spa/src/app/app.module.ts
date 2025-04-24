//my imports

import { HttpClientModule } from '@angular/common/http';
import { FormsModule} from '@angular/forms';

//import your services too
import { UserService } from './myModules/services/user.service';
//
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './myModules/components/user/user/user.component';
import { CreateuserComponent } from './myModules/components/user/createuser/createuser.component';
import { EdituserComponent } from './myModules/components/user/edituser/edituser.component';
import { HomeComponent } from './myModules/components/home/home.component';
import { LandingComponent } from './myModules/components/landing/landing.component';
import { NavbarComponent } from './myModules/components/navbar/navbar.component';
import { AuthguardService } from './myModules/services/authguard.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SignalRComponent } from './myModules/components/signal-r/signal-r.component';
import { SignalRClientService } from './myModules/SignalRService/signal-rclient.service';
import { FirectiveDirective } from './firective.directive';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    CreateuserComponent,
    EdituserComponent,
    HomeComponent,
    LandingComponent,
    NavbarComponent,
    SignalRComponent,
    FirectiveDirective,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    //my imports
    HttpClientModule,
    FormsModule,
    FontAwesomeModule

  ],
  //add UserApiService in the providers array
  providers: [UserService, AuthguardService, SignalRClientService],
  bootstrap: [AppComponent],
})
export class AppModule { }
 
