import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Alertas } from '../../../../shared/class/alertas';
import { DiretorService } from './diretor.service';

@Component({
   selector: 'app-diretor',
   templateUrl: './diretor.component.html',
   styleUrls: ['./diretor.component.css'],
})
export class DiretorComponent implements OnInit {

   public atualizar: boolean;
   public edital: any;
   public parecerGerente: any;
   public dadosForm: any;
   public parecer: any;
   public idParecer: any;
   public empresaForm: any;
   public gerenteForm: any;
   public anexo1GC: any;
   public anexo2GC: any;
   public anexo1DC: any;
   public anexo2DC: any;
   public motivoForm: any;

   public parecerDiretorComercialForm: FormGroup;

   public exibirAnexo1: boolean;
   public exibirAnexo2: boolean;

   arquivo1: any;
   arquivo2: any;
   private idAnexoExcluido1: string;
   private idAnexoExcluido2: string;

   private constaAnexo1: boolean;
   private constaAnexo2: boolean;
   private excluiuAnexo1: boolean;
   private excluiuAnexo2: boolean;

   lista_motivos: any;
   lista_gerentes: any;
   lista_empresas: any;

   editalId: string;
   public selecionar: boolean = true;

   constructor(
      private fb: FormBuilder,
      private diretorService: DiretorService,
      private router: Router,
      private alertas: Alertas
   ) {}

   ngOnInit() {
      this.parecerDiretorComercialForm = this.fb.group({
         decisao: this.fb.control('', [Validators.required]),
         motivoComum: this.fb.control(''),
         observacao: this.fb.control(''),
         empresa: this.fb.control('', [Validators.required]),
         gerente: this.fb.control('', [Validators.required]),
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
      }else{
         this.router.navigate([""]);
         return;
      }

      this.obterEdital(this.editalId);
      this.obterParecerGerente(this.editalId);
      this.obterDadosForm();

      if (this.atualizar){
         this.obterParecer(this.editalId);
      }

      this.exibirAnexo1 = false;
      this.exibirAnexo2 = false;
   }

   processar() {
      if(this.parecerDiretorComercialForm.get('decisao').value == "NOGO" && this.parecerDiretorComercialForm.get('motivoComum').value == ""){
         this.alertas.erro('O Motivo deve ser preenchido!');
         return;
      }

      if (this.atualizar) {
         this.atualizarParecer();
      } else {
         this.cadastrarParecer();
      }
   }

   setParecer(ok: boolean){
      ok ? this.parecerDiretorComercialForm.get("motivoComum").setValidators([]) :
            this.parecerDiretorComercialForm.get("motivoComum").setValidators([Validators.required]);
   }

   obterEdital(id: string) {
      this.alertas.showLoading('Carregando Edital...');
      this.diretorService.obterEdital(id)
         .subscribe((res) => {
            this.edital = res;

            this.alertas.fecharModal();
         }
      );
   }

   obterParecerGerente(id: string) {
      this.alertas.showLoading('Carregando Parecer do Gerente...');
      this.diretorService.obterParecerGerente(id)
         .subscribe((res) => {
            this.parecerGerente = res;

            this.anexo1GC = this.parecerGerente.anexo1;
            this.anexo2GC = this.parecerGerente.anexo2;
            this.alertas.fecharModal();
         }
      );
   }

   obterDadosForm() {
      this.alertas.showLoading('Carregando Edital...');
      this.diretorService.obterDadosForm()
         .subscribe((res) => {
            this.empresaForm = res['empresas'];
            this.gerenteForm = res['gerente'];
            this.motivoForm = res['motivos'];
            this.alertas.fecharModal();
         }
      );
   }

   obterParecer(id: string) {
      this.alertas.showLoading('Obtendo o parecer...');

      this.diretorService.obterParecer(id).subscribe((resp) => {
         this.parecer = resp;

         this.idParecer = this.parecer.id;

         this.parecerDiretorComercialForm
            .get('decisao')
            .setValue(this.parecer.decisao);
         this.parecerDiretorComercialForm
            .get('motivoComum')
            .setValue(this.parecer.motivosComum != null ? this.parecer.motivosComum.id : "");
         this.parecerDiretorComercialForm
            .get('observacao')
            .setValue(this.parecer.observacao);
         this.parecerDiretorComercialForm
            .get('empresa')
            .setValue(this.parecer.empresa.id);
         this.parecerDiretorComercialForm
            .get('gerente')
            .setValue(this.parecer.gerente.id);

         this.arquivo1 = this.parecer.anexo1;
         this.arquivo2 = this.parecer.anexo2;
         this.parecerDiretorComercialForm.get('anexo1').setValue(this.arquivo1);
         this.parecerDiretorComercialForm.get('anexo2').setValue(this.arquivo2);

         this.alertas.fecharModal();
      });
   }

   downloadAnexo(index: number) {
      let btLink = document.getElementById('download-anexo');

      if (index == 0) {
         btLink.setAttribute(
            'href',
            `data:${this.edital.anexo.tipo};base64,${this.edital.anexo.base64}`
         );
         btLink.setAttribute('download', this.edital.anexo.nome);
      } else if (index == 1) {
         btLink.setAttribute(
            'href',
            `data:${this.anexo1GC.tipo};base64,${this.anexo1GC.base64}`
         );
         btLink.setAttribute('download', this.anexo1GC.nome);
      } else if (index == 2) {
         btLink.setAttribute(
            'href',
            `data:${this.anexo2GC.tipo};base64,${this.anexo2GC.base64}`
         );
         btLink.setAttribute('download', this.anexo2GC.nome);

      }else if (index == 3) {
         btLink.setAttribute(
            'href',
            `data:${this.arquivo1.tipo};base64,${this.arquivo1.base64}`
         );
         btLink.setAttribute('download', this.arquivo1.nome);
      }else if (index == 4) {
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

         if (this.atualizar)
            this.arquivo1.id = this.anexo1DC;

         this.parecerDiretorComercialForm.get('anexo1').setValue(this.arquivo1);
      }

      if (index == 2) {
         this.arquivo2 = response.arquivo;

         if (this.atualizar)
            this.arquivo2.id = this.anexo2DC;

         this.parecerDiretorComercialForm.get('anexo2').setValue(this.arquivo2);
      }
   }

   excluirAnexo(index: number): void {
      if (index == 1) {
         this.anexo1DC = this.arquivo1.id;
         this.arquivo1 = undefined;
         this.parecerDiretorComercialForm.get('anexo1').setValue(null);
      } else if (index == 2) {
         this.anexo2DC = this.arquivo2.id;
         this.arquivo2 = undefined;
         this.parecerDiretorComercialForm.get('anexo2').setValue(null);
      }
   }

   cadastrarParecer() {
      this.alertas.showLoading('Criando Parecer de Diretor Comercial');

      if(this.parecerDiretorComercialForm.get('decisao').value == 'GO')
         this.parecerDiretorComercialForm.get('motivoComum').setValue('');

      this.diretorService
         .cadastrarParecer(
            this.edital.id,
            this.parecerDiretorComercialForm.get('decisao').value,
            this.parecerDiretorComercialForm.get('empresa').value,
            this.parecerDiretorComercialForm.get('motivoComum').value,
            this.parecerDiretorComercialForm.get('gerente').value,
            this.parecerDiretorComercialForm.get('observacao').value,
            this.parecerDiretorComercialForm.get('anexo1').value,
            this.parecerDiretorComercialForm.get('anexo2').value,
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

   atualizarParecer() {
      this.alertas.showLoading('Atualizando Parecer de Gerente de Contas');

      if(this.parecerDiretorComercialForm.get('decisao').value == 'GO')
         this.parecerDiretorComercialForm.get('motivoComum').setValue("");

      this.diretorService
         .atualizarParecer(
            this.idParecer,
            this.edital.id,
            this.parecerDiretorComercialForm.get('decisao').value,
            this.parecerDiretorComercialForm.get('empresa').value,
            this.parecerDiretorComercialForm.get('motivoComum').value,
            this.parecerDiretorComercialForm.get('gerente').value,
            this.parecerDiretorComercialForm.get('observacao').value,
            this.parecerDiretorComercialForm.get('anexo1').value,
            this.parecerDiretorComercialForm.get('anexo2').value,
         )
         .subscribe(
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
