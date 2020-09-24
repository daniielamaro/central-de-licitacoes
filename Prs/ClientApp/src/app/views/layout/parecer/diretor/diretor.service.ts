import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class DiretorService {
   constructor(
      private urlService: UrlService
   ) {}

   obterEdital(id: string) {
      return this.urlService.sendRequestPost(`Edital/GetById?id=${id}`);
   }

   obterDadosForm() {
      return this.urlService.sendRequestPost(`ParecerDiretorComercial/GetDadosParecerDiretor`);
   }

   obterParecerGerente(id: string) {
      return this.urlService.sendRequestPost(`ParecerGerenteConta/GetById?id=${id}`);
   }

   obterParecer(id: string) {
      return this.urlService.sendRequestPost(`ParecerDiretorComercial/GetById?id=${id}`);
   }

   cadastrarParecer(
      editalId: number,
      decisao: string,
      empresa: string,
      motivoComumId: string,
      gerente: string,
      observacao: string,
      anexo1,
      anexo2
   ) {
      return this.urlService.sendRequestPost(`ParecerDiretorComercial/Create`,
         JSON.stringify({
            responsavelRequestId: this.urlService.getUser().id,
            editalId: editalId,
            decisao: decisao,
            empresaId: Number(empresa),
            motivosComumId: Number(motivoComumId),
            gerenteId: Number(gerente),
            observacao: observacao,
            anexo1: anexo1,
            anexo2: anexo2,
         }));
   }

   atualizarParecer(
      id: number,
      editalId: number,
      decisao: string,
      empresa: string,
      motivoComumId: string,
      gerente: string,
      observacao: string,
      anexo1,
      anexo2
   ) {
      return this.urlService.sendRequestPut(`ParecerDiretorComercial/Update`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         id: id,
         editalId: editalId,
         decisao: decisao,
         empresaId: Number(empresa),
         motivoComumId: Number(motivoComumId),
         gerenteId: Number(gerente),
         observacao: observacao,
         anexo1: anexo1,
         anexo2: anexo2,
      }));
   }
}
