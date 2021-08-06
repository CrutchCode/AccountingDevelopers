import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Developer } from '../models/developer.model';

@Injectable()
export class DataDevelopersService {

  private readonly _developerUrl = 'api/developer';

  constructor(private http: HttpClient) { }

  getDevelopers() {
    return this.http.get<Developer[]>(this._developerUrl);
  }

  //getSortedProject(sort: boolean) {
  //  return this.http.get<Project[]>(this._projectUrl + '/' + sort)
  //}

  getGroupDeveloper() {
    return this.http.get<string[]>(this._developerUrl + '/group')
  }

  addDeveloper(developer: Developer) {
    return this.http.post<Developer>(this._developerUrl, developer);
  }

  updateDeveloper(developer: Developer) {
    return this.http.put<Developer>(this._developerUrl, developer);
  }

  deleteDeveloper(id: number | undefined) {
    return this.http.delete<number | undefined>(this._developerUrl + '/' + id);
  }
}
