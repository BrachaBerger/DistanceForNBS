import { Component } from '@angular/core';
import { DistanceService } from './shared/distance.service';
import { Distance } from './shared/distance.model';
import { error } from 'selenium-webdriver';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    source: string = "";
    destination: string = "";
    distance: number;
    popularDistance: Distance = new Distance();

    constructor(private distanceService: DistanceService) { }

    GetDistance() {
       this.distance=-1;
        this.distanceService.getExistLocation(this.source, this.destination).subscribe(
            (dis: number) => {
                this.distance = dis;
            });

    }

    GetPopular() {
        this.distanceService.getPopularDistances().subscribe((response: Distance) => {
            this.popularDistance = response;
        });
    }

    validInput() {
        return this.source.length && this.destination.length;
    }
}
