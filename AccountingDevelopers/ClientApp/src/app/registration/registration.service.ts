import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegistrationModel } from '../models/registration.model';

@Injectable()
export class RegistrationService {

  private readonly _url = 'api/registration';

  constructor(private http: HttpClient) { }

  userRegistration(registrationModel: RegistrationModel) {
    this.http.post(this._url, registrationModel);
  }
}
