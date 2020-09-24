import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class PortalService {
   constructor(
      private urlService: UrlService
   ) {}

   obterPortais() {
      return this.urlService.sendRequestPost(`Portal/GetAll`);
   }

   cadastrarPortal(
      nome: string,
   ) {
      return this.urlService.sendRequestPost(`Portal/Create`,
         JSON.stringify({
            nome
         }));
   }

   alterarPortal(
      id: number,
      nome: string,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`Portal/Update`,
         JSON.stringify({
            id,
            nome,
            ativo
         }));
   }


}
