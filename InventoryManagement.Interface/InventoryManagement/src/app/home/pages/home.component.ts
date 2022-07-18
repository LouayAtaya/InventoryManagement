import { Component, OnInit } from '@angular/core';
import { ContentHeaderService } from 'src/app/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private contentHeaderService:ContentHeaderService, private router:Router) {
  

   }

  isAuthenticated=false;

  ngOnInit(): void {

   /* if(!this.isAuthenticated)
      this.router.navigate(['login'])*/
      
    /*this.loadScript('../assets/plugins/jquery/jquery.min.js')
    this.loadScript('../assets/plugins/bootstrap/js/bootstrap.bundle.min.js')
    this.loadScript('../assets/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js')
    this.loadScript('../assets/js/adminlte.js')
    this.loadScript('../assets/plugins/jquery-mousewheel/jquery.mousewheel.js')
    this.loadScript('../assets/plugins/raphael/raphael.min.js')
    this.loadScript('../assets/plugins/jquery-mapael/jquery.mapael.min.js')
    this.loadScript('../assets/plugins/jquery-mapael/maps/usa_states.min.js')
    this.loadScript('../assets/plugins/chart.js/Chart.min.js')
    this.loadScript('../assets/js/demo.js')
    this.loadScript('../assets/js/pages/dashboard2.js')*/
  }

  

  public loadScript(url:string){
    const body=<HTMLDivElement> document.body;
    const script= document.createElement('script');
    script.innerHTML='';
    script.src=url;
    script.async=false;
    script.defer=true;
    console.log(script)
    body.appendChild(script);
  }

}
