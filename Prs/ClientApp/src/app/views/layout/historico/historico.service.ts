import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';

@Injectable()
export class HistoricoService {

  constructor(private urlService: UrlService) { }

  GetHistoricoByEditalId(id: string){
    return this.urlService.sendRequestPost(`Historico/GetHistoricoByEditalId?id=${id}`);
  }
}
