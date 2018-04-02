export class LoginModel {
    public isValid: boolean;
    public rememberMe: boolean; 
    
    constructor(
        public username: string,
        public password: string
    )
    { 
        this.isValid = true;
        this.rememberMe = false;
    }
}