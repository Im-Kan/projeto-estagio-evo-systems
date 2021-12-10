import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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
    return this.http.post("http://localhost:23283/api/workers", departament);
  }
  public putDepartament(id: any ,departament: any) {
    return this.http.put(`${this.based}/${id}`, departament);
  }
  public postWorker(worker: any) {
    return this.http.post("http://localhost:23283/api/workers", worker);
  }
  public putWorker(id: any, worker: any) {
    return this.http.put(`${this.basew}/${id}`, worker);
  }
  public deleteWorker(id: any) {
    return this.http.get(`${this.basew}/${id}`);
  }
  public deleteDepartament(id: any) {
    return this.http.get(`${this.based}/${id}`);
  }
}
