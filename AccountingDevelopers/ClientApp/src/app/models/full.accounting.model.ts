export class FullAccountingModel {
  constructor(
    public projectId?: number,
    public projectName?: string,
    public description?: string,
    public dateOfCreate?: Date,
    public developerId?: number,
    public fullName?: string,
    public position?: string
  ) { }
}
