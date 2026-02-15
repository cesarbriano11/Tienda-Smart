import { HttpClient } from '@angular/common/http';
import { createNgModule, inject, Injectable } from '@angular/core';
import { JwtMapperService } from './jwt-mapper.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
    private apiUrl = 'https://localhost:7145/auth'
    private jwtMapper = inject(JwtMapperService);
    private readonly tokenKey = 'token';

    constructor(private http: HttpClient){}

    login(credenciales: any){
      return this.http.post<any>(`${this.apiUrl}/login`, credenciales);
    }

    registrar(datos: any){
      return this.http.post<any>(`${this.apiUrl}/registro`, datos);
    }

    guardarSesion(token: string){
      localStorage.setItem(this.tokenKey, token);
    }

    obtenerToken(): string | null {
      return localStorage.getItem(this.tokenKey);
    }

      obtenerRol(): string | null {
    const token = localStorage.getItem(this.tokenKey);
    if (!token) return null;

    const usuario = this.jwtMapper.decodificarToken(token);

    return usuario?.rol || null;
  }
}
