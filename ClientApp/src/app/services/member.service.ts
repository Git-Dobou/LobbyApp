import { Component, Injectable, Inject } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IMember } from '../models/IMember';

export class MemberService {

  Members: BehaviorSubject<IMember[]> = new BehaviorSubject([]);

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.requestMember();
  }

  requestMember() {
    this.http.get(this.baseUrl + 'api/Member/GetAllMembers').subscribe((data: IMember[]) => {
      this.Members.next(data);
    });
  }
}
