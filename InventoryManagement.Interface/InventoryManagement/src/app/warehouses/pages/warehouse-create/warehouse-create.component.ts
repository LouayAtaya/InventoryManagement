import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ContentHeaderService } from 'src/app/core';
import { WarehouseForCreation } from '../../../core/models/warehouse-for-creation';

@Component({
  selector: 'app-warehouse-create',
  templateUrl: './warehouse-create.component.html',
  styleUrls: ['./warehouse-create.component.css']
})
export class WarehouseCreateComponent implements OnInit {

  warehouseForCreation:WarehouseForCreation;

  constructor(private contentHeaderService:ContentHeaderService) { }
  
  ngOnInit() {
    this.contentHeaderService.setMainHeaderTitle("إضافة مصنع/ مخزن جديد")
    this.warehouseForCreation=new WarehouseForCreation();
  }

  onSubmit(warehouseForm:NgForm){

    console.log(this.warehouseForCreation);

  }

  reset(warehouseForm :NgForm) {
    warehouseForm.resetForm();
  }

}
