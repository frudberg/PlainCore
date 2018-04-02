import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public static get Server(): string { return location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '')+"/";}
    public static get ApiUrl(): string { return 'api/v1/'; }
    public static get ServerWithApiUrl(): string { return Configuration.Server + Configuration.ApiUrl; }
    public static get AuthenticationServer(): string { return Configuration.Server; }

    public static get Hostname(): string {
        let length = window.location.hostname.split('.').length;
        if (length > 2) {
            return window.location.hostname.split('.')[length - 2] + '.' + window.location.hostname.split('.')[length - 1];
        }
        return window.location.hostname;
    }
}