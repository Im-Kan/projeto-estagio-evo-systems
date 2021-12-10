import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css']
})
/** form component*/
export class FormComponent implements OnInit {

  departamentput: any;
  formDepartament = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    sigla: new FormControl('')
  });

    /** form ctor */
  constructor() { }
  ngOnInit() { }

  formput() {
    this.departamentput = this.formDepartament.value;
  }
}
