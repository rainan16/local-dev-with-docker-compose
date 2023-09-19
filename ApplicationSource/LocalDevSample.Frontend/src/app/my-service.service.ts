import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as api from './api-endpoints';

@Injectable({
  providedIn: 'root'
})
export class MyServiceService {

  constructor(private http: HttpClient) { }

  getServiceA(): Observable<string> {
    return this.http.get<string>(api.SERVICEA);
  }  

  getServiceB(): Observable<string> {
    return this.http.get<string>(api.SERVICEB);
  }  
}
