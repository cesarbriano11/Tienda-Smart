import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.Service';
import { Router, RouterLink } from "@angular/router";
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatLabel } from '@angular/material/form-field';
@Component({
  selector: 'app-menu',
  imports: [RouterLink,CommonModule, MatIconModule, MatLabel],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
})
export class Menu {
    menus: any[] = [];

    constructor(private authService:AuthService,
      private router: Router
    ){}

    ngOnInit(){
      const rol = this.authService.obtenerRol();

      if(rol === 'Admin'){
        this.menus = [
          {label: 'sucursales', ruta: '/tienda/sucursales'},
          {label: 'articulos', ruta: '/tienda/articulos'}
        ];
      }else{
        this.menus = [
          {label: 'Carrito de Compra', ruta: 'compras'}
        ]
      }
    }

    logout(){
      localStorage.removeItem('token');
      this.router.navigate(['/login']);
    }
}
