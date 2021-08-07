import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FullAccountingModel } from '../models/full.accounting.model';

@Injectable()
export class DataManageService {

  private readonly _url = 'api/manage';

  constructor(private http: HttpClient) {}

  getFullData() {
    return this.http.get<FullAccountingModel[]>(this._url);
  }

  appointDeveloper(fullModel: FullAccountingModel) {
    return this.http.post<FullAccountingModel>(this._url, fullModel);
  }
}
