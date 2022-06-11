import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, RouterLinkActive } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { ItemDetails, ItemOperation,ItemOperationsService,ItemsService } from 'src/app/core';
import { itemTypeList } from 'src/app/core/models/item-types-list';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {

  @ViewChild('selectedImage',{static:false}) selectedImage: ElementRef;
  itemId:number;
  itemDetails:ItemDetails;
  itemOperations:ItemOperation[];

  constructor( private itemsService:ItemsService,private itemOperationsService:ItemOperationsService, private route:ActivatedRoute, private router:Router) {
    this.itemDetails=new ItemDetails();
   }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params=>{
        this.itemId=Number.parseInt(params.get("id"))

        this.getItemDetails(this.itemId);
      }
    )
  }

  getItemDetails(id:number){
    this.itemsService.GetItemDetails(id).subscribe(
      data=>{
        this.itemDetails=data;
        this.assignItemTypeName();
      },
      error=>{
        this.router.navigateByUrl("test")

      }
    )
  }

  private defaultItemTypes=itemTypeList;
  assignItemTypeName(){
      this.defaultItemTypes.forEach(el=>{
        if(this.itemDetails.itemType==el.itemTypeId)
          this.itemDetails.itemTypeName=el.ItemTypeName;
      })
  }

  
  onImageChange(imageElement : HTMLImageElement){

    this.selectedImage.nativeElement.src=imageElement.src
  }

  getItemOperations(){
    this.itemOperationsService.getItemOperationByItem(this.itemId).subscribe(
      data=>{
          this.itemOperations=data;
      },
      error=>{
        alert("itemOperation:error")
      }
    )
  }

}
