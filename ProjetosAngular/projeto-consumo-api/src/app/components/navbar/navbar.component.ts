import { ListModel } from './../../models/list-model';
import { ApiService } from './../../service/api.service';
import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public service: ApiService){}

  ngOnInit(): void {
    this.getMenusByUser().subscribe(
      (resp) => {
        //Criar o MENU
      }
    )
  }

  getMenusByUser(): Observable<ListModel>{
    return of(ListModel);
  }
}
