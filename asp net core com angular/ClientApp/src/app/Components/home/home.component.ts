import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Departaments, Workers } from '../../models/Models.Model';
import { CrudService } from '../../services/crud.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  //variables
  departaments = new Departaments();
  erro: any;
  id: number;
  public selectedDepartament: string;
  public selectedDepartament2: string;
  //PUT Form Variables
  departamentput: Departaments;
  departamentpost: Departaments;
  formDepartament = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    sigla: new FormControl('')
  });
  //POST Form Variables
  formDepartamentPost = new FormGroup({
    name: new FormControl(''),
    sigla: new FormControl('')
  });
  //constructor
  constructor(
    private crudService: CrudService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) {

    this.getDepartaments();
    this.criarForm();
  }
  //init
  ngOnInit() {
 
  }
  //Forms

  criarForm() {
    this.formDepartament = this.fb.group({
      id: [''],
      name: [''],
      sigla: ['']
    });
  }

  criarFormPost() {
    this.formDepartamentPost = this.fb.group({
      name: [''],
      sigla: ['']
    });
  }
  //getrequest

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
  //deletedepartament
  deleteDepartament(id) {
    this.crudService.deleteDepartament(id).subscribe(
      (id: any) => { console.log(id) },
      (error: any) => { console.log(error) }
    );
    this.reloadComponent();
  }



  //reload
  reloadComponent() {
    let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate([currentUrl]);
  }

  //Para esconder/mostrar os botões
  selectDepartament(departament: any) {
    this.selectedDepartament = departament;
  }
  selectDepartament2(departament2: any) {
    this.selectedDepartament2 = departament2;
  }
  //putrequest
  saveDepartament() {
    this.departamentput = this.formDepartament.value;
   
    console.log(this.departamentput);
    this.sendputrequest();
    this.reloadComponent();
    
  }
  sendputrequest() {
    this.crudService.putDepartament(this.departamentput).subscribe(
      (departament: any) => { console.log(departament) },
      (erro: any) => { console.log(erro) }
    );
  }
  //postrequest
  saveDepartamentPost() {
   
      this.departamentpost = this.formDepartamentPost.value;
      console.log(this.departamentpost);
      this.sendpostrequest();
    
    this.reloadComponent();
    
  }
  sendpostrequest() {
    this.crudService.postDepartament(this.departamentpost).subscribe(
      (departament: any) => { console.log(departament) },
      (erro: any) => { console.log(erro) }
    );
  }
}
