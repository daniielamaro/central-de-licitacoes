import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlService } from 'src/app/shared/class/url-service';

@Injectable()
export class CarteiraContaService {
   constructor(private http: HttpClient, private urlService: UrlService) {}

   listarCarteira() {
      return this.urlService.sendRequestPost(`CarteiraConta/GetAllCarteiraContas`);
   }

   obterDadosForm() {
      return this.urlService.sendRequestPost(`CarteiraConta/GetFormCarteiraConta`);
   }

   insertCarteira(gerenteId: string, clienteId: string) {
      return this.urlService.sendRequestPost(`CarteiraConta/CreateCarteiraConta?gerenteId=${Number(gerenteId)}&clienteId=${Number(clienteId)}`);
   }

   deleteCarteira(id: string) {
      return this.urlService.sendRequestPost(`CarteiraConta/DeleteCarteiraConta?id=${Number(id)}`);
   }

   deleteGrenteCarteira(id: string) {
      return this.urlService.sendRequestPut(`CarteiraConta/DeleteGerenteCarteiraConta?id=${Number(id)}`);
   }

   deleteGrenteComCarteira(id: string) {
      return this.urlService.sendRequestPost(`CarteiraConta/DeleteGerenteComCarteiraConta?id=${Number(id)}`);
   }
}
