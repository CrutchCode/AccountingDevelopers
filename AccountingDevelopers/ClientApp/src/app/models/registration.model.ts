export class RegistrationModel {
  constructor(
    public login?: string,
    public userName?: string,
    public password?: string,
    public confirmPassword?: string
  ) { }
}
