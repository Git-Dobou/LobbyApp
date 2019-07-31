import { Component, Injectable, Inject } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ISession } from '../models/ISession';

export class SessionService {

  Sessions: BehaviorSubject<ISession[]> = new BehaviorSubject([]);
  CurrentSession: BehaviorSubject<ISession> = new BehaviorSubject({});

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.requestSessions();
  }

  requestSessions() {
    this.http.get(this.baseUrl + 'api/Session/GetAllSessions').subscribe((data: ISession[]) => {
      this.Sessions.next(data);

      console.log(this.Sessions.value);
    });
  }

  selectSession(session: ISession) {
    this.CurrentSession.next(session);
  }
}
