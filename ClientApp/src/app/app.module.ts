import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injectable } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { SessionsComponent } from './components/sessions/sessions.component';
import { ReportComponent } from './components/report/report.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { MyComponent } from './components/my/my.component';

import { SessionService } from './services/sessions.service';
import { LoginService } from './services/login.service';
import { MemberService } from './services/member.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private loginService: LoginService,
        private router: Router) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): boolean {

        if (this.loginService.IsMemberLoged.value === false) {
            this.router.navigate(['/login']);
        }

        return this.loginService.IsMemberLoged.value;
    }
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SessionsComponent,
    ReportComponent,
    LoginComponent,
    RegisterComponent,
    MyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'register', component: RegisterComponent },
      { path: 'sessions', component: SessionsComponent, canActivate: [AuthGuard]  },
      { path: 'report', component: ReportComponent, canActivate: [AuthGuard] },
      { path: 'my', component: MyComponent, canActivate: [AuthGuard]  },
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [SessionService,
    LoginService, MemberService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }


