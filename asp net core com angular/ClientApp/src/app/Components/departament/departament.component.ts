import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
    selector: 'app-departament',
    templateUrl: './departament.component.html',
    styleUrls: ['./departament.component.css']
})
/** departament component*/
export class DepartamentComponent implements OnInit {
  workers = new Workers();
  erro: any;
  id: any;
  public selectedWorker: string;
 depId = this.route.snapshot.paramMap.get('id');

  constructor(private crudService: CrudService,
    private route: ActivatedRoute) {
    
    this.getworkers();
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id']; 
    });
      }
  getid() {

    }
  getworkers() {
    this.crudService.getworkerbydi(this.depId).subscribe((data: Workers) => {
      this.workers = data
      console.log("o data q recebemos", this.workers);
      console.log("a variavel q preenchemos", data);
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }
  selectWorker(worker: any) {
    this.selectedWorker = worker.name;
  }
}
