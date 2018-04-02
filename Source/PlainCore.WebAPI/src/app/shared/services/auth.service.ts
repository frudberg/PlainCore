import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions, ResponseContentType } from '@angular/http';
import { ServiceBase } from './service.base';
import { ApplicationContext } from '../Models/applicationContext.model';
import { Configuration } from '../Configuration';

@Injectable()
export class AuthenticationService extends ServiceBase
{
    constructor(protected http: Http, protected appContext: ApplicationContext) {
        super(http,'', appContext);
    }

    public login = (email: string, password: string, rememberMe: boolean): Promise<any> => {
        let headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        console.log(Configuration.ApiUrl);
        debugger;
        let formdata = {
            username: email,
            password: password,
            rememberMe: rememberMe,
            grant_type: 'password',
            scope: 'offline_access profile email roles',
            resource: Configuration.Server
        };

        let postData = this.serializeObj(formdata);

        return this.http.post(Configuration.ApiUrl+'Authentication/login', postData, { headers })
            .toPromise()
            .then(res => {
                if (res) {
                    if(rememberMe)
                        this.appContext.authContext.rememberMe = rememberMe
                        
                    this.appContext.authContext.accessToken = res.json().access_token;
                    this.appContext.authContext.refreshToken = res.json().refresh_token;
                    localStorage.setItem('isLoggedin', 'true');
                }
                else
                {
                    this.appContext.authContext.clearAll();
                }
            })
    }

    protected serializeObj(obj: any): string {
        let result = new Array();
        for (let property in obj) {
            result.push(encodeURIComponent(property) + '=' + encodeURIComponent(obj[property]));
        }
        return result.join('&');
    }
}