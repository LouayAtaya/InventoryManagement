import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-header',
  templateUrl: './main-header.component.html',
  styleUrls: ['./main-header.component.css']
})
export class MainHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

    this.loadScript('../assets/js/adminlte.js')
   
    //this.loadScript('../assets/js/pages/dashboard2.js')
  }

  public loadScript(url:string){
    const body=<HTMLDivElement> document.body;
    const script= document.createElement('script');
    script.innerHTML='';
    script.src=url;
    script.async=false;
    script.defer=true;
    //console.log(script)
    body.appendChild(script);
  }

}
