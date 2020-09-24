import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class MotivoComumService {
   constructor(
      private urlService: UrlService
   ) {}

   obterMotivosComum() {
      return this.urlService.sendRequestPost(`MotivoComum/GetAll`);
   }

   cadastrarMotivoComum(
      nome: string,
   ) {
      return this.urlService.sendRequestPost(`MotivoComum/Create`, JSON.stringify({
         nome
      }));
   }

   alterarMotivoComum(
      id: number,
      nome: string,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`MotivoComum/Update`, JSON.stringify({
         id,
         nome,
         ativo
      }));
   }


}
