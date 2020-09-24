import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class ModalidadeService {
   constructor(
      private urlService: UrlService
   ) {}

   obterModalidades() {
      return this.urlService.sendRequestPost(`Modalidade/GetAll`);
   }

   cadastrarModalidade(
      nome: string,
   ) {
      return this.urlService.sendRequestPost(`Modalidade/Create`,
         JSON.stringify({
            nome
         }));
   }

   alterarModalidade(
      id: number,
      nome: string,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`Modalidade/Update`, JSON.stringify({
         id,
         nome,
         ativo
      }));
   }


}
