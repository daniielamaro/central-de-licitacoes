import { Injectable } from '@angular/core';
import { UrlService } from '../../../../shared/class/url-service';

@Injectable()
export class GerenteService {

  constructor(private urlService: UrlService) { }

  obterEdital(id: string){
    return this.urlService.sendRequestPost(`Edital/GetById?id=${id}`);
  }

  obterDadosForm(){
    return this.urlService.sendRequestPost(`ParecerGerenteConta/GetDadosParecerGerente`);
  }

  obterParecer(id: string){
    return this.urlService.sendRequestPost(`ParecerGerenteConta/GetById?id=${id}`);
  }

  cadastrarParecer(
    parecer: string,
    motivo: string,
    natureza: string,
    observacao: string,
    empresa: string,
    preVenda: string,
    editalId: number,
    codCrm: string,
    anexo1,
    anexo2){

    return this.urlService.sendRequestPost(`ParecerGerenteConta/Create`, JSON.stringify({
      responsavelRequestId: this.urlService.getUser().id,
      editalId: editalId,
      parecer: parecer,
      natureza: natureza,
      motivoComumId: Number(motivo),
      crm: Number(codCrm),
      observacao: observacao,
      empresaId: Number(empresa),
      preVendaId: Number(preVenda),
      anexo1: anexo1,
      anexo2: anexo2
    }));

  }

  atualizarParecer(
    id: number,
    parecer: string,
    motivo: string,
    natureza: string,
    observacao: string,
    empresa: string,
    preVenda: string,
    editalId,
    codCrm,
    anexo1,
    anexo2){
      return this.urlService.sendRequestPut(`ParecerGerenteConta/Update`, JSON.stringify({
        responsavelRequestId: this.urlService.getUser().id,
        id: id,
        editalId: editalId,
        parecer: parecer,
        natureza: natureza,
        motivoComumId: Number(motivo),
        crm: Number(codCrm),
        observacao: observacao,
        empresaId: Number(empresa),
        preVendaId: Number(preVenda),
        anexo1: anexo1,
        anexo2: anexo2,
        ativo: true
      }));

  }

}
