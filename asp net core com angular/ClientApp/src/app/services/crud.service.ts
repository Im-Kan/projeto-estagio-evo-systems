import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departaments } from '../models/Departament.Model';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  constructor(private http: HttpClient) { }
  public getDepartaments(): Observable<any> {
    return this.http.get("http://localhost:23283/api/departaments");
  }
  public getWorkers(): Observable<any> {
    return this.http.get("http://localhost:23283/api/workers");
  }

}
