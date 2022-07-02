import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginUser } from '../../../core/models/login-user';
import { NotEmpty } from 'src/app/shared/validators/not-empty.validator';
import { UsersService } from '../../../core/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  loginUser:LoginUser;

  constructor(private formBuilder: FormBuilder, private usersService:UsersService) { 

    this.loginForm= formBuilder.group({
      username:['',[Validators.required,  NotEmpty]],
      password: ['',[Validators.required,  NotEmpty]],
    })
  }

  ngOnInit(): void {
  }

  get username(){
    return this.loginForm.get("username")
  }

  get password(){
    return this.loginForm.get("password")
  }

  onSubmit(){
    console.log(this.loginForm.value);
    this.loginUser=new LoginUser(this.loginForm.value);
    console.log(this.loginUser)

    this.usersService.login(this.loginUser)
    .subscribe(
      data=>{
        alert(data.token);
      },
      error=>{
        console.log("error")
        console.log(error)
        console.log("error")
        alert(error);
      }

    )
    
  }
}
