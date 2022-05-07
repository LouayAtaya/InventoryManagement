import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { WarehouseForCreation } from '../../../core/models/warehouse-for-creation';

@Component({
  selector: 'app-warehouse-create',
  templateUrl: './warehouse-create.component.html',
  styleUrls: ['./warehouse-create.component.css']
})
export class WarehouseCreateComponent implements OnInit {

  warehouseForCreation:WarehouseForCreation;

  constructor() { }
  
  ngOnInit() {
    this.warehouseForCreation=new WarehouseForCreation();
  }

  onSubmit(warehouseForm:NgForm){

    console.log(this.warehouseForCreation);

  }

  reset(warehouseForm :NgForm) {
    warehouseForm.resetForm();
  }

}
