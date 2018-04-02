"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AuthenticationContext = /** @class */ (function () {
    function AuthenticationContext() {
    }
    Object.defineProperty(AuthenticationContext.prototype, "accessToken", {
        get: function () {
            if (this.rememberMe)
                return localStorage.getItem('accessToken');
            else
                return sessionStorage.getItem('refreshToken');
        },
        set: function (theValue) {
            if (this.rememberMe)
                localStorage.setItem('accessToken', theValue);
            else
                sessionStorage.setItem('accessToken', theValue);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AuthenticationContext.prototype, "refreshToken", {
        get: function () {
            if (this.rememberMe)
                return localStorage.getItem('refreshToken');
            else
                return sessionStorage.getItem('refreshToken');
        },
        set: function (theValue) {
            if (this.rememberMe)
                localStorage.setItem('refreshToken', theValue);
            else
                sessionStorage.setItem('refreshToken', theValue);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(AuthenticationContext.prototype, "rememberMe", {
        get: function () {
            return localStorage.getItem('rememberMe') == 'true';
        },
        set: function (theValue) {
            if (theValue)
                localStorage.setItem('rememberMe', 'true');
            else
                localStorage.setItem('rememberMe', 'false');
        },
        enumerable: true,
        configurable: true
    });
    AuthenticationContext.prototype.clearAll = function () {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        localStorage.removeItem('rememberMe');
        localStorage.removeItem('isLoggedin');
        sessionStorage.removeItem('accessToken');
        sessionStorage.removeItem('refreshToken');
        sessionStorage.removeItem('rememberMe');
    };
    AuthenticationContext.prototype.isLoggedIn = function () {
        return this.accessToken != undefined;
    };
    return AuthenticationContext;
}());
exports.AuthenticationContext = AuthenticationContext;
//# sourceMappingURL=authenticationContext.model.js.map