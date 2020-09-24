import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { UrlService } from '../../shared/class/url-service';

@Injectable()
export class LoginService {

  constructor(private urlService: UrlService) { }

  login(usuario: string, senha: string) {
    return this.urlService.sendRequestPostWithoutHeaders(`Usuario/Login?login=${usuario}&senha=${senha}`, "");
  }

  solicitar(nome: string, email: string, motivo: string) {
    return this.urlService.sendRequestPostWithoutHeaders(`SolicitacaoCadastro/CreateSolicitacao?nome=${nome}&email=${email}&motivo=${motivo}`, "");
    }
}
