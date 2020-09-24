import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class ConcorrenteService {
   constructor(
      private urlService: UrlService
   ) {}

   obterConcorentes() {
      return this.urlService.sendRequestPost(`Concorrente/GetAll`);
   }

   buscarConcorrente(
      id: number
   ) {
      return this.urlService.sendRequestPost(`Concorrente/GetById?id=${id}`);
   }

   verificarConcorrente(
      nome: string
   ) {
      return this.urlService.sendRequestPost(`Concorrente/GetByName?nome=${nome}`,
         JSON.stringify({
            nome
         }));
   }

   cadastrarConcorrente(
      nome: string,
      apelido: string,
      cnpj: string,
   ) {
      return this.urlService.sendRequestPost(`Concorrente/Create`,
         JSON.stringify({
            nome,
            apelido,
            cnpj
         }));
   }

   alterarConcorrente(
      id: number,
      nome: string,
      apelido: string,
      cnpj: string,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`Concorrente/Update`, JSON.stringify({
         id,
         nome,
         apelido,
         cnpj,
         ativo
      }));
   }


}
