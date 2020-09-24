import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Alertas } from '../../../../shared/class/alertas';
import { LicitacaoService } from './licitacao.service';

@Component({
   selector: 'app-licitacao',
   templateUrl: './licitacao.component.html',
   styleUrls: ['./licitacao.component.css'],
})
export class LicitacaoComponent implements OnInit {
   public parecerLicitacaoForm: FormGroup;
   public editalId: string;
   public atualizar: boolean = false;
   public finalizar: boolean = false;

   public edital: any;
   public parecerGerente: any;
   public motivoComumGerente: any;
   public parecerDiretor: any;
   public dadosFormMotivo: any;
   public dadosFormVencedor: any;
   public dadosFormResponsavel: any;
   public arquivo1: any;
   public arquivo2: any;
   private idAnexo1: number;
   private idAnexo2: number;
   public anexo1: any;
   public anexo2: any;

   public parecer: any;
   public idParecer: number;

   constructor(
      private fb: FormBuilder,
      private licitacaoService: LicitacaoService,
      private router: Router,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.parecerLicitacaoForm = this.fb.group({
         resultado: this.fb.control('', [Validators.required]),
         nossoValor: this.fb.control(''),
         motivoPerda: this.fb.control(''),
         vencedor: this.fb.control(''),
         valorVencedor: this.fb.control(''),
         nossaClassificacao: this.fb.control(''),
         responsavel: this.fb.control(''),
         observacao: this.fb.control(''),
         anexo1: this.fb.control(null),
         anexo2: this.fb.control(null),
      });

      if ('cadastrar-parecer' in sessionStorage) {
         this.editalId = sessionStorage.getItem('cadastrar-parecer');
         sessionStorage.removeItem('cadastrar-parecer');
      } else if ('atualizar-parecer' in sessionStorage) {
         this.editalId = sessionStorage.getItem('atualizar-parecer');
         sessionStorage.removeItem('atualizar-parecer');
         this.atualizar = true;
      } else if ('finalizar-parecer' in sessionStorage) {
         this.editalId = sessionStorage.getItem('finalizar-parecer');
         sessionStorage.removeItem('finalizar-parecer');
         this.finalizar = true;
         this.verificarParecerLicitacao(this.editalId);
      } else {
         this.router.navigate([""]);
         return;
      }

      this.obterEdital(this.editalId);
      this.obterParecerGerente(this.editalId);
      this.obterParecerDiretor(this.editalId);
      this.obterDadosForm();

      if (this.atualizar){
         this.obterParecer(this.editalId);
      }
   }

   obterEdital(id: string) {
      this.alertas.showLoading('Carregando Edital...');
      this.licitacaoService.obterEdital(id)
         .subscribe((res) => {
            this.edital = res;

            this.alertas.fecharModal();
         }
      );
   }

   obterParecerGerente(id: string) {
      this.alertas.showLoading('Carregando Parecer do Gerente...');
      this.licitacaoService.obterParecerGerente(id)
         .subscribe((res) => {
            this.parecerGerente = res;

            this.alertas.fecharModal();
         }
      );
   }

   obterParecerDiretor(id: string) {
      this.alertas.showLoading('Carregando Parecer do Diretor...');
      this.licitacaoService.obterParecerDiretor(id)
         .subscribe((res) => {
            this.parecerDiretor = res;

            this.alertas.fecharModal();
         }
      );
   }

   obterDadosForm(){
      this.alertas.showLoading('Carregando Edital...');
      this.licitacaoService.obterDadosForm()
         .subscribe((res) => {
            this.dadosFormMotivo = res['motivosPerda']
            this.dadosFormVencedor = res['concorrentes']
            this.dadosFormResponsavel = res['gerentes']

            this.alertas.fecharModal();
         }
      );
   }

   verificarParecerLicitacao(id: string){
      this.licitacaoService.verificarParecerLicitacao(id)
         .subscribe(resp => {
            this.atualizar = resp;

            if(this.atualizar && !this.parecer)
               this.obterParecer(this.editalId);
         })
   }

   obterParecer(id: string) {
      this.alertas.showLoading('Obtendo o parecer...');

      this.licitacaoService.obterParecer(id).subscribe((resp) => {
         this.parecer = resp;

         this.idParecer = this.parecer.id;

         this.parecerLicitacaoForm
            .get('resultado')
            .setValue(this.parecer.resultado);
         this.parecerLicitacaoForm
            .get('nossoValor')
            .setValue(this.parecer.nossoValor);
         this.parecerLicitacaoForm
            .get('motivoPerda')
            .setValue(this.parecer.motivoPerda != null ? this.parecer.motivoPerda.id : null);
         this.parecerLicitacaoForm
            .get('vencedor')
            .setValue(this.parecer.vencedor != null ? this.parecer.vencedor.id : null);
         this.parecerLicitacaoForm
            .get('valorVencedor')
            .setValue(this.parecer.valorVencedor);
         this.parecerLicitacaoForm
            .get('nossaClassificacao')
            .setValue(this.parecer.nossaClassificacao);
         this.parecerLicitacaoForm
            .get('responsavel')
            .setValue(this.parecer.responsavel != null ? this.parecer.responsavel.id : null);
         this.parecerLicitacaoForm
            .get('observacao')
            .setValue(this.parecer.observacao);

         this.arquivo1 = this.parecer.anexo1;
         this.arquivo2 = this.parecer.anexo2;
         this.parecerLicitacaoForm.get('anexo1').setValue(this.arquivo1);
         this.parecerLicitacaoForm.get('anexo2').setValue(this.arquivo2);

         this.alertas.fecharModal();
      });
   }

   downloadAnexo(index: number) {
      let btLink = document.getElementById('download-anexo');

      if (index == 0) {
         btLink.setAttribute(
            'href',
            `data:${this.arquivo1.tipo};base64,${this.arquivo1.base64}`
         );
         btLink.setAttribute('download', this.arquivo1.nome);
      } else if (index == 1) {
         btLink.setAttribute(
            'href',
            `data:${this.arquivo2.tipo};base64,${this.arquivo2.base64}`
         );
         btLink.setAttribute('download', this.arquivo2.nome);
      }

      btLink.click();
   }

   upload(response, index: number) {

      if (index == 1) {
         this.arquivo1 = response.arquivo;

         if (this.atualizar) this.arquivo1.id = this.idAnexo1;

         this.parecerLicitacaoForm.get('anexo1').setValue(this.arquivo1);
      }

      if (index == 2) {
         this.arquivo2 = response.arquivo;

         if (this.atualizar) this.arquivo2.id = this.idAnexo2;

         this.parecerLicitacaoForm.get('anexo2').setValue(this.arquivo2);
      }
   }

   excluirAnexo(index: number): void {
      if (index == 1) {
         this.idAnexo1 = this.arquivo1.id;
         this.arquivo1 = undefined;
         this.parecerLicitacaoForm.get('anexo1').setValue(null);
      } else if (index == 2) {
         this.idAnexo2 = this.arquivo2.id;
         this.arquivo2 = undefined;
         this.parecerLicitacaoForm.get('anexo2').setValue(null);
      }
   }

   processar() {
      if(this.parecerLicitacaoForm.get('resultado').value == 'perdeu'){
         if(this.parecerLicitacaoForm.get('motivoPerda').value == ""){
            this.alertas.erro('O Motivo Perda deve ser preenchido!');
            return;
         }
         if(this.parecerLicitacaoForm.get('vencedor').value == ""){
            this.alertas.erro('O Vencedor deve ser preenchido!');
            return;
         }
         if(this.parecerLicitacaoForm.get('valorVencedor').value == ""){
            this.alertas.erro('O Valor Vencedor deve ser preenchido!');
            return;
         }
         if(this.parecerLicitacaoForm.get('nossaClassificacao').value == ""){
            this.alertas.erro('A Nossa Classificacao deve ser preenchido!');
            return;
         }
      }

      if (this.atualizar && !this.finalizar) {
         this.atualizarParecer();
      } else if(!this.atualizar && !this.finalizar){
         this.cadastrarParecer();
      }else{
         this.finalizarParecer();
      }
   }

   setParecer(ok: boolean, ganhouperdeu: boolean){
      if(!ok){
         this.parecerLicitacaoForm.get("motivoPerda").setValidators([Validators.required]);
         this.parecerLicitacaoForm.get("vencedor").setValidators([Validators.required]);
         this.parecerLicitacaoForm.get("valorVencedor").setValidators([Validators.required]);
         this.parecerLicitacaoForm.get("nossaClassificacao").setValidators([Validators.required]);
      }else{
         this.parecerLicitacaoForm.get("motivoPerda").setValidators([]);
         this.parecerLicitacaoForm.get("vencedor").setValidators([]);
         this.parecerLicitacaoForm.get("valorVencedor").setValidators([]);
         this.parecerLicitacaoForm.get("nossaClassificacao").setValidators([]);
      }

      if(!ganhouperdeu){
         this.parecerLicitacaoForm.get("nossoValor").setValidators([]);
         this.parecerLicitacaoForm.get("responsavel").setValidators([]);
      }else{
         this.parecerLicitacaoForm.get("nossoValor").setValidators([Validators.required]);
         this.parecerLicitacaoForm.get("responsavel").setValidators([Validators.required]);
      }
            
   }

   cadastrarParecer(){
      this.alertas.showLoading('Criando Parecer de Licitação');

      if(this.parecerLicitacaoForm.get('resultado').value != 'perdeu'){
         this.parecerLicitacaoForm.get('motivoPerda').setValue("");
         this.parecerLicitacaoForm.get('vencedor').setValue("");
         this.parecerLicitacaoForm.get('valorVencedor').setValue("");
         this.parecerLicitacaoForm.get('nossaClassificacao').setValue("");
      }

      this.licitacaoService
         .cadastrarParecer(
            this.edital.id,
            this.parecerLicitacaoForm.get('resultado').value,
            this.parecerLicitacaoForm.get('nossoValor').value,
            this.parecerLicitacaoForm.get('motivoPerda').value,
            this.parecerLicitacaoForm.get('vencedor').value,
            this.parecerLicitacaoForm.get('valorVencedor').value,
            this.parecerLicitacaoForm.get('nossaClassificacao').value,
            this.parecerLicitacaoForm.get('observacao').value,
            this.parecerLicitacaoForm.get('responsavel').value,
            this.parecerLicitacaoForm.get('anexo1').value,
            this.parecerLicitacaoForm.get('anexo2').value
         ).subscribe(
            () => {
               this.alertas.fecharModal();
               this.router.navigate(['/']);
            },
            (error) => {
               this.alertas.erro(error.message);
            }
         );
   }
   
   finalizarParecer(){
      this.alertas.showLoading('Finalizando Parecer de Licitação');

      if(this.parecerLicitacaoForm.get('resultado').value != 'perdeu'){
         this.parecerLicitacaoForm.get('motivoPerda').setValue("");
         this.parecerLicitacaoForm.get('vencedor').setValue("");
         this.parecerLicitacaoForm.get('valorVencedor').setValue("");
         this.parecerLicitacaoForm.get('nossaClassificacao').setValue("");
      }

      this.licitacaoService
         .finalizarParecer(
            this.edital.id,
            this.parecerLicitacaoForm.get('resultado').value,
            this.parecerLicitacaoForm.get('nossoValor').value,
            this.parecerLicitacaoForm.get('motivoPerda').value,
            this.parecerLicitacaoForm.get('vencedor').value,
            this.parecerLicitacaoForm.get('valorVencedor').value,
            this.parecerLicitacaoForm.get('nossaClassificacao').value,
            this.parecerLicitacaoForm.get('observacao').value,
            this.parecerLicitacaoForm.get('responsavel').value,
            this.parecerLicitacaoForm.get('anexo1').value,
            this.parecerLicitacaoForm.get('anexo2').value
         ).subscribe(
            () => {
               this.alertas.fecharModal();
               this.router.navigate(['/']);
            },
            (error) => {
               this.alertas.erro(error.message);
            }
         );
   }

   atualizarParecer(){
      this.alertas.showLoading('Atualizando Parecer de Licitação');

      if(this.parecerLicitacaoForm.get('resultado').value != 'perdeu'){
         this.parecerLicitacaoForm.get('motivoPerda').setValue("");
         this.parecerLicitacaoForm.get('vencedor').setValue("");
         this.parecerLicitacaoForm.get('valorVencedor').setValue("");
         this.parecerLicitacaoForm.get('nossaClassificacao').setValue("");
      }

      this.licitacaoService
         .atualizarParecer(
            this.idParecer,
            this.parecerLicitacaoForm.get('resultado').value,
            this.parecerLicitacaoForm.get('nossoValor').value,
            this.parecerLicitacaoForm.get('motivoPerda').value,
            this.parecerLicitacaoForm.get('vencedor').value,
            this.parecerLicitacaoForm.get('valorVencedor').value,
            this.parecerLicitacaoForm.get('nossaClassificacao').value,
            this.parecerLicitacaoForm.get('observacao').value,
            this.parecerLicitacaoForm.get('responsavel').value,
            this.parecerLicitacaoForm.get('anexo1').value,
            this.parecerLicitacaoForm.get('anexo2').value
         ).subscribe(
            () => {
               this.alertas.fecharModal();
               this.router.navigate(['/']);
            },
            (error) => {
               this.alertas.erro(error.message);
            }
         );
   }
}
