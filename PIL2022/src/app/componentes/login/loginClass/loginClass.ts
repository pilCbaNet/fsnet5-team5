export default class LoginClass{

    email: string = ""
    password: string = ""
    monto: number = 0
    moviminetos: Array<string> = [] 

   constructor(Email: string, Password: string, monto: number, movimientos: Array<string>){
       this.email = Email;
       this.password = Password;
       this.monto= monto;
       this.moviminetos = movimientos;
   }

}