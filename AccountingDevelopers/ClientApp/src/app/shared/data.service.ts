import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Project } from '../models/project.model';
import { FullAccountingModel } from '../models/full.accounting.model';
import { Developer } from '../models/developer.model';

@Injectable({
  providedIn: 'root'
})


export class DataService {
  constructor(private http: HttpClient) { }

  private readonly _baseUrl = 'api/home';
  private readonly _projectUrl = 'api/project';
  

  getFullModel() {
    return this.http.get<FullAccountingModel[]>(this._baseUrl);
  }

  getProjects() {
    return this.http.get<Project[]>(this._projectUrl);
  }

  getSortedProject(sort: boolean) {
    return this.http.get<Project[]>(this._projectUrl  + '/' + sort)
  }

  getGroupProject() {
    return this.http.get<string[]>(this._projectUrl + '/group')
  }

  createProject(project: Project) {
    return this.http.post<Project>(this._projectUrl, project);
  }

  updateProject(project:Project) {
    return this.http.put<Project>(this._projectUrl, project);
  }

  deleteProject(id: number | undefined) {
    return this.http.delete<number | undefined>(this._projectUrl + '/' + id);
  }

  //getProject(id: number) {
  //  return this.http.get<Project>(this._projectUrl + '/' + id);
  //}

  //getProject() {
  //  return this.http.get<Project>(this._baseUrl);
  //}
}
