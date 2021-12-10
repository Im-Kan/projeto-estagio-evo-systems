import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  id: number;
  public selectedDepartament: string;
  constructor(private crudService: CrudService,
    private route: ActivatedRoute) {
    this.getWorkers();
    this.getDepartaments();
  }
  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        console.log(params);

        this.id = params.id;
        console.log(this.id);
      })
  }
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
  selectDepartament(departament: any) {
    this.selectedDepartament = departament.name;
  }
}
