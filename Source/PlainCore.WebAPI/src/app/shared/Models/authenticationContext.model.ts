import { User } from "./user.model";

export class AuthenticationContext {
    get accessToken(): string {
        if (this.rememberMe)
            return localStorage.getItem('accessToken');
        else
            return sessionStorage.getItem('refreshToken');
    }
    set accessToken(theValue: string) {
        if (this.rememberMe)
            localStorage.setItem('accessToken', theValue);
        else
            sessionStorage.setItem('accessToken', theValue);
    }
    get refreshToken(): string {
        if (this.rememberMe)
            return localStorage.getItem('refreshToken');
        else
            return sessionStorage.getItem('refreshToken');
    }
    set refreshToken(theValue: string) {
        if (this.rememberMe)
            localStorage.setItem('refreshToken', theValue);
        else
            sessionStorage.setItem('refreshToken', theValue);
    }
    get rememberMe(): boolean {
            return localStorage.getItem('rememberMe') == 'true';
    }
    set rememberMe(theValue: boolean) {
        if (theValue)
            localStorage.setItem('rememberMe', 'true');
        else
            localStorage.setItem('rememberMe', 'false');
    }

    clearAll() {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        localStorage.removeItem('rememberMe');
        localStorage.removeItem('isLoggedin');

        sessionStorage.removeItem('accessToken');
        sessionStorage.removeItem('refreshToken');
        sessionStorage.removeItem('rememberMe');
    }

    isLoggedIn(): boolean {
        return this.accessToken != undefined;
    }
}