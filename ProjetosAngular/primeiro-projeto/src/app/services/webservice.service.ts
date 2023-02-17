import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WebserviceService {

  constructor(public http: HttpClient) { }

  getPokemonData(){
    return this.http.get('https://pokeapi.co/api/v2/pokemon/');
  }
}
