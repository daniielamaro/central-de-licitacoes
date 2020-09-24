import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Alertas } from '../../../shared/class/alertas';
import { RelatorioService } from './relatorio.service';

@Component({
   selector: 'app-relatorio',
   templateUrl: './relatorio.component.html',
   styleUrls: ['./relatorio.component.css'],
})
export class RelatorioComponent implements OnInit {
  @ViewChild('table', { read: false }) table: ElementRef;

   public relatorio: FormGroup;
   public dadosForm: any;
   public dadosRelatorio: any;

   public seta: Array<any> = [
      "../../../../assets/iconis/baixo03.png",
      "../../../../assets/iconis/cima01.png"
    ];

    public toogleSetaEdital: string;
    public toogleSetaGerente: string;
    public toogleSetaDiretor: string;
    public toogleSetaLicitacao: string;

   public tabTags: Array<string> = [
      'id',
      'cliente',
      'nº edital',
      'uasg',
      'categoria',
      'regiao',
      'data de abertura',
      'modalidade',
      'portal',
      'gerente',
      'diretor',
      'bu',
      'parecer',
      'motivo comum',
      'pre-venda',
      'decisao',
      'empresa',
      'resultado',
      'motivo da perda',
      'nosso valor',
      'vencedor',
      'valor vencedor',
      'responsavel',
   ];


   constructor(
      private fb: FormBuilder,
      private alertas: Alertas,
      private relatorioService: RelatorioService
   ) {}

   ngOnInit(): void {
      this.relatorio = this.fb.group({
         numEdital: this.fb.control(''),
         cliente: this.fb.control(''),
         dataAberturaInicio: this.fb.control(''),
         dataAberturaFinal: this.fb.control(''),
         modalidade: this.fb.control(''),
         regiao: this.fb.control(''),
         estado: this.fb.control(''),
         uasg: this.fb.control(''),
         consorcio: this.fb.control(''),
         portal: this.fb.control(''),
         gerenteDeContas: this.fb.control(''),
         diretorComercial: this.fb.control(''),
         valorEstimadoInicio: this.fb.control(''),
         valorEstimadoFinal: this.fb.control(''),
         bu: this.fb.control(''),
         parecer: this.fb.control(''),
         motivoComum: this.fb.control(''),
         preVenda: this.fb.control(''),
         decisao: this.fb.control(''),
         empresa: this.fb.control(''),
         categoria: this.fb.control(''),
         resultado: this.fb.control(''),
         motivoPerda: this.fb.control(''),
         nossoValorInicio: this.fb.control(''),
         nossoValorFinal: this.fb.control(''),
         vencedor: this.fb.control(''),
         valorVencedorInicio: this.fb.control(''),
         valorVencedorFinal: this.fb.control(''),
         responsavel: this.fb.control(''),
      });

      this.getDadosForm();

      this.toogleSetaEdital = this.seta[0];
      this.toogleSetaGerente = this.seta[0];
      this.toogleSetaDiretor = this.seta[0];
      this.toogleSetaLicitacao = this.seta[0];
   }

   toogleTab(tabNome: string) {
      if (this.tabTags.indexOf(tabNome) > -1) {
         this.tabTags.splice(this.tabTags.indexOf(tabNome), 1);
      } else {
         this.tabTags.push(tabNome);
      }
   }

   getDadosForm() {
      this.relatorioService.obterDadosForm().subscribe((res) => {
         this.dadosForm = res;
      });
   }

   exportXLSX() {
      this.relatorioService.exportXLSX(this.table.nativeElement);
   }

   obterRelatorio() {
      this.alertas.showLoading('Buscando Editais');

      this.dadosRelatorio = null;

      this.relatorioService
         .obterRelatorio(
            this.relatorio.get('numEdital').value,
            this.relatorio.get('cliente').value,
            this.relatorio.get('dataAberturaInicio').value,
            this.relatorio.get('dataAberturaFinal').value,
            this.relatorio.get('modalidade').value,
            this.relatorio.get('regiao').value,
            this.relatorio.get('estado').value,
            this.relatorio.get('uasg').value,
            this.relatorio.get('consorcio').value,
            this.relatorio.get('portal').value,
            this.relatorio.get('gerenteDeContas').value,
            this.relatorio.get('diretorComercial').value,
            this.relatorio.get('valorEstimadoInicio').value,
            this.relatorio.get('valorEstimadoFinal').value,
            this.relatorio.get('parecer').value,
            this.relatorio.get('motivoComum').value,
            this.relatorio.get('preVenda').value,
            this.relatorio.get('decisao').value,
            this.relatorio.get('empresa').value,
            this.relatorio.get('categoria').value,
            this.relatorio.get('resultado').value,
            this.relatorio.get('motivoPerda').value,
            this.relatorio.get('nossoValorInicio').value,
            this.relatorio.get('nossoValorFinal').value,
            this.relatorio.get('vencedor').value,
            this.relatorio.get('valorVencedorInicio').value,
            this.relatorio.get('valorVencedorFinal').value,
            this.relatorio.get('responsavel').value,
            this.relatorio.get('bu').value
         )
         .subscribe((res) => {
            this.dadosRelatorio = res;
            this.alertas.fecharModal();
         });
   }

   limparFiltro() {
      this.relatorio.get('numEdital').setValue('');
      this.relatorio.get('cliente').setValue('');
      this.relatorio.get('dataAberturaInicio').setValue('');
      this.relatorio.get('dataAberturaFinal').setValue('');
      this.relatorio.get('modalidade').setValue('');
      this.relatorio.get('regiao').setValue('');
      this.relatorio.get('estado').setValue('');
      this.relatorio.get('uasg').setValue('');
      this.relatorio.get('consorcio').setValue('');
      this.relatorio.get('portal').setValue('');
      this.relatorio.get('gerenteDeContas').setValue('');
      this.relatorio.get('diretorComercial').setValue('');
      this.relatorio.get('valorEstimadoInicio').setValue('');
      this.relatorio.get('valorEstimadoFinal').setValue('');
      this.relatorio.get('parecer').setValue('');
      this.relatorio.get('motivoComum').setValue('');
      this.relatorio.get('preVenda').setValue('');
      this.relatorio.get('decisao').setValue('');
      this.relatorio.get('empresa').setValue('');
      this.relatorio.get('categoria').setValue('');
      this.relatorio.get('resultado').setValue('');
      this.relatorio.get('motivoPerda').setValue('');
      this.relatorio.get('nossoValorInicio').setValue('');
      this.relatorio.get('nossoValorFinal').setValue('');
      this.relatorio.get('vencedor').setValue('');
      this.relatorio.get('valorVencedorInicio').setValue('');
      this.relatorio.get('valorVencedorFinal').setValue('');
      this.relatorio.get('responsavel').setValue('');
      this.relatorio.get('bu').setValue('');

      this.dadosRelatorio = null;
   }

   toogleCard(posicao: number){
      if(posicao == 1){
         if(this.toogleSetaEdital == this.seta[0]){
            this.toogleSetaEdital = this.seta[1];
         }else{
            this.toogleSetaEdital = this.seta[0];
         }
      }else if(posicao == 2){
         if(this.toogleSetaGerente == this.seta[0]){
            this.toogleSetaGerente = this.seta[1];
         }else{
            this.toogleSetaGerente = this.seta[0];
         }
      }else if(posicao == 3){
         if(this.toogleSetaDiretor == this.seta[0]){
            this.toogleSetaDiretor = this.seta[1];
         }else{
            this.toogleSetaDiretor = this.seta[0];
         }
      }else if(posicao == 4){
         if(this.toogleSetaLicitacao == this.seta[0]){
            this.toogleSetaLicitacao = this.seta[1];
         }else{
            this.toogleSetaLicitacao = this.seta[0];
         }
      }
   }
}
