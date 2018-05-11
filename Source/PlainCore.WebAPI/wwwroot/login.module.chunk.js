webpackJsonp(["login.module"],{

/***/ "../../../../../src/app/login/login-routing.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__login_component__ = __webpack_require__("../../../../../src/app/login/login.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: __WEBPACK_IMPORTED_MODULE_2__login_component__["a" /* LoginComponent */]
    }
];
var LoginRoutingModule = /** @class */ (function () {
    function LoginRoutingModule() {
    }
    LoginRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["J" /* NgModule */])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["c" /* RouterModule */].forChild(routes)],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["c" /* RouterModule */]]
        })
    ], LoginRoutingModule);
    return LoginRoutingModule;
}());



/***/ }),

/***/ "../../../../../src/app/login/login.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">  \r\n        <div class=\"row justify-content-md-center\">\r\n    <div class=\"col-lg-4 col-md-3 col-sm-2\"></div>\r\n    <div class=\"col-lg-4 col-md-6 col-sm-8\">\r\n        <div class=\"logo\">\r\n            <img src=\"assets/images/logo.jpg\"  alt=\"Logo\"  > \r\n        </div>\r\n        <div class=\"row loginbox\">                    \r\n            <div class=\"col-lg-12\">\r\n                <span class=\"singtext\" >Sign in </span>   \r\n            </div>\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n                <input [ngClass]=\"{'is-invalid':!model.isValid}\"  class=\"form-control\" type=\"text\" placeholder=\"Please enter your user name\" required [(ngModel)]=\"model.username\"> \r\n            </div>\r\n            <div class=\"col-lg-12  col-md-12 col-sm-12\">\r\n                <input [ngClass]=\"{'is-invalid':!model.isValid}\" class=\"form-control\" type=\"password\" placeholder=\"Please enter password\" required [(ngModel)]=\"model.password\">\r\n               <div  *ngIf=\"model.isValid == ''\" class=\"invalid-feedback\">\r\n                    The combination of username and password is invalid\r\n                </div>    \r\n            </div>\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n            <div class=\"checkbox\">\r\n                    <label>\r\n                        <input type=\"checkbox\" [(ngModel)]=\"model.rememberMe\"> Remember me\r\n                    </label>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-12  col-md-12 col-sm-12\">\r\n                <button class=\"btn submitButton\" (click)=\"onLoggedin()\">Submit </button> \r\n            </div>                     \r\n        </div>\r\n        <br>                \r\n        <br>\r\n    </div>\r\n    <div class=\"col-lg-4 col-md-3 col-sm-2\"></div>\r\n</div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/login/login.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".form-control {\n  border-radius: 0px;\n  margin: 12px 3px;\n  height: 40px; }\n\n.logo {\n  margin: auto;\n  text-align: center;\n  padding-top: 20%; }\n\n.logo img {\n  height: 70px; }\n\n/*footer*/\n\n.footer a {\n  color: #000;\n  text-decoration: none; }\n\n.footer {\n  color: #000;\n  text-align: center; }\n\n/*footer end*/\n\n/*for logintemplate blue*/\n\n.grayBody {\n  background-color: #E9E9E9; }\n\n.loginbox {\n  margin-top: 5%;\n  border-top: 6px solid #3779a0;\n  background-color: #fff;\n  padding: 20px;\n  -webkit-box-shadow: 0 10px 10px -2px rgba(0, 0, 0, 0.12), 0 -2px 10px -2px rgba(0, 0, 0, 0.12);\n          box-shadow: 0 10px 10px -2px rgba(0, 0, 0, 0.12), 0 -2px 10px -2px rgba(0, 0, 0, 0.12); }\n\n.singtext {\n  font-size: 28px;\n  color: #0088D8;\n  font-weight: 500;\n  letter-spacing: 1px; }\n\n.submitButton {\n  background-color: #0088D8;\n  color: #fff;\n  margin-top: 12px;\n  margin-bottom: 10px;\n  padding: 10px 0px;\n  width: 100%;\n  margin-left: 2px;\n  font-size: 16px;\n  border-radius: 0px;\n  outline: none; }\n\n.submitButton:hover, .submitButton:focus {\n  color: #fff;\n  outline: none; }\n\n.forGotPassword {\n  background-color: #F2F2F2;\n  padding: 15px 60px; }\n\n.forGotPassword:hover {\n  -webkit-box-shadow: 0 10px 10px -2px rgba(0, 0, 0, 0.12);\n          box-shadow: 0 10px 10px -2px rgba(0, 0, 0, 0.12); }\n\n.forGotPassword a {\n  color: #000;\n  outline: none; }\n\n.forGotPassword a:hover, .forGotPassword a:active, .forGotPassword a:focus {\n  text-decoration: none;\n  outline: none; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/login/login.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__router_animations__ = __webpack_require__("../../../../../src/app/router.animations.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__shared_services_auth_service__ = __webpack_require__("../../../../../src/app/shared/services/auth.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__shared_Models_applicationContext_model__ = __webpack_require__("../../../../../src/app/shared/Models/applicationContext.model.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__login_model__ = __webpack_require__("../../../../../src/app/login/login.model.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var LoginComponent = /** @class */ (function () {
    function LoginComponent(router, authenticationService, appContext) {
        this.router = router;
        this.authenticationService = authenticationService;
        this.appContext = appContext;
        this.model = new __WEBPACK_IMPORTED_MODULE_5__login_model__["a" /* LoginModel */]('', '');
    }
    LoginComponent.prototype.ngOnInit = function () {
    };
    LoginComponent.prototype.onLoggedin = function () {
        var _this = this;
        if (this.model.password == '' || this.model.username == '') {
            this.model.isValid = false;
        }
        else {
            this.authenticationService.login(this.model.username, this.model.password, false).then(function () {
                if (_this.appContext.authContext.isLoggedIn) {
                    _this.model.isValid = true;
                    _this.router.navigate(['/dashboard']);
                }
                else
                    _this.model.isValid = false;
            }).catch(function (error) {
                _this.appContext.authContext.clearAll();
                _this.model.isValid = false;
                console.log('error');
            });
        }
    };
    LoginComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-login',
            template: __webpack_require__("../../../../../src/app/login/login.component.html"),
            styles: [__webpack_require__("../../../../../src/app/login/login.component.scss")],
            animations: [Object(__WEBPACK_IMPORTED_MODULE_2__router_animations__["a" /* routerTransition */])()]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */], __WEBPACK_IMPORTED_MODULE_3__shared_services_auth_service__["a" /* AuthenticationService */], __WEBPACK_IMPORTED_MODULE_4__shared_Models_applicationContext_model__["a" /* ApplicationContext */]])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "../../../../../src/app/login/login.model.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginModel; });
var LoginModel = /** @class */ (function () {
    function LoginModel(username, password) {
        this.username = username;
        this.password = password;
        this.isValid = true;
        this.rememberMe = false;
    }
    return LoginModel;
}());



/***/ }),

/***/ "../../../../../src/app/login/login.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginModule", function() { return LoginModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/esm5/common.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__login_routing_module__ = __webpack_require__("../../../../../src/app/login/login-routing.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__login_component__ = __webpack_require__("../../../../../src/app/login/login.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var LoginModule = /** @class */ (function () {
    function LoginModule() {
    }
    LoginModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["J" /* NgModule */])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_common__["b" /* CommonModule */], __WEBPACK_IMPORTED_MODULE_3__login_routing_module__["a" /* LoginRoutingModule */], __WEBPACK_IMPORTED_MODULE_2__angular_forms__["a" /* FormsModule */]],
            declarations: [__WEBPACK_IMPORTED_MODULE_4__login_component__["a" /* LoginComponent */]]
        })
    ], LoginModule);
    return LoginModule;
}());



/***/ })

});
//# sourceMappingURL=login.module.chunk.js.map