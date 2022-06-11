import { Component, EventEmitter, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Warehouse, WarehousesService } from 'src/app/core';
import { ItemOperationsService } from '../../../core/services/item-operations.service';
import { ItemOperationForCreation } from '../../../core/models/item-operation-for-creation';
import { Output } from '@angular/core';

@Component({
  selector: 'app-item-operation-create',
  templateUrl: './item-operation-create.component.html',
  styleUrls: ['./item-operation-create.component.css']
})
export class ItemOperationCreateComponent implements OnInit, OnChanges {

  @Input("itemId") itemForUpdateId: number;
  itemOperationForm:FormGroup;

  @Output() itemOperationCreated: EventEmitter<boolean> = new EventEmitter()

  itemOperationForCreation:ItemOperationForCreation;

  warehousesList:Warehouse[];
  itemOperationTypes;

  constructor(private formBuilder: FormBuilder,private itemOperationsService: ItemOperationsService, private warehousesService: WarehousesService) { 
    this.itemOperationForm= formBuilder.group({
      itemId:[null,[Validators.required]],
      warehouseId:[null,[Validators.required]],
      affectedQuantity:[1,[Validators.required]] ,
      description:['',[Validators.maxLength(500)]],
      itemOperationType:[null,[Validators.required]],
      isActive:[true]
    })

    this.itemOperationTypes=itemOperationsService.itemOperationTypesMap;
  }

  ngOnInit(): void {
    this.getWarehousesList();

    this.affectedQuantity.valueChanges.subscribe(quantity => {
      if(quantity<1){
        this.affectedQuantity.setErrors({minQuantity:1});
      }
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    this.itemId.setValue(this.itemForUpdateId)
  }


  get itemId(){
    return this.itemOperationForm.get('itemId');
  }

  get warehouseId(){
    return this.itemOperationForm.get('warehouseId');
  }

  get affectedQuantity(){
    return this.itemOperationForm.get('affectedQuantity');
  }

  get description(){
    return this.itemOperationForm.get('description');
  }

  get itemOperationType(){
    return this.itemOperationForm.get('itemOperationType');
  }
 

  onSubmit(){
    this.itemOperationForCreation=new ItemOperationForCreation(this.itemOperationForm.value);

    this.itemOperationsService.addItemOperation(this.itemOperationForCreation)
      .subscribe(
        data=>{
          alert("created");
          this.itemOperationCreated.emit(true);

        },
        error=>{
          console.log("error")
          console.log(error)
          console.log("error")
          alert(error);
          this.itemOperationCreated.emit(false);

        }

      )
  }

  getWarehousesList(){
    this.warehousesService.GetWarehouses().subscribe(
      data=>{
        this.warehousesList=data;
      },
      error=>{

      }
    )    
  }

  

}
