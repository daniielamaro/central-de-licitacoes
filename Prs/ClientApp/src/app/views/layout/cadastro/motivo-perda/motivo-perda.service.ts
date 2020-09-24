import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class MotivoPerdaService {
   constructor(
      private urlService: UrlService
   ) {}

   obterMotivosPerda() {
      return this.urlService.sendRequestPost(`MotivoPerda/GetAll`);
   }

   cadastrarMotivoPerda(
      nome: string,
   ) {
      return this.urlService.sendRequestPost(`MotivoPerda/Create`, JSON.stringify({
         nome
      }));
   }

   alterarMotivoPerda(
      id: number,
      nome: string,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`MotivoPerda/Update`, JSON.stringify({
         id,
         nome,
         ativo
      }));
   }


}
