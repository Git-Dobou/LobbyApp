import { Component, Inject, OnInit } from '@angular/core';
import { SessionService } from '../../services/sessions.service';

@Component({
  selector: 'app-report-component',
  templateUrl: './report.component.html'
})
export class ReportComponent implements OnInit {

  constructor(public sessionService: SessionService) { }

  ngOnInit(): void {
  }

  canDeactivate(): boolean {
    this.sessionService.CurrentSession.next({});
    return true;
  }
}
