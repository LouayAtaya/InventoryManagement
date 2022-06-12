import { Component, OnInit } from '@angular/core';
import { ContentHeaderService, Warehouse, WarehousesService } from 'src/app/core';

@Component({
  selector: 'app-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.css']
})
export class WarehousesComponent implements OnInit {

  constructor(private warehouseService: WarehousesService,private contentHeaderService:ContentHeaderService) { }

  warehouses: Warehouse[];

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("المصانع والمخازن")
    this.warehouseService.GetWarehouses().subscribe(
      data=>{
        this.warehouses=data;
      },
      error=>{

      }
    )
  }

}
