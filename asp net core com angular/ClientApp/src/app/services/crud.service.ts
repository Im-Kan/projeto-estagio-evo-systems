import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departaments } from '../models/Models.Model';

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  basew = "http://localhost:23283/api/workers";
  based = "http://localhost:23283/api/departaments"

  constructor(private http: HttpClient) { }
  public getDepartaments(): Observable<any> {
    return this.http.get("http://localhost:23283/api/departaments");
  }
  public getWorkers(): Observable<any> {
    return this.http.get("http://localhost:23283/api/workers");
  }
  public getworkerbydi(id: any): Observable<any> {
    return this.http.get(`${this.basew}/${id}`);
  }
  public postDepartament(departament: any) {
    return this.http.post("http://localhost:23283/api/departaments", departament);
  }
  public putDepartament(departament: Departaments) {
    return this.http.put<JSON>(`${this.based}`, departament);
  }
  public postWorker(worker: any) {
    return this.http.post("http://localhost:23283/api/workers", worker);
  }
  public putWorker( worker: any) {
    return this.http.put(`${this.basew}`, worker);
  }
  public deleteWorker(id: any) {
    return this.http.delete(`${this.basew}/${id}`);
  }
  public deleteDepartament(id: any) {
    return this.http.delete(`${this.based}/${id}`);
  }
  public getWorkerByID(id: any) {
    return this.http.get(`${this.based}/one/${id}`)
  }
}
