import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './myModules/components/landing/landing.component';
import { HomeComponent } from './myModules/components/home/home.component';
import { AuthguardService } from './myModules/services/authguard.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SignalRComponent } from './myModules/components/signal-r/signal-r.component';

const routes: Routes = [
  {
    component:LandingComponent,
    path: ""
  },
  {
    component: HomeComponent,
    path: "home",
    canActivate: [AuthguardService]
  },
  {
    component: SignalRComponent,
    path: "sr"
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
