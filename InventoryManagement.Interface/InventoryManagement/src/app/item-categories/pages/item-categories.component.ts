import { Component, OnInit } from '@angular/core';
import { ContentHeaderService, ItemCategoriesService, ItemCategory } from 'src/app/core';

@Component({
  selector: 'app-item-categories',
  templateUrl: './item-categories.component.html',
  styleUrls: ['./item-categories.component.css']
})
export class ItemCategoriesComponent implements OnInit {

  constructor(private itemCategoriesService:ItemCategoriesService,private contentHeaderService:ContentHeaderService) { }

  itemCategories:ItemCategory[];

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("التصنيفات")
    
    this.itemCategoriesService.GetItemCategories().subscribe(
      data=>{
        this.itemCategories=data;
      },
      error=>{

      }
    )
  }

}
