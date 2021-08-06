import { Component, OnInit } from '@angular/core';
import { FullAccountingModel } from '../models/full.accounting.model';
import { DataHomeService } from './data.home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [DataHomeService]
})
export class HomeComponent implements OnInit {

  //project: Project = new Project();
  //projects: Project[] = [];
  fullModel: FullAccountingModel[] = [];

  constructor(private dataService: DataHomeService) { }

  ngOnInit(): void {
    //this.LoadProjects();
    this.LoadFullModel();
  }
  //LoadProjects(): void {
  //  this.dataService.getProjects().subscribe((data: Project[]) => this.projects = data);
  //}
  LoadFullModel(): void {
    this.dataService.getFullModel().subscribe((data: FullAccountingModel[]) => this.fullModel = data);
  }

  

  
}
