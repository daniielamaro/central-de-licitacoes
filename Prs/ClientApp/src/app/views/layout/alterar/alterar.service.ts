import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AlterarService {

  constructor(private urlService: UrlService) { }

  public verificarEdital(id: string): any {
    return this.urlService.sendRequestFetchPost(`Edital/VerifyExists?id=${id}`);
  }

  public verificarParecerGerente(id: string): any {
    return this.urlService.sendRequestFetchPost(`ParecerGerenteConta/VerifyExists?id=${id}`);
  }

  public verificarParecerDiretor(id: string): any {
    return this.urlService.sendRequestFetchPost(`ParecerDiretorComercial/VerifyExists?id=${id}`);
  }

  public verificarParecerLicitacao(id: string): any {
    return this.urlService.sendRequestFetchPost(`ParecerLicitacao/VerifyExists?id=${id}`);
  }

}
