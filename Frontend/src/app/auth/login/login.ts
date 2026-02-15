import { CommonModule } from '@angular/common';
import { AuthService } from '../auth.Service';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardMdImage, MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';
import { validate } from '@angular/forms/signals';
import { Cabecera } from '../../compartido/cabecera/cabecera';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [Cabecera,
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule, RouterLink,
    RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
    private formBuilder = inject(FormBuilder);
    private authService = inject(AuthService);
    private router = inject(Router);

    mensajeError = '';

    formLogin = this.formBuilder.group({
      usuarioPersonal: ['', Validators.required],
      password: ['', Validators.required]
    });

    login(){
      if(this.formLogin.invalid) return;

      this.authService.login(this.formLogin.value)
      .subscribe({
        next: (respuesta) => {
          this.authService.guardarSesion(respuesta.token);
          this.router.navigate(['/tienda']);
        },
        error: () => {
          this.mensajeError = 'credenciales incorrectas';
        }
      });
    }
}
