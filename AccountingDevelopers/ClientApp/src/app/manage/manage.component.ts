import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { DataManageService } from './data.manage.service';
import { Developer } from '../models/developer.model';
import { FullAccountingModel } from '../models/full.accounting.model';
import { DataDevelopersService } from '../developer/data.developers.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.scss'],
  providers: [DataManageService , DataDevelopersService]
})
export class ManageComponent implements OnInit {

  developers: Developer[] = [];
  fullList: FullAccountingModel[] = [];
  editModel: FullAccountingModel = new FullAccountingModel();
  developer: Developer = new Developer();
  option: number = 0;
  @ViewChild('TemplatePart1', { static: false }) templatePart1!: TemplateRef<FullAccountingModel>;
  @ViewChild('TemplatePart2', { static: false }) templatePart2!: TemplateRef<FullAccountingModel>;

  // Temp


  constructor(
    private dataManage: DataManageService,
    private dataDeveloper: DataDevelopersService
  ) { }

  ngOnInit(): void {
    this.loadDevelopers();
    this.loadFullData();
  }

  //
  loadDevelopers() {
    this.dataDeveloper.getDevelopers().subscribe((data: Developer[]) => this.developers = data);
  }

  //
  loadFullData() {
    this.dataManage.getFullData().subscribe((data: FullAccountingModel[]) => this.fullList = data);
  }

  //
  loadTemplate(item: FullAccountingModel) {
    if (item.developerId == this.editModel.developerId && item.projectId == this.editModel.projectId) {
      return this.templatePart2;
    }
    return this.templatePart1;
  }

  //
  edit(edited: FullAccountingModel) {
    this.editModel = new FullAccountingModel(
      edited.projectId,
      edited.projectName,
      edited.description,
      edited.dateOfCreate,
      edited.developerId,
      edited.fullName,
      edited.position
    );
  }

  //
  cancel() {
    this.editModel = new FullAccountingModel();
  }

  //
  choose(option: number) {
    let temp = this.developers.filter(d => d.id == option);
    for (var i = 0; i < temp.length; i++) {
      this.option = temp[i].id as number;
    }
  }

  //
  save() {
    this.editModel.developerId = this.option;
    this.dataManage.appointDeveloper(this.editModel).subscribe((data: FullAccountingModel) => this.loadFullData());
  }  

  //
  delete() {

  }

}
