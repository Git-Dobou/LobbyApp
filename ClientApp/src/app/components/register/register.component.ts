import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-register-component',
  templateUrl: './register.component.html'
})
export class RegisterComponent {

  constructor(public loginService: LoginService) { }
}
