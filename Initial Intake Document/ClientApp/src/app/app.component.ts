import { Component } from '@angular/core';
import { BedService } from './Service/bed.service';
import { Bed } from './Model/bed';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(private bedService:BedService){}
  ngOnInit(){
    this.GetBeds()
  }
  GetBeds(){
    this.bedService.GetBeds().subscribe((response:Bed[])=>{
      console.log(response);
    }
    )
  }
}
