import { Component } from '@angular/core';
import { Cabecera } from "../cabecera/cabecera";
import { Menu } from "../menu/menu";
import { RouterModule } from "@angular/router";
import { AuthService } from '../../auth/auth.Service';
import { Articulos } from "../../articulos/articulos";

@Component({
  selector: 'app-layout-principal',
  imports: [Cabecera, Menu, RouterModule, Articulos],
  templateUrl: './layout-principal.html',
  styleUrl: './layout-principal.css',
})
export class LayoutPrincipal {
  rol:string | null = null;

  constructor(
    private authService:AuthService
  ){}

  ngOnInit(){
    this.rol = this.authService.obtenerRol();
  }
}
