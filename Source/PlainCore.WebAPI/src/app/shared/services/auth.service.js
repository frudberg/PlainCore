"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var service_base_1 = require("./service.base");
var applicationContext_model_1 = require("../Models/applicationContext.model");
var Configuration_1 = require("../Configuration");
var AuthenticationService = /** @class */ (function (_super) {
    __extends(AuthenticationService, _super);
    function AuthenticationService(http, appContext) {
        var _this = _super.call(this, http, '', appContext) || this;
        _this.http = http;
        _this.appContext = appContext;
        _this.login = function (email, password, rememberMe) {
            var headers = new http_1.Headers();
            headers.append('Content-Type', 'application/x-www-form-urlencoded');
            console.log(Configuration_1.Configuration.ApiUrl);
            debugger;
            var formdata = {
                username: email,
                password: password,
                rememberMe: rememberMe,
                grant_type: 'password',
                scope: 'offline_access profile email roles',
                resource: Configuration_1.Configuration.Server
            };
            var postData = _this.serializeObj(formdata);
            return _this.http.post(Configuration_1.Configuration.ApiUrl + 'Authentication/login', postData, { headers: headers })
                .toPromise()
                .then(function (res) {
                if (res) {
                    if (rememberMe)
                        _this.appContext.authContext.rememberMe = rememberMe;
                    _this.appContext.authContext.accessToken = res.json().access_token;
                    _this.appContext.authContext.refreshToken = res.json().refresh_token;
                    localStorage.setItem('isLoggedin', 'true');
                }
                else {
                    _this.appContext.authContext.clearAll();
                }
            });
        };
        return _this;
    }
    AuthenticationService.prototype.serializeObj = function (obj) {
        var result = new Array();
        for (var property in obj) {
            result.push(encodeURIComponent(property) + '=' + encodeURIComponent(obj[property]));
        }
        return result.join('&');
    };
    AuthenticationService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http, applicationContext_model_1.ApplicationContext])
    ], AuthenticationService);
    return AuthenticationService;
}(service_base_1.ServiceBase));
exports.AuthenticationService = AuthenticationService;
//# sourceMappingURL=auth.service.js.map