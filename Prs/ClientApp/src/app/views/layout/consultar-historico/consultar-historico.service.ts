import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';

@Injectable()
export class ConsultarHistoricoService {

  constructor(private urlService: UrlService) { }

  public verificarEdital(id: string): any {
    return this.urlService.sendRequestFetchPost(`Edital/VerifyExists?id=${id}`);
  }
}
