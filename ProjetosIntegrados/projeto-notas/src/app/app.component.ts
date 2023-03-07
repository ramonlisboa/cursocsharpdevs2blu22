import { UserService } from './services/user/user.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'projeto-notas';

  constructor(public service: UserService) {
    this.service.testApi().subscribe(
      (response) => {
        console.log(response);
      }
    );
  }
}
