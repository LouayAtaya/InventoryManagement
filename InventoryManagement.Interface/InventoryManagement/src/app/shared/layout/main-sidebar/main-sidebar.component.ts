import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    //this.loadScripts()


  }
 
  loadScripts(){
    const dynamicScripts=[
      "assets/plugins/jquery/jquery.min.js",
      "assets/plugins/bootstrap/js/bootstrap.bundle.min.js",
      "assets/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
      "assets/js/adminlte.js",
      "assets/plugins/jquery-mousewheel/jquery.mousewheel.js",
      "assets/plugins/raphael/raphael.min.js",
      "assets/plugins/jquery-mapael/jquery.mapael.min.js",
      "assets/plugins/jquery-mapael/jquery.mapael.min.js",
      "assets/plugins/jquery-mapael/maps/usa_states.min.js",
      "assets/plugins/chart.js/Chart.min.js",
      "assets/js/demo.js",
      "assets/js/pages/dashboard2.js",
    ];

    for(let i=0; i< dynamicScripts.length;i++){
      const node=document.createElement('script');
      node.src= dynamicScripts[i];
      node.type='text/javascript';
      node.async=false;
      document.getElementsByTagName('head')[0].appendChild(node);

    }
  }


}
