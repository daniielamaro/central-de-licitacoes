import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class BuService {
   constructor(private urlService: UrlService) {}

   obterBus() {
      return this.urlService.sendRequestPost(`Bu/GetAll`);
   }

   cadastrarBu(nome: string) {
      return this.urlService.sendRequestPost(`Bu/Create`, JSON.stringify({
         nome
      }));
   }

   alterarBu(id: number, nome: string, ativo: boolean) {
      return this.urlService.sendRequestPut(`Bu/Update`, JSON.stringify({
         id,
         nome,
         ativo
      }));
   }


}
