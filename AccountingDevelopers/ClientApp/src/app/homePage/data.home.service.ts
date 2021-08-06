import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FullAccountingModel } from '../models/full.accounting.model';

@Injectable()
export class DataHomeService {

  private readonly _baseUrl = 'api/home';

  constructor(private http: HttpClient) { }

  getFullModel() {
    return this.http.get<FullAccountingModel[]>(this._baseUrl);
  }
}
