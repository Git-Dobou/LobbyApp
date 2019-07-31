import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-my-component',
  templateUrl: './my.component.html'
})
export class MyComponent {

  constructor(public loginService: LoginService) { }
}
