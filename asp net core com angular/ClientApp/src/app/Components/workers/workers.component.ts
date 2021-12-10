import { Component, OnInit } from '@angular/core';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
})
export class WorkerComponent implements OnInit {
  departaments = new Departaments();
  workers = new Workers();
  erro: any;
  public selectedWorker: string;
  constructor(private crudService: CrudService) {
    this.getWorkers();

  }
  ngOnInit() { }
  getWorkers() {
    this.crudService.getWorkers().subscribe((data: Workers) => {
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
