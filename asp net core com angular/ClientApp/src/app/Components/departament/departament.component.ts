import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
    selector: 'app-departament',
    templateUrl: './departament.component.html',
    styleUrls: ['./departament.component.css']
})
/** departament component*/
export class DepartamentComponent implements OnInit {
  //vars
  depId = this.route.snapshot.paramMap.get('id');
  
  workers = new Workers();
  wworkers = new Workers();
  wname = 's';
  erro: any;
  id: any;
  public selectedWorker: string;
  public selectedWorker2: string
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
    
    this.getworkers();
    this.criarForm();
    this.criarFormPost();
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id']; 
    });
      }
//get
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
  getworkersbyid() {
    this.crudService.getWorkerByID(this.depId).subscribe((data: Workers) => {
      this.wworkers = data
      console.log("o data q recebemos", this.workers);
      console.log("a variavel q preenchemos", data);
      return data
    },
      (error: any) => {
        this.erro = error;
        console.error("ERRO", error);
      });
  }
  //hide show buttons
  selectWorker(worker: any) {
    this.selectedWorker = worker;
    this.getworkersbyid();
  }
  selectWorker2(worker2: any) {
    this.selectedWorker2 = worker2;
  }
  //forms
  criarForm() {
    this.formWorkerPut = this.fb.group({
      id: [this.workers.id],
      name: [this.wname],
      rg: [this.workers.rg],
      foto: [this.workers.foto],
      departamentId: [this.depId]
    });
  }

  criarFormPost() {
    this.formWorkerPost = this.fb.group({
      name: [this.workers.name],
      rg: [this.workers.rg],
      foto: [this.workers.foto],
      departamentId: [this.depId]
    });
  }

  //reload
  reloadComponent() {
    setTimeout(() => {
      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    }, 1000)
    
  }

  //post
  saveWorkerPost() {

    this.workerpost = this.formWorkerPost.value;
    console.log(this.workerpost);
    this.sendpostrequest();

    this.reloadComponent();

  }
  sendpostrequest() {
    this.crudService.postWorker(this.workerpost).subscribe(
      (worker: any) => { console.log(worker) },
      (erro: any) => { console.log(erro) }
    );
  }
  //delete
  deleteWorker(id) {
    this.crudService.deleteWorker(id).subscribe(
      (id: any) => { console.log(id) },
      (error: any) => { console.log(error) }
    );
    this.reloadComponent();
  }

  //put
  saveWorker() {
    this.workerput = this.formWorkerPut.value;

    console.log(this.workerput);
    this.sendputrequest();
    this.reloadComponent();

  }
  sendputrequest() {
    this.crudService.putWorker(this.workerput).subscribe(
      (departament: any) => { console.log(departament) },
      (erro: any) => { console.log(erro) }
    );
  }

}
