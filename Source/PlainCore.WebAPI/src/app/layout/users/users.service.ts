import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Http, Headers, ResponseContentType } from '@angular/http';

import { ServiceBase } from '../../shared/services/service.base';
import { AuthenticationService } from '../../shared/services/auth.service';
import { ApplicationContext } from '../../shared/Models/applicationContext.model'
import { User } from '../../shared/Models/user.model';

@Injectable()
export class UserService extends ServiceBase {

    constructor(protected http: Http, protected applicationContext: ApplicationContext, private authenticationService: AuthenticationService) {
        super(http, 'UserController', applicationContext);
    }

    public getUsers = (): Promise<User> => {
        return this.get('GetAllUsers', (res) => {
            return res.json();
        });
    }
}