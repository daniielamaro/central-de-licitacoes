import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlService } from 'src/app/shared/class/url-service';

@Injectable()
export class EditalService {
   constructor(private http: HttpClient, private urlService: UrlService) {}

   getDadosCadastrarEdital() {
      return this.urlService.sendRequestPost(`Edital/GetDadosCadastrarEdital`);
   }

   cadastrarEdital(
      numEdital: string,
      clienteId: string,
      estadoId: string,
      modalidadeId: string,
      dataDeAbertura: string,
      horaDeAbertura: string,
      uasg: string,
      categoriaId: string,
      consorcio: string,
      valorEstimado: string,
      agendarVistoria: string,
      dataVistoria: string,
      objetosDescricao: string,
      objetosResumo: string,
      observacoes: string,
      regiaoId: string,
      gerenteId: string,
      diretorId: string,
      portalId: string,
      arquivo: any
   ) {
      return this.urlService.sendRequestPost(`Edital/Create`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         numEdital: numEdital,
         clienteId: Number(clienteId),
         estadoId: Number(estadoId),
         modalidadeId: Number(modalidadeId),
         dataDeAbertura: dataDeAbertura,
         horaDeAbertura: horaDeAbertura,
         uasg: uasg,
         categoriaId: Number(categoriaId),
         consorcio: consorcio,
         valorEstimado: Number(valorEstimado),
         agendarVistoria: agendarVistoria,
         dataVistoria: dataVistoria,
         objetosDescricao: objetosDescricao,
         objetosResumo: objetosResumo,
         observacoes: observacoes,
         regiaoId: Number(regiaoId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         portalId: Number(portalId),
         anexo: arquivo,
      }));
   }

   atualizarEdital(
      id: string,
      numEdital: string,
      clienteId: string,
      estadoId: string,
      modalidadeId: string,
      dataDeAbertura: string,
      horaDeAbertura: string,
      uasg: string,
      categoriaId: string,
      consorcio: string,
      valorEstimado: string,
      agendarVistoria: string,
      dataVistoria: string,
      objetosDescricao: string,
      objetosResumo: string,
      observacoes: string,
      regiaoId: string,
      gerenteId: string,
      diretorId: string,
      portalId: string,
      arquivo: any
   ) {
      return this.urlService.sendRequestPut(`Edital/Update`, JSON.stringify({
            responsavelRequestId: this.urlService.getUser().id,
            id: Number(id),
            ativo: true,
            numEdital: numEdital,
            clienteId: Number(clienteId),
            estadoId: Number(estadoId),
            modalidadeId: Number(modalidadeId),
            dataDeAbertura: dataDeAbertura,
            horaDeAbertura: horaDeAbertura,
            uasg: uasg,
            categoriaId: Number(categoriaId),
            consorcio: consorcio,
            valorEstimado: Number(valorEstimado),
            agendarVistoria: agendarVistoria,
            dataVistoria: dataVistoria,
            objetosDescricao: objetosDescricao,
            objetosResumo: objetosResumo,
            observacoes: observacoes,
            regiaoId: Number(regiaoId),
            gerenteId: Number(gerenteId),
            diretorId: Number(diretorId),
            portalId: Number(portalId),
            anexo: arquivo,
         }));
   }

   restaurarEdital(
      id: string,
      numEdital: string,
      clienteId: string,
      estadoId: string,
      modalidadeId: string,
      dataDeAbertura: string,
      horaDeAbertura: string,
      uasg: string,
      categoriaId: string,
      consorcio: string,
      valorEstimado: string,
      agendarVistoria: string,
      dataVistoria: string,
      objetosDescricao: string,
      objetosResumo: string,
      observacoes: string,
      regiaoId: string,
      gerenteId: string,
      diretorId: string,
      portalId: string,
      arquivo: any
   ) {
      return this.urlService.sendRequestPut(`Edital/Restaurar`, JSON.stringify({
         responsavelRequestId: this.urlService.getUser().id,
         id: Number(id),
         ativo: true,
         numEdital: numEdital,
         clienteId: Number(clienteId),
         estadoId: Number(estadoId),
         modalidadeId: Number(modalidadeId),
         dataDeAbertura: dataDeAbertura,
         horaDeAbertura: horaDeAbertura,
         uasg: uasg,
         categoriaId: Number(categoriaId),
         consorcio: consorcio,
         valorEstimado: Number(valorEstimado),
         agendarVistoria: agendarVistoria,
         dataVistoria: dataVistoria,
         objetosDescricao: objetosDescricao,
         objetosResumo: objetosResumo,
         observacoes: observacoes,
         regiaoId: Number(regiaoId),
         gerenteId: Number(gerenteId),
         diretorId: Number(diretorId),
         portalId: Number(portalId),
         anexo: arquivo,
      }));
   }

  obterEdital(id: string){
    return this.urlService.sendRequestPost(`Edital/GetById?id=${id}`);
  }

  obterAnexo(id: Number){
    return this.urlService.sendRequestPost(`Anexo/GetById?id=${id}`);
  }

  suspenderEdital(id: Number){
    return this.urlService.sendRequestPost(`Edital/SuspenderEdital?id=${id}&responsavelId=${this.urlService.getUser().id}`);
  }
}
