import { Pokemon } from './../../models/api/pokemon-model';
import { ApiService } from './../../service/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  public pokemon:Pokemon = new Pokemon({});

  constructor(public service: ApiService,
              public route: ActivatedRoute) {}

  ngOnInit(): void {
    let paramName = this.route.snapshot.paramMap.get('name');
    if(paramName) {
      this.service.getPokemonByName(paramName).subscribe(
        (resp) => {
          this.pokemon = resp;
        }
      );
    }
  }
}
