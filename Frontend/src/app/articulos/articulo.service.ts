import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

export interface Articulo{
    idArticulo: number;
    nombreArticulo: string;
    codigo: string;
    descripcion: string;
    precio : number;
    urlImagen: string;
    stock: number;
}

@Injectable({providedIn: 'root'})
export class ArticuloService{
    private apiUrl = 'https://localhost:7145/articulo'

    constructor(private http: HttpClient){}

    consultaArticulosPorSucursal(idSucursal: number){
        return this.http.get<Articulo[]>(`${this.apiUrl}/sucursal/${idSucursal}`);
    }

    insertarArticulo(data: Articulo){
        return this.http.post<Articulo>(this.apiUrl, data);
    }

    actualizaArticulo(data: Articulo){
        return this.http.put<void>(`${this.apiUrl}/${data.idArticulo}`, data);
    }

    eliminarArticulo(idArticulo: number){
        return this.http.delete<void>(`${this.apiUrl}/${idArticulo}`);
    }
}