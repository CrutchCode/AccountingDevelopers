import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '../models/project.model';

@Injectable()
export class DataProjectService {

  private readonly _projectUrl = 'api/project';

  constructor(private http: HttpClient) { }

  getProjects() {
    return this.http.get<Project[]>(this._projectUrl);
  }

  getSortedProject(sort: boolean) {
    return this.http.get<Project[]>(this._projectUrl + '/' + sort)
  }

  getGroupProject() {
    return this.http.get<string[]>(this._projectUrl + '/group')
  }

  createProject(project: Project) {
    return this.http.post<Project>(this._projectUrl, project);
  }

  updateProject(project: Project) {
    return this.http.put<Project>(this._projectUrl, project);
  }

  deleteProject(id: number | undefined) {
    return this.http.delete<number | undefined>(this._projectUrl + '/' + id);
  }
}
