import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

export  interface Sucursal{
    idSucursal:number; 
    nombreSucursal: string;
    direccion: string;
}

@Injectable({
    providedIn:'root'
})
export class SucursalService{
    private apiurl = 'https://localhost:7145/sucursal';

    constructor(private http: HttpClient){}

    consultaSucursales():Observable<Sucursal[]>{
        return this.http.get<Sucursal[]>(this.apiurl);
    }

    insertarSucursal(data: any){
        return this.http.post(this.apiurl, data);
    }

    actualizarSucursal(idSucursal: number, data: Sucursal):Observable<void>{
        return this.http.put<void>(`${this.apiurl}/${idSucursal}`,data);
    }

    eliminarSucursal(idSucursal: number): Observable<void>{
        return this.http.delete<void>(`${this.apiurl}/${idSucursal}`)
    }
}