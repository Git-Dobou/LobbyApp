import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { MemberService } from '../../services/member.service';
import { SessionService } from '../../services/sessions.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  get form() { return this.loginForm.controls; }

  constructor(public loginService: LoginService,
    public memberService: MemberService,
    public sessionService: SessionService,
    private formBuilder: FormBuilder) {

    this.memberService.requestMember();
    this.sessionService.requestSessions();
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['Daniel486', Validators.required],
      password: ['test', Validators.required]
    });

    // reset login status
    this.loginService.logout();

    // get return url from route parameters or default to '/'
  }
  onSubmit() {
    

    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;

    this.loginService.login(this.form.username.value, this.form.password.value);
  }
}
