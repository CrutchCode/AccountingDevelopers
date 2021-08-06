import { Component, OnInit } from '@angular/core';
import { DataManageService } from './data.manage.service';
import { Project } from '../models/project.model';
import { Developer } from '../models/developer.model';
import { FullAccountingModel } from '../models/full.accounting.model'
import { DataProjectService } from '../project/data.project.service';
import { DataDevelopersService } from '../developer/data.developers.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.scss'],
  providers: [DataManageService, DataProjectService, DataDevelopersService]
})
export class ManageComponent implements OnInit {

  projects: Project[] = [];
  developers: Developer[] = [];
  fullList: FullAccountingModel[] = [];

  // Temp
  chooseDevelopersName: string[] = [];
  chooseDevelopersPosition: string[] = [];
  fullModel: FullAccountingModel = new FullAccountingModel();


  constructor(
    private dataManage: DataManageService,
    private dataProject: DataProjectService,
    private dataDeveloper: DataDevelopersService
  ) { }

  ngOnInit(): void {
    this.loadProjects();
    this.loadDevelopers();
    this.loadFullData();
  }

  loadProjects() {
    this.dataProject.getProjects().subscribe((data: Project[]) => this.projects = data);
  }

  loadDevelopers() {
    this.dataDeveloper.getDevelopers().subscribe((data: Developer[]) => this.developers = data);
  }

  loadFullData() {
    this.dataManage.getFullData().subscribe((data: FullAccountingModel[]) => this.fullList = data);
  }

}
