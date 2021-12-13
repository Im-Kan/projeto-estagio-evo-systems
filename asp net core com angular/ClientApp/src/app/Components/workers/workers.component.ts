import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./home.component.css']
})
export class WorkerComponent implements OnInit {
  departaments = new Departaments();
  workers = new Workers();
  erro: any;
  public selectedWorker: string;
  //PUT Form Variables
  workerput: Departaments;
  workerpost: Departaments;
  formWorkerPut = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    rg: new FormControl(''),
    foto: new FormControl(''),
    departamentId: new FormControl('')
  });
  //POST Form Variables
  formWorkerPost = new FormGroup({
    name: new FormControl(''),
    rg: new FormControl(''),
    foto: new FormControl(''),
    departamentId: new FormControl('')
  });




  constructor(
    private crudService: CrudService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) {
    this.getWorkers();

  }
  ngOnInit() { }
  reloadComponent() {
    setTimeout(() => {
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    }, 1000)

  }
  //get
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
  
  //select
  selectWorker(worker: any) {
    this.selectedWorker = worker;
    this.criarForm(worker);
  }
  //forms
  criarForm(worker: Workers) {
    this.formWorkerPut = this.fb.group({
      id: [worker.id],
      name: [worker.name],
      rg: [worker.rg],
      foto: [worker.foto],
      departamentId: [worker.departamentId]
    });
  }

  criarFormPost(worker: Workers) {
    this.formWorkerPost = this.fb.group({
      name: [''],
      rg: [''],
      foto: [''],
      departamentId: ['']
    });
  }
  deleteWorker(id) {
    this.crudService.deleteWorker(id).subscribe(
      (id: any) => { console.log(id) },
      (error: any) => { console.log(error) }
    );
    this.reloadComponent();
  }

}
