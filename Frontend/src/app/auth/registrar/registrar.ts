import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, ɵInternalFormsSharedModule } from '@angular/forms';
import { AuthService } from '../auth.Service';
import { Router } from '@angular/router';
import { MatCardModule } from "@angular/material/card";
import { MatFormField, MatLabel } from "@angular/material/form-field";
import { MatInput } from "@angular/material/input";
import { MatButtonModule } from '@angular/material/button';
import { Cabecera } from '../../compartido/cabecera/cabecera';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-registrar',
  imports: [Cabecera, MatCardModule, MatFormField, MatLabel, MatInput, ɵInternalFormsSharedModule, ReactiveFormsModule, MatButtonModule, RouterModule],
  templateUrl: './registrar.html',
  styleUrl: './registrar.css',
})
export class Registrar {
    formularioRegistro: FormGroup;
    mensajeError: string ='';

    constructor(
      private formBuilder: FormBuilder,
      private auth: AuthService,
      private router: Router
    ){
      this.formularioRegistro = this.formBuilder.group({
        nombreCliente: ['', Validators.required],
        primerApellido: ['', Validators.required],
        segundoApellido: ['', Validators.required],
        direccion : ['', Validators.required],
        usuarioPersonal : ['', Validators.required],
        password: ['', Validators.required]
      });
    }

    registrar(){
      if(this.formularioRegistro.invalid) return;

      this.auth.registrar(this.formularioRegistro.value).subscribe({
        next: () =>{
          this.router.navigate(['/login']);
          alert("Se inserto el usuario");
        },
        error: (error: any)=>{
          this,this.mensajeError = 'ocurrio un error al registrar al usuario';
          console.error(error);
        }
      });
    }
}
