import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { UserService } from './users.service';

@Component({
    selector: 'app-tables',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss'],
    animations: [routerTransition()]
})
export class UsersComponent implements OnInit {

    constructor(protected userService: UserService) {}

    ngOnInit()
    {
        debugger;
        console.log('UsersComponent');
        this.userService.getUsers().then(
            (users) => {
                debugger;
                console.log(users[0].lastname);
            }).catch(
            (error) => {
                debugger;
                console.log(error);
            });
    }
}
