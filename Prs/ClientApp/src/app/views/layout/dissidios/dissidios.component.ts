import { Component, OnInit } from '@angular/core';
import { DissidiosService } from './dissidios.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Arquivo } from '../../../shared/upload/arquivo';
import { Alertas } from '../../../shared/class/alertas';

@Component({
   selector: 'app-dissidios',
   templateUrl: './dissidios.component.html',
   styleUrls: ['./dissidios.component.css'],
})
export class DissidiosComponent implements OnInit {
   pdfSrc = '';
   dadosStatus: any;
   formCadastrar: FormGroup;
   formDissidio: FormGroup;
   dissidioEstado: any;
   exibirUpload: boolean;
   arquivo: Arquivo = new Arquivo();
   editarDissidio: boolean = false;

   exibirUploadUpdate: boolean;
   arquivoUpdate: Arquivo = new Arquivo();

   public seta: Array<any> = [
      '../../../../assets/iconis/baixo03.png',
      '../../../../assets/iconis/cima01.png',
   ];
   public toogleSeta: string;

   constructor(
      private dissidiosService: DissidiosService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.obterStatus();

      this.formDissidio = new FormGroup({
         dataBase: new FormControl(''),
         dataUltima: new FormControl(''),
         pisoSalarial8h: new FormControl(''),
         pisoSalarial6h: new FormControl(''),
         ticket8h: new FormControl(''),
         ticket6h: new FormControl(''),
         reajuste: new FormControl(''),
         benefInd8h: new FormControl(''),
         benefInd6h: new FormControl(''),
         observacoes: new FormControl(''),
         vigenciainicio: new FormControl(''),
         vigenciafim: new FormControl(''),
         cnpj: new FormControl(''),
         conformeCargoFuncao: new FormControl(''),
         arquivo: new FormControl(null),
         atalho: new FormControl('')
      });

      this.formCadastrar = new FormGroup({
         dataBase: new FormControl('', Validators.required),
         dataUltima: new FormControl(''),
         pisoSalarial8h: new FormControl('', Validators.required),
         pisoSalarial6h: new FormControl(''),
         ticket8h: new FormControl(''),
         ticket6h: new FormControl(''),
         reajuste: new FormControl(''),
         benefInd8h: new FormControl(''),
         benefInd6h: new FormControl(''),
         observacoes: new FormControl(''),
         vigenciainicio: new FormControl('', Validators.required),
         vigenciafim: new FormControl('', Validators.required),
         cnpj: new FormControl(''),
         conformeCargoFuncao: new FormControl(''),
         arquivo: new FormControl('', Validators.required),
         atalho: new FormControl('')
      });

      this.toogleSeta = this.seta[0];
   }

   toogleCard() {
      if (this.toogleSeta == this.seta[0]) {
         this.toogleSeta = this.seta[1];
      } else {
         this.toogleSeta = this.seta[0];
      }
   }

   obterStatus() {
      this.dissidiosService.obterStatus().subscribe((resp) => {
         this.dadosStatus = resp;
      });
   }

   obterDissidioById(dissidio: any) {
      this.alertas.showLoading('Carregando dissidio...');
      this.dissidiosService.obterDissidioById(dissidio.id).subscribe((resp) => {
         let dissidioRebase = {
            id: this.dissidioEstado.dissidio.id,
            dataBase: this.dissidioEstado.dissidio.dataBase,
            vigencia:
               Date.parse(this.dissidioEstado.dissidio.vigenciaInicio) <=
                  Date.now() &&
               Date.parse(this.dissidioEstado.dissidio.vigenciaFinal) >
                  Date.now()
                  ? 0
                  : Date.parse(this.dissidioEstado.dissidio.vigenciaInicio) >
                       Date.now() &&
                    Date.parse(this.dissidioEstado.dissidio.vigenciaFinal) >
                       Date.now()
                  ? 1
                  : -1,
         };
         this.dissidioEstado.listaDissidiosRestantes.splice(
            this.dissidioEstado.listaDissidiosRestantes.indexOf(dissidio),
            1,
            dissidioRebase
         );
         this.dissidioEstado.dissidio = resp;

         this.formDissidio.get("dataBase").setValue(this.dissidioEstado.dissidio.dataBase.substring(0, this.dissidioEstado.dissidio.dataBase.indexOf("T")));
         this.formDissidio.get("dataUltima").setValue(this.dissidioEstado.dissidio.dataUltima.substring(0, this.dissidioEstado.dissidio.dataUltima.indexOf("T")));
         this.formDissidio.get("pisoSalarial8h").setValue(this.dissidioEstado.dissidio.pisoSalarial8h);
         this.formDissidio.get("pisoSalarial6h").setValue(this.dissidioEstado.dissidio.pisoSalarial6h);
         this.formDissidio.get("ticket8h").setValue(this.dissidioEstado.dissidio.ticket8h);
         this.formDissidio.get("ticket6h").setValue(this.dissidioEstado.dissidio.ticket6h);
         this.formDissidio.get("reajuste").setValue(this.dissidioEstado.dissidio.reajuste);
         this.formDissidio.get("benefInd8h").setValue(this.dissidioEstado.dissidio.benefInd8h);
         this.formDissidio.get("benefInd6h").setValue(this.dissidioEstado.dissidio.benefInd6h);
         this.formDissidio.get("observacoes").setValue(this.dissidioEstado.dissidio.observacoes);
         this.formDissidio.get("vigenciainicio").setValue(this.dissidioEstado.dissidio.vigenciaInicio.substring(0, this.dissidioEstado.dissidio.vigenciaInicio.indexOf("T")));
         this.formDissidio.get("vigenciafim").setValue(this.dissidioEstado.dissidio.vigenciaFinal.substring(0, this.dissidioEstado.dissidio.vigenciaFinal.indexOf("T")));
         this.formDissidio.get("cnpj").setValue(this.dissidioEstado.dissidio.cnpj);
         this.formDissidio.get("conformeCargoFuncao").setValue(this.dissidioEstado.dissidio.conformeCargoFuncao);
         this.formDissidio.get("arquivo").setValue(this.dissidioEstado.dissidio.arquivo);
         this.formDissidio.get("atalho").setValue(this.dissidioEstado.dissidio.atalho);

         this.editarDissidio = false;
         this.alertas.fecharModal();
      });
   }

   consultar(id: string) {
      this.alertas.showLoading('Carregando dissidio...');
      this.dissidiosService
         .obterDissidio(id)
         .subscribe((resp) => {
            this.dissidioEstado = resp;
            this.editarDissidio = false;

            this.formDissidio.get("dataBase").setValue(this.dissidioEstado.dissidio.dataBase.substring(0, this.dissidioEstado.dissidio.dataBase.indexOf("T")));
            this.formDissidio.get("dataUltima").setValue(this.dissidioEstado.dissidio.dataUltima.substring(0, this.dissidioEstado.dissidio.dataUltima.indexOf("T")));
            this.formDissidio.get("pisoSalarial8h").setValue(this.dissidioEstado.dissidio.pisoSalarial8h);
            this.formDissidio.get("pisoSalarial6h").setValue(this.dissidioEstado.dissidio.pisoSalarial6h);
            this.formDissidio.get("ticket8h").setValue(this.dissidioEstado.dissidio.ticket8h);
            this.formDissidio.get("ticket6h").setValue(this.dissidioEstado.dissidio.ticket6h);
            this.formDissidio.get("reajuste").setValue(this.dissidioEstado.dissidio.reajuste);
            this.formDissidio.get("benefInd8h").setValue(this.dissidioEstado.dissidio.benefInd8h);
            this.formDissidio.get("benefInd6h").setValue(this.dissidioEstado.dissidio.benefInd6h);
            this.formDissidio.get("observacoes").setValue(this.dissidioEstado.dissidio.observacoes);
            this.formDissidio.get("vigenciainicio").setValue(this.dissidioEstado.dissidio.vigenciaInicio.substring(0, this.dissidioEstado.dissidio.vigenciaInicio.indexOf("T")));
            this.formDissidio.get("vigenciafim").setValue(this.dissidioEstado.dissidio.vigenciaFinal.substring(0, this.dissidioEstado.dissidio.vigenciaFinal.indexOf("T")));
            this.formDissidio.get("cnpj").setValue(this.dissidioEstado.dissidio.cnpj);
            this.formDissidio.get("conformeCargoFuncao").setValue(this.dissidioEstado.dissidio.conformeCargoFuncao);
            this.formDissidio.get("arquivo").setValue(this.dissidioEstado.dissidio.arquivo);
            this.formDissidio.get("atalho").setValue(this.dissidioEstado.dissidio.atalho);

            this.alertas.fecharModal();
         });
   }

   cadastrar() {
      this.alertas.showLoading('Cadastrando novo dissidio...');
      this.dissidiosService
         .cadastrarDissidio(
            Number(this.dissidioEstado.estado.id),
            this.formCadastrar.get('dataBase').value,
            this.formCadastrar.get('dataUltima').value,
            Number(this.formCadastrar.get('pisoSalarial8h').value),
            Number(this.formCadastrar.get('pisoSalarial6h').value),
            Number(this.formCadastrar.get('ticket8h').value),
            Number(this.formCadastrar.get('ticket6h').value),
            Number(this.formCadastrar.get('benefInd8h').value),
            Number(this.formCadastrar.get('benefInd6h').value),
            Number(this.formCadastrar.get('reajuste').value),
            this.formCadastrar.get('observacoes').value,
            this.formCadastrar.get('vigenciainicio').value,
            this.formCadastrar.get('vigenciafim').value,
            this.formCadastrar.get('cnpj').value,
            this.formCadastrar.get('conformeCargoFuncao').value,
            this.formCadastrar.get('arquivo').value,
            this.formCadastrar.get('atalho').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         });
   }

   dissidioeditar(){
      if(this.editarDissidio){
         this.alertas.showLoading('Atualizando dissidio...');

         this.dissidiosService.atualizarDissidio(
            Number(this.dissidioEstado.dissidio.id),
            this.formDissidio.get('dataBase').value,
            this.formDissidio.get('dataUltima').value,
            Number(this.formDissidio.get('pisoSalarial8h').value),
            Number(this.formDissidio.get('pisoSalarial6h').value),
            Number(this.formDissidio.get('ticket8h').value),
            Number(this.formDissidio.get('ticket6h').value),
            Number(this.formDissidio.get('benefInd8h').value),
            Number(this.formDissidio.get('benefInd6h').value),
            Number(this.formDissidio.get('reajuste').value),
            this.formDissidio.get('observacoes').value,
            this.formDissidio.get('vigenciainicio').value,
            this.formDissidio.get('vigenciafim').value,
            this.formDissidio.get('cnpj').value,
            this.formDissidio.get('conformeCargoFuncao').value,
            this.formDissidio.get('arquivo').value,
            this.formDissidio.get('atalho').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();

            this.dissidioEstado.dissidio.dataBase = this.formDissidio.get('dataBase').value;
            this.dissidioEstado.dissidio.dataUltima = this.formDissidio.get('dataUltima').value;
            this.dissidioEstado.dissidio.pisoSalarial8h = this.formDissidio.get('pisoSalarial8h').value;
            this.dissidioEstado.dissidio.pisoSalarial6h = this.formDissidio.get('pisoSalarial6h').value;
            this.dissidioEstado.dissidio.ticket8h = this.formDissidio.get('ticket8h').value;
            this.dissidioEstado.dissidio.ticket6h = this.formDissidio.get('ticket6h').value;
            this.dissidioEstado.dissidio.reajuste = this.formDissidio.get('reajuste').value;
            this.dissidioEstado.dissidio.benefInd8h = this.formDissidio.get('benefInd8h').value;
            this.dissidioEstado.dissidio.benefInd6h = this.formDissidio.get('benefInd6h').value;
            this.dissidioEstado.dissidio.observacoes = this.formDissidio.get('observacoes').value;
            this.dissidioEstado.dissidio.cnpj = this.formDissidio.get('cnpj').value;
            this.dissidioEstado.dissidio.vigenciaInicio = this.formDissidio.get('vigenciainicio').value;
            this.dissidioEstado.dissidio.vigenciaFinal = this.formDissidio.get('vigenciafim').value;
            this.dissidioEstado.dissidio.conformeCargoFuncao = this.formDissidio.get('conformeCargoFuncao').value;
            this.dissidioEstado.dissidio.atalho = this.formDissidio.get('atalho').value;
            this.dissidioEstado.dissidio.arquivo = this.formDissidio.get('arquivo').value;
         });
      }else{
         if(this.dissidioEstado.dissidio.arquivo){
            this.exibirUploadUpdate = true;
            this.arquivoUpdate = this.dissidioEstado.dissidio.arquivo;
         }
         else{
            this.exibirUploadUpdate = false;
            this.arquivoUpdate = undefined;
         }
      }

      this.editarDissidio = !this.editarDissidio;
   }

   upload(response, tipo: number) {
      if(tipo == 0){
         this.arquivo = response.arquivo;

         this.formCadastrar.get('arquivo').setValue(this.arquivo);
         this.exibirUpload = true;
         let btLink = document.getElementById('download-anexo');
         btLink.setAttribute(
            'href',
            `data:${this.arquivo.tipo};base64,${this.arquivo.base64}`
         );
      }else if(tipo == 1){
         this.arquivoUpdate = response.arquivo;

         this.formDissidio.get('arquivo').setValue(this.arquivoUpdate);
         this.exibirUploadUpdate = true;
      }
   }

   downloadAnexo(tipo: number) {
      let btLink;

      if(tipo == 0) btLink = document.getElementById('download-anexo');

      btLink.click();
   }

   excluirEdital(tipo: number) {
      if(tipo == 0){

         this.arquivo = new Arquivo();
         this.formCadastrar.get('arquivo').setValue('');
         this.exibirUpload = false;
         let btLink = document.getElementById('download-anexo');
         btLink.setAttribute('href', '');

      }else if(tipo == 1){

         this.arquivoUpdate = new Arquivo();
         this.formDissidio.get('arquivo').setValue(null);
         this.exibirUploadUpdate = false;

      }
   }
}
