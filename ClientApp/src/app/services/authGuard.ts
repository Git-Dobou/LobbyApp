import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { LoginService } from './login.service';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private loginService: LoginService,
        private router: Router) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): boolean {

        if (this.loginService.IsMemberLoged.value === false) {
            this.router.navigate(['/login']);
        }

        return this.loginService.IsMemberLoged.value;
    }
}
