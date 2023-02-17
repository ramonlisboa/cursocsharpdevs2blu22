import { WebserviceService } from './../../services/webservice.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public service: WebserviceService){}

  ngOnInit(): void {
    const list = this.service.getPokemonData();
    list.subscribe(
      resp => {
        console.log(resp);
      }
    )
  }
}
