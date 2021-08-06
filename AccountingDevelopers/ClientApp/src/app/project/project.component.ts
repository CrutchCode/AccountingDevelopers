import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//import { DataService } from '../shared/data.service';
import { Project } from '../models/project.model';
import { DataProjectService } from './data.project.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss'],
  providers: [DataProjectService]
})
export class ProjectComponent implements OnInit {

  // Temporary fields
  //sortedProject: boolean = true;
  
  
  //----------------------------------------

  editProject: Project = new Project();
  project: Project = new Project();
  projects: Project[] = [];
  options: string[] = [];
  option: string = '';
  

  constructor(private dataService: DataProjectService, private router: Router) { }

  ngOnInit(): void {
    this.loadData();
    this.loadFilterData();
  }

  cancel() {
    this.editProject = new Project();
  }

  resetFilter() {
    if (this.option != '') {
      this.option = '';
    }
  }

  // Analog OrderBy()!!
  reverseTable() {
    this.projects.reverse();
  }

  filter(option: string) {
    
    if (option != '') {
      let filteredProject = this.projects.filter(p => p.description == option);
      this.projects = filteredProject;
    } else {
      this.loadData();
    }
  }

  //orderBy() {    
  //  if (!this.sortedProject) {
  //    console.log('Order by Decending');
  //    this.dataService.getSortedProject(this.sortedProject).subscribe((data: Project[]) => this.projects = data);
  //    this.sortedProject = true;
  //  } else if (this.sortedProject) {
  //    console.log('Order by Ascending');
  //    this.dataService.getSortedProject(this.sortedProject).subscribe((data: Project[]) => this.projects = data);
  //    this.sortedProject = false;
  //  }    
  //}

  // Download projects
  loadData() {
    return this.dataService.getProjects().subscribe((data: Project[]) => this.projects = data);    
  }

  loadFilterData() {
    this.dataService.getGroupProject().subscribe((data: string[]) => this.options = data);
  }

   //Edit project
  editLoadProject(project: Project) {
    this.editProject = new Project(project.id, project.projectName, project.description, project.dateOfCreate);
  }

  // Create new project
  create() {
    this.dataService.createProject(this.project).subscribe(data => this.loadData());
    this.project = new Project();
    this.resetFilter();
  }

  // Save project
  save(project: Project) {
    this.dataService.updateProject(project).subscribe(data =>
    {
      this.loadData(); this.loadFilterData();
    });
    this.cancel();
    this.resetFilter();
  }

  // Delete project
  delete(project: Project) {
    this.dataService.deleteProject(project.id).subscribe(data => {
      this.loadData(); this.loadFilterData();
    });
    this.resetFilter();
  }
}
