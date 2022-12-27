import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { UnitModel } from "./enheter.model";

@Injectable()
export class EnheterService {

    constructor(private httpClient: HttpClient) { }

    getLength() {
        return this.httpClient.get<UnitModel[]>(`${environment.unitConverterApiUrl}/length`);
    }

    getWeight() {
        return this.httpClient.get<UnitModel[]>(`${environment.unitConverterApiUrl}/weight`);
    }

    getVolume() {
        return this.httpClient.get<UnitModel[]>(`${environment.unitConverterApiUrl}/volume`);
    }
}