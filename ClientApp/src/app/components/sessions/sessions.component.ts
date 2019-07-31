import { Component } from '@angular/core';
import { SessionService} from '../../services/sessions.service';
@Component({
  selector: 'app-sessions-component',
  templateUrl: './sessions.component.html'
})
export class SessionsComponent {

  constructor(public sessionService: SessionService) {}

}
