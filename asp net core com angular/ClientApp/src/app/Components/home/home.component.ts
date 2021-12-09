import { Component, OnInit } from '@angular/core';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  departaments = new Departaments();
  workers = new Workers();
  erro: any;
  constructor(private crudService: CrudService) {
    this.getWorkers();
    this.getDepartaments();
  }
  ngOnInit() { }
  getDepartaments() {
    this.crudService.getDepartaments().subscribe((data: Departaments) => {
      this.departaments = data
      console.log("o data q recebemos",this.departaments);
      console.log("a variavel q preenchemos",data);
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }
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
}
