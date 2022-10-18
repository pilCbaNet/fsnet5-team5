import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import LoginClass from './loginClass/loginClass';
import { LoginServiceService } from './service/login-service.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  users: any[] = [];

  constructor(private fb: FormBuilder, private service: LoginServiceService) {
    this.form = this.fb.group({
      Email: ['', Validators.required],
      Password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getUsers();
  }

  login(): void {
    let email: string = this.form.get('Email')?.value;
    let Password: string = this.form.get('Password')?.value;

    // let log: LoginClass = new LoginClass(email, Password);

    // this.service.login(log).subscribe((data) => {
    //   this.form.reset();
    //   localStorage.setItem('tokenPrueba', data.Email);
    //   location.reload();
    // });

    let name = this.users.filter((data) => email === data.email);

    if (name.length !== 0) {
      this.form.reset();
      localStorage.setItem('tokenPrueba', email);
      location.reload();
    }else{
      alert("si queres entrar ingresa admin@admin.com")
    }
  }

  getUsers(): void {
    this.service.getUsers().subscribe((data) => {
      this.users = data;
      console.log(this.users);
    });
  }
}
