// service.base.ts
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions, ResponseContentType } from '@angular/http';
import { ApplicationContext } from '../Models/applicationContext.model';
import { Configuration } from '../Configuration';

@Injectable()
export class ServiceBase {

    protected url :string;
    protected appContext: ApplicationContext;

    constructor(protected http: Http, url: string, appContext:ApplicationContext) {
        this.appContext = appContext;
        this.url = Configuration.ServerWithApiUrl + url + '/';
    }

    protected getHeaders(): Headers {
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        headers.append('Authorization', 'Bearer ' + this.appContext.authContext.accessToken);
        headers.append('Content-Type', 'application/json');
        return headers;
    }

    protected get(apiCall: string, callback: (response: Response) => any, contentType?: string, responseType?: ResponseContentType): Promise<any>
    {
        let headers: Headers = this.getHeaders();
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

        return new Promise((resolve, reject) => {
            if (this.appContext.authContext.accessToken != undefined) {
                return this.http.get(this.url + apiCall,
                    {
                        headers: headers,
                        responseType: (responseType != undefined) ? responseType : ResponseContentType.Json
                    }
                ).toPromise()
                    .then(res => {
                        return resolve(callback(res));
                    })
                    .catch(error => {
                        return reject(error);
                    });
            } 
        });
    }
}