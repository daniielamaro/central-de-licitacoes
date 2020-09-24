import { Injectable } from '@angular/core';
import { UrlService } from 'src/app/shared/class/url-service';

@Injectable()
export class LicitacaoService {
   constructor(
      private urlService: UrlService
   ) {}

   obterEdital(id: string) {
      return this.urlService.sendRequestPost(`Edital/GetById?id=${id}`);
   }

   obterParecerGerente(id: string) {
      return this.urlService.sendRequestPost(`ParecerGerenteConta/GetById?id=${id}`);
   }

   obterParecerDiretor(id: string) {
      return this.urlService.sendRequestPost(`ParecerDiretorComercial/GetById?id=${id}`);
   }

   obterDadosForm() {
      return this.urlService.sendRequestPost(`ParecerLicitacao/GetDadosParecerLicitacao`);
   }

   obterParecer(id: string) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/GetById?id=${id}`);
   }

   cadastrarParecer(
      editalId: number,
      resultado: string,
      nossoValor: number,
      motivosPerdaId: string,
      vencedorId: string,
      valorVencedor: number,
      nossaClassificacao: number,
      observacao: string,
      responsavelId: string,
      anexo1,
      anexo2,
   ) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/Create`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         editalId: Number(editalId),
         resultado: resultado,
         nossoValor: Number(nossoValor),
         motivosPerdaId: Number(motivosPerdaId),
         vencedorId: Number(vencedorId),
         valorVencedor: Number(valorVencedor),
         nossaClassificacao: Number(nossaClassificacao),
         observacao: observacao,
         responsavelId: Number(responsavelId),
         anexo1: anexo1,
         anexo2: anexo2,
      }));
   }

   atualizarParecer(
      id: number,
      resultado: string,
      nossoValor: number,
      motivosPerdaId: string,
      vencedorId: string,
      valorVencedor: number,
      nossaClassificacao: number,
      observacao: string,
      responsavelId: string,
      anexo1,
      anexo2,
   ) {
      return this.urlService.sendRequestPut(`ParecerLicitacao/Update`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         id: id,
         resultado: resultado,
         nossoValor: Number(nossoValor),
         motivosPerdaId: Number(motivosPerdaId),
         vencedorId: Number(vencedorId),
         valorVencedor: Number(valorVencedor),
         nossaClassificacao: Number(nossaClassificacao),
         observacao: observacao,
         responsavelId: Number(responsavelId),
         anexo1: anexo1,
         anexo2: anexo2,
         ativo: true
      }));
   }

   finalizarParecer(
      editalId: number,
      resultado: string,
      nossoValor: number,
      motivosPerdaId: string,
      vencedorId: string,
      valorVencedor: number,
      nossaClassificacao: number,
      observacao: string,
      responsavelId: string,
      anexo1,
      anexo2,
   ) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/Finalize`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         editalId: Number(editalId),
         resultado: resultado,
         nossoValor: Number(nossoValor),
         motivosPerdaId: Number(motivosPerdaId),
         vencedorId: Number(vencedorId),
         valorVencedor: Number(valorVencedor),
         nossaClassificacao: Number(nossaClassificacao),
         observacao: observacao,
         responsavelId: Number(responsavelId),
         anexo1: anexo1,
         anexo2: anexo2,
      }));
   }

   public verificarParecerLicitacao(id: string): any {
      return this.urlService.sendRequestPost(`ParecerLicitacao/VerifyExists?id=${id}`);
    }
}
