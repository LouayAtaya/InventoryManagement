import { Component, OnInit } from '@angular/core';
import { ContentHeaderService, Item, ItemsService } from 'src/app/core';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {

  constructor(private itemService:ItemsService,private contentHeaderService:ContentHeaderService) { }

  items:Item[];

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("المنتجات")

    this.itemService.GetItems().subscribe(
      data=>{
        this.items=data;

      },
      error=>{

      }
    )
  }

}
