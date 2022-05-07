import { Component, OnInit } from '@angular/core';
import { Item, ItemsService } from 'src/app/core';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  constructor(private itemService:ItemsService) { }

  items:Item[];

  ngOnInit(): void {
    this.itemService.GetItems().subscribe(
      data=>{
        this.items=data;
      },
      error=>{

      }
    )
  }

}
