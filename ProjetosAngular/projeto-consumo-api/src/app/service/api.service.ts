import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public URL_API:string = 'https://pokeapi.co/api/v2';

  constructor(public http: HttpClient) { }
}
