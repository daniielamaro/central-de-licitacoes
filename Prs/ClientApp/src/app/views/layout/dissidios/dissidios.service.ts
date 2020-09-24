import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlService } from 'src/app/shared/class/url-service';

@Injectable()
export class DissidiosService {

  constructor(private urlService: UrlService) { }

  obterDissidio(id: string){
    return this.urlService.sendRequestPost(`Dissidio/GetDissidioByEstadoId?id=${id}`);
  }

  obterDissidioById(id: string){
    return this.urlService.sendRequestPost(`Dissidio/GetDissidioById?id=${id}`);
  }

  obterStatus(){
    return this.urlService.sendRequestPost(`Dissidio/ObterStatusDissidios`);
  }

  cadastrarDissidio(
    estadoId: number,
    dataBase: string,
    dataUltima: string,
    pisoSalarial8h: number,
    pisoSalarial6h: number,
    ticket8h: number,
    ticket6h: number,
    benefInd8h: number,
    benefInd6h: number,
    reajuste: number,
    observacoes: string,
    vigenciaInicio: string,
    vigenciaFinal: string,
    cnpj: string,
    conformeCargoFuncao: string,
    arquivo: any,
    atalho: string
  ){
    return this.urlService.sendRequestPost(`Dissidio/CreateDissidio`, JSON.stringify({
      estadoId: estadoId,
      dataBase: dataBase,
      dataUltima: dataUltima,
      pisoSalarial8h: pisoSalarial8h,
      pisoSalarial6h: pisoSalarial6h,
      ticket8h: ticket8h,
      ticket6h: ticket6h,
      benefInd8h: benefInd8h,
      benefInd6h: benefInd6h,
      reajuste: reajuste,
      observacoes: observacoes,
      vigenciaInicio: vigenciaInicio,
      vigenciaFinal: vigenciaFinal,
      cnpj: cnpj,
      conformeCargoFuncao: conformeCargoFuncao,
      arquivo: arquivo,
      atalho: atalho
    }));
  }

  atualizarDissidio(
    id: number,
    dataBase: string,
    dataUltima: string,
    pisoSalarial8h: number,
    pisoSalarial6h: number,
    ticket8h: number,
    ticket6h: number,
    benefInd8h: number,
    benefInd6h: number,
    reajuste: number,
    observacoes: string,
    vigenciaInicio: string,
    vigenciaFinal: string,
    cnpj: string,
    conformeCargoFuncao: string,
    arquivo: any,
    atalho: string
  ){
    return this.urlService.sendRequestPost(`Dissidio/UpdateDissidio`, JSON.stringify({
      id: id,
      dataBase: dataBase,
      dataUltima: dataUltima,
      pisoSalarial8h: pisoSalarial8h,
      pisoSalarial6h: pisoSalarial6h,
      ticket8h: ticket8h,
      ticket6h: ticket6h,
      benefInd8h: benefInd8h,
      benefInd6h: benefInd6h,
      reajuste: reajuste,
      observacoes: observacoes,
      vigenciaInicio: vigenciaInicio,
      vigenciaFinal: vigenciaFinal,
      cnpj: cnpj,
      conformeCargoFuncao: conformeCargoFuncao,
      arquivo: arquivo,
      atalho: atalho
    }));
  }
}
