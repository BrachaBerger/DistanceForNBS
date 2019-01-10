import { Component, OnInit, Input } from '@angular/core';
import { DistanceService } from '../shared/distance.service';
import { Distance } from '../shared/distance.model';

@Component({
  selector: 'app-popular-distance-modal',
  templateUrl: './popular-distance-modal.component.html',
  styleUrls: ['./popular-distance-modal.component.scss']
})
export class PopularDistanceModalComponent implements OnInit {

   @Input() distance:number;
   @Input() popularDistance:Distance;

  constructor() { }

  ngOnInit() {
      

  }
  
}
