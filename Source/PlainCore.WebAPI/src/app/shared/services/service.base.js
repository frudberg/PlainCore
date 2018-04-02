"use strict";
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
var applicationContext_model_1 = require("../Models/applicationContext.model");
var Configuration_1 = require("../Configuration");
var ServiceBase = /** @class */ (function () {
    function ServiceBase(http, url, appContext) {
        this.http = http;
        this.appContext = appContext;
        this.url = Configuration_1.Configuration.ServerWithApiUrl + url + '/';
    }
    ServiceBase.prototype.getHeaders = function () {
        var headers = new http_1.Headers();
        headers.append('Accept', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.appContext.authContext.accessToken);
        headers.append('Content-Type', 'application/json');
        return headers;
    };
    ServiceBase.prototype.get = function (apiCall, callback, contentType, responseType) {
        var _this = this;
        var headers = this.getHeaders();
        if (contentType != undefined) {
            headers.set('Content-Type', contentType);
        }
        headers.set('Cache-Control', 'no-cache, no-store, must-revalidate');
        headers.set('Pragma', 'no-cache');
        headers.set('Expires', '0');
        //this.http.get(this.url + apiCall, {
        //    headers: headers,
        //    responseType: (responseType != undefined) ? responseType : ResponseContentType.Json
        //}).subscribe(res => { console.log('aaaa'+res.json()); });
        return new Promise(function (resolve, reject) {
            if (_this.appContext.authContext.accessToken != undefined) {
                return _this.http.get(_this.url + apiCall, {
                    headers: headers,
                    responseType: (responseType != undefined) ? responseType : http_1.ResponseContentType.Json
                }).toPromise()
                    .then(function (res) {
                    return resolve(callback(res));
                })
                    .catch(function (error) {
                    return reject(error);
                });
            }
        });
    };
    ServiceBase = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http, String, applicationContext_model_1.ApplicationContext])
    ], ServiceBase);
    return ServiceBase;
}());
exports.ServiceBase = ServiceBase;
//# sourceMappingURL=service.base.js.map