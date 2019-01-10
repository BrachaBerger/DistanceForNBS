import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http"
import { Distance } from './distance.model';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class DistanceService {

    constructor(private http: HttpClient) { }

    getExistLocation(source: string, destination: string): Observable<number> {
        debugger;
        return this.http.get("http://localhost:54402/api/getDistance/" + source + "/" + destination)
            .map((response: string) => response)
            .catch((response: HttpErrorResponse) => Observable.throw(response));
    }

    getPopularDistances(): Observable<Distance> {
        return this.http.get("http://localhost:54402/api/getPopularDistances")
            .map((response: Distance) => response)
            .catch((response: HttpErrorResponse) => Observable.throw(response));
    }

}
