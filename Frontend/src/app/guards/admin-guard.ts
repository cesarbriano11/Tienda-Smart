import { CanActivateFn, Router } from '@angular/router';
import { inject, Inject } from '@angular/core';
import { AuthService } from '../auth/auth.Service';

export const adminGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const rol = authService.obtenerRol();

  if(rol === 'Admin'){
    return true;
  }

  router.navigate(['/login']);
  return true;
};
