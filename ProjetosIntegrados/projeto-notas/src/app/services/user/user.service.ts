import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  testApi(){
    return this.http.get('https://localhost:7184/WeatherForecast');
  }
}
