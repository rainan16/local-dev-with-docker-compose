import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MyServiceService } from './my-service.service';

@Component({
  standalone: false,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit {
  title = 'frontend';
  dataa = '';
  datab = '';

  constructor(
    public router: Router,
    private servicea: MyServiceService,
    private serviceb: MyServiceService
  ) {  }


  ngOnInit(): void {
      this.servicea.getServiceA().subscribe(data => {
          this.dataa = data;
      })
      this.servicea.getServiceB().subscribe(data => {
        this.datab = data;
    })      
  }  
}