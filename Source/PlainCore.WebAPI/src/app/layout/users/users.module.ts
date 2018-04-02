import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { UserService } from './users.service';
import { PageHeaderModule } from './../../shared';

@NgModule({
    imports: [CommonModule, UsersRoutingModule, PageHeaderModule],
    declarations: [UsersComponent],
    providers: [UserService]
})
export class UsersModule {}
