import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';

@Injectable()
export class IndicadoresService {

  constructor(private urlService: UrlService) { }

  autenticateTokenUser(){
    return this.urlService.sendRequestPost(`Usuario/AutenticateTokenUser`);
  }
}
