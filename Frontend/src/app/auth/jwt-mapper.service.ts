import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

export interface Usuariojwt {
  id: string;
  nombre: string;
  rol: string;
  exp: number;
}

@Injectable({
  providedIn: 'root',
})
export class JwtMapperService {
  private readonly RoleClaim =
    'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
  private readonly NombreClaim =
    'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name';
  private readonly IdClaim =
    'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';

  constructor() {}

  decodificarToken(token: string): Usuariojwt | null {
    if (!token) return null;

    try {
      const decoded: any = jwtDecode(token);

      const usuario: Usuariojwt = {
        id: decoded[this.IdClaim],
        nombre: decoded[this.NombreClaim],
        rol: decoded[this.RoleClaim],
        exp: decoded['exp'],
      };

      return usuario;
    } catch (error) {
      console.error('Error al decodificar el token jwt', error);
      return null;
    }
  }
}
