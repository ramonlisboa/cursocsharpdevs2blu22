import { Pokemon } from './../models/api/pokemon-model';
import { ApiReturn } from './../models/api-return';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public URL_API:string = 'https://pokeapi.co/api/v2/pokemon';

  constructor(public http: HttpClient) { }

  getPokemonList() {
    return this.http.get<ApiReturn>(this.URL_API);
  }

  getPokemonByName(name: string) {
    return this.http.get<Pokemon>(`${this.URL_API}/${name}`);
  }

}
