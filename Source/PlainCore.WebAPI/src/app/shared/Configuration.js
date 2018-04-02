"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var Configuration = /** @class */ (function () {
    function Configuration() {
    }
    Configuration_1 = Configuration;
    Object.defineProperty(Configuration, "Server", {
        get: function () { return location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + "/"; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Configuration, "ApiUrl", {
        get: function () { return 'api/v1/'; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Configuration, "ServerWithApiUrl", {
        get: function () { return Configuration_1.Server + Configuration_1.ApiUrl; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Configuration, "AuthenticationServer", {
        get: function () { return Configuration_1.Server; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Configuration, "Hostname", {
        get: function () {
            var length = window.location.hostname.split('.').length;
            if (length > 2) {
                return window.location.hostname.split('.')[length - 2] + '.' + window.location.hostname.split('.')[length - 1];
            }
            return window.location.hostname;
        },
        enumerable: true,
        configurable: true
    });
    Configuration = Configuration_1 = __decorate([
        core_1.Injectable()
    ], Configuration);
    return Configuration;
    var Configuration_1;
}());
exports.Configuration = Configuration;
//# sourceMappingURL=Configuration.js.map