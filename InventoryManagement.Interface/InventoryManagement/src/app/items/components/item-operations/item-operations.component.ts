import { Component, Input, OnInit } from '@angular/core';
import { ItemOperation, ItemOperationsService, ItemOperationType } from 'src/app/core';

@Component({
  selector: 'app-item-operations',
  templateUrl: './item-operations.component.html',
  styleUrls: ['./item-operations.component.css']
})
export class ItemOperationsComponent implements OnInit {

  @Input() itemOperations: ItemOperation[];
  @Input() itemId: number;

  displayedColumns=['id','warehouseName','previousQuantity','affectedQuantity','description','itemOperationType','createdAt']

  constructor(private itemOperationsService:ItemOperationsService) { }

  ngOnInit(): void {
  }

  getItemOperationType(status:ItemOperationType){
    return this.itemOperationsService.getItemOperationType(status);
  }

  newOperationSubmitHandler(itemOperationCreated){
    if(itemOperationCreated){
      
    }

  }

}
