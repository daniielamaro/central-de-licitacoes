import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { UrlService }  from '../../../shared/class/url-service';
import { User } from '../user';
import { Router } from '@angular/router';

@Injectable()
export class HomeService {

   constructor(private http: HttpClient, private router: Router, private urlService: UrlService) { }

   getDadoForm() {
      return this.urlService.sendRequestPost(`Edital/GetDadosCadastrarEdital`);
   }

   getWaitingGerente(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`ParecerGerenteConta/GetWaitingGerente`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getWaitingDiretor(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`ParecerDiretorComercial/GetWaitingDiretor`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getWaitingLicitacao(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/GetWaitingLicitacao`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getAguardandoFinalizacao(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/GetAguardandoFinalizacao`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getSuspenso(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`ParecerLicitacao/GetSuspenso`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getTotalEditalGanhos(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`Edital/GetTotalEditalGanhos`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getTotalEdital(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`Edital/GetTotalEdital`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getTotalEditalGo(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`Edital/GetTotalEditalGo`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getTotalEditalNoGo(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`Edital/GetTotalEditalNogo`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   getTotalEditalSuspenso(
      id: string,
      numEdital: string,
      clienteId: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidadeId: string,
      regiaoId: string,
      estadoId: string,
      categoriaId: string,
      uasg: string,
      consorcio: string,
      portalId: string,
      gerenteId: string,
      diretorId: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      buId: string
   ) {
      return this.urlService.sendRequestPost(`Edital/GetTotalEditalSuspenso`, JSON.stringify({
         id: Number(id),
         numEdital: numEdital,
         clienteId: Number(clienteId),
         dataAberturaInicio: dataAberturaInicio,
         dataAberturaFinal: dataAberturaFinal,
         modalidadeId: Number(modalidadeId),
         regiaoId: Number(regiaoId),
         estadoId: Number(estadoId),
         categoriaId: Number(categoriaId),
         uasg: uasg,
         consorcio: consorcio,
         portalId: Number(portalId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         valorEstimadoInicio: Number(valorEstimadoInicio),
         valorEstimadoFinal: Number(valorEstimadoFinal),
         buId: Number(buId)
      }));
   }

   obterComentarios(id: string){
      return this.urlService.sendRequestPost(`Comentario/Getlast?editalId=${id}`);
   }


   getUser(){
      return this.urlService.getUser();
   }
}
