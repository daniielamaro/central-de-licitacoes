import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';

@Injectable()
export class SlaService {

  constructor(private urlService: UrlService) { }

  getTMC(){
    return this.urlService.sendRequestPost(`Sla/GetTMC`);
  }

  getTMPG(){
    return this.urlService.sendRequestPost(`Sla/GetTMPG`);
  }

  getTMPD(){
    return this.urlService.sendRequestPost(`Sla/GetTMPD`);
  }

  getSlaGerentes(){
    return this.urlService.sendRequestPost(`Sla/GetSlaGerentes`);
  }
  getSlaDiretores(){
    return this.urlService.sendRequestPost(`Sla/GetSlaDiretores`);
  }
}
