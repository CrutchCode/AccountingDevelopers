import { Component, OnInit } from '@angular/core';
import { RegistrationModel } from '../models/registration.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  login: string = '';
  userName: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
