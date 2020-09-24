import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class ClienteService {
   constructor(
      private urlService: UrlService
   ) {}

   obterClientes() {
      return this.urlService.sendRequestPost(`Cliente/GetAllClientes`);
   }

   buscarCliente(id: number) {
      return this.urlService.sendRequestPost(`Cliente/GetById?id=${id}`);
   }

   verificarClientes(nome: string) {
      return this.urlService.sendRequestPost(`Cliente/GetByName?nome=${nome}`, JSON.stringify({
         nome
      }));
   }

   cadastrarClientes(nome: string, apelido: string, cnpj: string) {
      return this.urlService.sendRequestPost(`Cliente/Create`, JSON.stringify({
         nome,
         apelido,
         cnpj
      }));
   }

   alterarClientes(id: number, nome: string, apelido: string, cnpj: string, ativo: boolean) {
      return this.urlService.sendRequestPut(`Cliente/Update`, JSON.stringify({
         id,
         nome,
         apelido,
         cnpj,
         ativo
      }));
   }


}
