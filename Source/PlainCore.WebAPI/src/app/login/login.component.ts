import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { AuthenticationService } from '../shared/services/auth.service'
import { ApplicationContext } from '../shared/Models/applicationContext.model'
import {LoginModel} from './login.model'
import { FormsModule } from '@angular/forms';


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    constructor(public router: Router, private authenticationService: AuthenticationService, private appContext: ApplicationContext ) {}

    private model : LoginModel = new LoginModel('','');

    ngOnInit() 
    {

    }

    onLoggedin() {

        if(this.model.password == '' || this.model.username == '')
        {
            this.model.isValid = false;
        }
        else
        {
            this.authenticationService.login(this.model.username, this.model.password,false).then(() => {
                if(this.appContext.authContext.isLoggedIn)
                {
                     this.model.isValid = true;
                     this.router.navigate(['/dashboard']);
                }
                else
                    this.model.isValid = false;

            }).catch(error => {
                this.appContext.authContext.clearAll();
                this.model.isValid = false;
                console.log('error');
                });
        }
    }
}
