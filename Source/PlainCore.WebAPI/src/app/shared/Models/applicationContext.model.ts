import { User } from "./user.model";
import { AuthenticationContext } from "./authenticationContext.model";
import { Injectable } from "@angular/core";

@Injectable()
export class  ApplicationContext
{
    public authContext: AuthenticationContext = new AuthenticationContext();
}