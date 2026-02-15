import { Routes } from '@angular/router';
import { Login } from './auth/login/login';
import { Registrar } from './auth/registrar/registrar';
import { LayoutPrincipal } from './compartido/layout-principal/layout-principal'
import { Sucursales } from './sucursales/sucursales';
import { adminGuard } from './guards/admin-guard';
import { Articulos } from './articulos/articulos';

export const routes: Routes = [
    {path: 'login', component: Login},
    {path: 'registrar', component: Registrar},
    {path: 'tienda', component: LayoutPrincipal,
        children:[
            {path: 'sucursales', component: Sucursales, canActivate: [adminGuard]},
            {path: 'articulos', component:Articulos, canActivate: [adminGuard]}
        ]
    },
    {path: '', redirectTo:'login', pathMatch:'full'},
    {path: '**', redirectTo: 'login'}
];
