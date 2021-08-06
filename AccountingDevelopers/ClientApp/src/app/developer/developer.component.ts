import { Component, OnInit } from '@angular/core';
import { DataDevelopersService } from './data.developers.service';
import { Developer } from '../models/developer.model';

@Component({
  selector: 'app-developer',
  templateUrl: './developer.component.html',
  styleUrls: ['./developer.component.scss'],
  providers: [DataDevelopersService]
})
export class DeveloperComponent implements OnInit {

  // Temporary properties

  //---------------------------------------------------

  // Properties
  developers: Developer[] = [];
  developer: Developer = new Developer();
  editedDeveloper: Developer = new Developer();
  options: string[] = [];
  option: string = '';

  constructor(private dataService: DataDevelopersService) { }

  ngOnInit(): void {
    this.LoadDevelopers();
    this.loadGroupDevelopers();
  }

  //
  reverseTable() {
    this.developers.reverse();
  }

  //
  filter(option: string) {

    if (option != '') {
      let filteredProject = this.developers.filter(p => p.position == option);
      this.developers = filteredProject;
    } else {
      this.LoadDevelopers();
    }
  }

  //
  resetFilter() {
    if (this.option != '') {
      this.option = '';
    }
  }

  //
  cencel() {
    this.editedDeveloper = new Developer();
  }

  loadGroupDevelopers() {
    this.dataService.getGroupDeveloper().subscribe((data: string[]) => this.options = data);
  }

  //
  LoadDevelopers() {
    this.dataService.getDevelopers().subscribe((data: Developer[]) => this.developers = data);
  }

  //
  add() {
    this.dataService.addDeveloper(this.developer).subscribe((data: Developer) => this.LoadDevelopers());
    this.developer = new Developer();
  }

  //
  downloadEditedDeveloper(developer: Developer) {
    this.editedDeveloper = new Developer(developer.id, developer.name, developer.lastName, developer.position);
  }

  //
  save(developer: Developer) {
    this.dataService.updateDeveloper(developer).subscribe((data: Developer) => this.LoadDevelopers())
    this.cencel();
  }

  //
  delete(developer: Developer) {
    console.log(developer.id)
    this.dataService.deleteDeveloper(developer.id).subscribe((data) => this.LoadDevelopers())
  }

}
