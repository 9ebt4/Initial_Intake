import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Bed } from '../Model/bed';

@Injectable({
  providedIn: 'root'
})
export class BedService {

  constructor(@Inject('BASE_URL') private baseURL:string, private http:HttpClient) { }

  url:string = `${this.baseURL}api/Bed`
  GetBeds():Observable<Bed[]>{
    return this.http.get<Bed[]>(this.url);
  }
}
