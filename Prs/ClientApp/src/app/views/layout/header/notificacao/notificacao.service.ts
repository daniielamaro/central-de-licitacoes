import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlService } from 'src/app/shared/class/url-service';

@Injectable()
export class NotificacaoService {

  constructor(private http: HttpClient, private urlService: UrlService) { }

  getNotificacao(id: number) {
    return this.urlService.sendRequestPost(`Usuario/GetNotification?id=${id}`);
  }
}
