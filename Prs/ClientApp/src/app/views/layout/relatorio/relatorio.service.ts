import { Injectable } from '@angular/core';
import { UrlService } from '../../../shared/class/url-service';
import * as XLSX from 'xlsx';

@Injectable()
export class RelatorioService {
   constructor(
      private urlService: UrlService
   ) {}

   obterDadosForm() {
      return this.urlService.sendRequestPost(`Relatorio/GetFormRelatorio`);
   }

   exportXLSX(dados: any) {
      const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(dados);
      const wb: XLSX.WorkBook = XLSX.utils.book_new();
      XLSX.utils.book_append_sheet(wb, ws, 'Relatorio');

      XLSX.writeFile(wb, 'Relatorio.xlsx');
   }

   obterRelatorio(
      numEdital: string,
      cliente: string,
      dataAberturaInicio: string,
      dataAberturaFinal: string,
      modalidade: string,
      regiao: string,
      estado: string,
      uasg: string,
      consorcio: string,
      portal: string,
      gerenteDeContas: string,
      diretorComercial: string,
      valorEstimadoInicio: string,
      valorEstimadoFinal: string,
      parecer: string,
      motivoComum: string,
      preVenda: string,
      decisao: string,
      empresa: string,
      categoria: string,
      resultado: string,
      motivoPerda: string,
      nossoValorInicio: string,
      nossoValorFinal: string,
      vencedor: string,
      valorVencedorInicio: string,
      valorVencedorFinal: string,
      responsavel: string,
      bu: string,
   ) {
      return this.urlService.sendRequestPost(`Relatorio/CreateRelatorio`,
         JSON.stringify({
            numEdital: numEdital,
            clienteId: Number(cliente),
            dataAberturaInicio: dataAberturaInicio,
            dataAberturaFinal: dataAberturaFinal,
            modalidadeId: Number(modalidade),
            regiaoId: Number(regiao),
            estadoId: Number(estado),
            uasg: uasg,
            consorcio: consorcio,
            portalId: Number(portal),
            gerenteId: Number(gerenteDeContas),
            diretorId: Number(diretorComercial),
            valorEstimadoInicio: Number(valorEstimadoInicio),
            valorEstimadoFinal: Number(valorEstimadoFinal),
            parecerGerente: parecer,
            motivoComumId: Number(motivoComum),
            preVendaId: Number(preVenda),
            parecerDiretor: decisao,
            empresaId: Number(empresa),
            categoriaId: Number(categoria),
            parecerLicitacao: resultado,
            motivoPerdaId: Number(motivoPerda),
            nossoValorInicio: Number(nossoValorInicio),
            nossoValorFinal: Number(nossoValorFinal),
            vencedorId: Number(vencedor),
            valorVencedorInicio: Number(valorVencedorInicio),
            valorVencedorFinal: Number(valorVencedorFinal),
            responsavelId: Number(responsavel),
            buId: Number(bu)
         }));
   }
}
