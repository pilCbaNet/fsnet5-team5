import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import LoginClass from "./loginClass/loginClass";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor( private fb: FormBuilder) { 
    this.form = this.fb.group({
      Email: ['', Validators.required],
      Password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  login(): void {
    let email: string = this.form.get('Email')?.value;
    let Password: string = this.form.get('Password')?.value;

    let log: LoginClass = new LoginClass(email, Password);

    // this.service.login(log).subscribe((data) => {
    //   this.form.reset();
    //   localStorage.setItem('tokenPrueba', data.Email);
    //   location.reload();
    // });
  }
}
