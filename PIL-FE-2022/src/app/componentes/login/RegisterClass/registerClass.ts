export default class RegisterClass{

    email: string = ""
    pasword: string = ""
    nombre: string = ""
    apellido: string = ""
    dni: string = ""
    fechaAlta: string = ""
    fechaBaja: null = null;


   constructor(Email: string, Pasword: string, Nombre: string, Apellido: string, Dni: string){
       this.email = Email;
       this.pasword = Pasword;
       this.dni =  Dni;
       this.nombre = Nombre;
       this.apellido = Apellido;
       const fecha = new Date();
       this.fechaAlta = fecha.toISOString();
       this.fechaBaja;
   }
   

}