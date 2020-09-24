import { Role } from './role';

export class User{
    id: number = 0;
    nome: string = "";
    login: string = "";
    email: string = "";
    token: string = "";
    role: Role = new Role();
}