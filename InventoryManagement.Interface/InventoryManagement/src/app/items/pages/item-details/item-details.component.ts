import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, RouterLinkActive } from '@angular/router';
import { ItemsService } from '../../../core/services/items.service';
import { ItemDetails } from '../../../core/models/item-details';
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

  constructor( private ItemsService:ItemsService, private route:ActivatedRoute, private router:Router) {
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
    this.ItemsService.GetItemDetails(id).subscribe(
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

}
