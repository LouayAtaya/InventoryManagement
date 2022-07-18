import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContentHeaderService } from 'src/app/core';

@Component({
  selector: 'app-home-content',
  templateUrl: './home-content.component.html',
  styleUrls: ['./home-content.component.css']
})
export class HomeContentComponent implements OnInit {

  constructor(private contentHeaderService:ContentHeaderService, private router:Router) { }

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("الصفحة الرئيسية")

  }

}
