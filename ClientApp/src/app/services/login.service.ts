import { Component, Injectable, Inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { IMember } from '../models/IMember';


export class LoginService {

  CurrentMemeber: BehaviorSubject<IMember> = new BehaviorSubject({});
  IsMemberLoged: BehaviorSubject<boolean> = new BehaviorSubject(false);

  toRegisterMember: IMember = {
    address: {}
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private router: Router, private jwtHelperService: JwtHelperService) { }

  login(user: string, password: string) {

    const member: IMember = {
      userName: user,
      password: password
    };

    const credentials = JSON.stringify(member);

    this.http.post(this.baseUrl + 'api/Login/LoginMember', credentials, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(response => {
      const token = (<any>response).token;

      const decodedToken = this.jwtHelperService.decodeToken(token);
      const expirationDate = this.jwtHelperService.getTokenExpirationDate(token);
      const isExpired = this.jwtHelperService.isTokenExpired(token);

      console.log(decodedToken);
      
      localStorage.setItem('jwt23', token);
      this.router.navigate(['/sessions']);
    }, err => {
    });
  }

  logout() {
    localStorage.removeItem('jwt');

  }
  register() {
    this.http.post(this.baseUrl + 'api/Member/RegisterMember', this.toRegisterMember).subscribe();
  }
}
