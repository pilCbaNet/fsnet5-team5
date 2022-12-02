export default class LoginClass{

    email: string = ""
    password: string = ""
    monto: number = 0
    movimientos: Array<any> = [] 

   constructor(Email: string, Password: string, monto: number, movimientos: Array<any>){
       this.email = Email;
       this.password = Password;
       this.monto= monto;
       this.movimientos = movimientos;
   }

}