import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { GerenteService } from './gerente.service';
import { Arquivo } from '../../../../shared/upload/arquivo';
import { Alertas } from '../../../../shared/class/alertas';

@Component({
   selector: 'app-gerente',
   templateUrl: './gerente.component.html',
   styleUrls: ['./gerente.component.css'],
})
export class GerenteComponent implements OnInit {
   dadosForm: any;

   private idParecer: number;
   public edital: any;
   private parecer: any;
   private editalId: string;
   public arquivo1: Arquivo;
   public arquivo2: Arquivo;

   private idAnexo1: number;
   private idAnexo2: number;

   public parecerGerenteContasForm: FormGroup;

   public atualizar: boolean = false;

   constructor(
      private fb: FormBuilder,
      private router: Router,
      private gerenteService: GerenteService,
      private alertas: Alertas
   ) {}

   ngOnInit() {
      this.parecerGerenteContasForm = this.fb.group({
         parecer: this.fb.control('', [Validators.required]),
         motivo: this.fb.control(''),
         natureza: this.fb.control('', [Validators.required]),
         codCrm: this.fb.control(''),
         observacao: this.fb.control(''),
         empresa: this.fb.control('', [Validators.required]),
         preVenda: this.fb.control(''),
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
      this.obterDadosForm();

      if (this.atualizar) this.obterParecer(this.editalId);
   }

   obterEdital(id: string) {
      this.alertas.showLoading('Carregando Edital...');
      this.gerenteService.obterEdital(id).subscribe((resp) => {
         this.edital = resp;



         this.alertas.fecharModal();
      });
   }

   obterDadosForm() {
      this.gerenteService.obterDadosForm().subscribe((resp) => {
         this.dadosForm = resp;
      });
   }

   obterParecer(id: string) {
      this.alertas.showLoading('Obtendo o parecer...');

      this.gerenteService.obterParecer(id).subscribe((resp) => {
         this.parecer = resp;

         this.idParecer = this.parecer.id;

         this.parecerGerenteContasForm
            .get('parecer')
            .setValue(this.parecer.parecer);
         if (this.parecer.motivoComum)
            this.parecerGerenteContasForm
               .get('motivo')
               .setValue(this.parecer.motivoComum.id);
         this.parecerGerenteContasForm
            .get('natureza')
            .setValue(this.parecer.natureza);
         this.parecerGerenteContasForm
            .get('observacao')
            .setValue(this.parecer.observacao);
         if (this.parecer.empresa)
            this.parecerGerenteContasForm
               .get('empresa')
               .setValue(this.parecer.empresa.id);
         if (this.parecer.preVenda)
            this.parecerGerenteContasForm
               .get('preVenda')
               .setValue(this.parecer.preVenda.id);
         this.parecerGerenteContasForm.get('codCrm').setValue(this.parecer.crm);

         this.arquivo1 = this.parecer.anexo1;
         this.arquivo2 = this.parecer.anexo2;
         this.parecerGerenteContasForm.get('anexo1').setValue(this.arquivo1);
         this.parecerGerenteContasForm.get('anexo2').setValue(this.arquivo2);

         this.alertas.fecharModal();
      });
   }

   cadastrarParecer() {
      this.alertas.showLoading('Criando Parecer de Gerente de Contas');

      this.gerenteService
         .cadastrarParecer(
            this.parecerGerenteContasForm.get('parecer').value,
            this.parecerGerenteContasForm.get('motivo').value,
            this.parecerGerenteContasForm.get('natureza').value,
            this.parecerGerenteContasForm.get('observacao').value,
            this.parecerGerenteContasForm.get('empresa').value,
            this.parecerGerenteContasForm.get('preVenda').value,
            this.edital.id,
            this.parecerGerenteContasForm.get('codCrm').value,
            this.parecerGerenteContasForm.get('anexo1').value,
            this.parecerGerenteContasForm.get('anexo2').value
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

   setParecer(ok: boolean){
      ok ? this.parecerGerenteContasForm.get("motivo").setValidators([]) :
            this.parecerGerenteContasForm.get("motivo").setValidators([Validators.required]);
   }

   setNatureza(ok: boolean){
      ok ? this.parecerGerenteContasForm.get("codCrm").setValidators([]) :
            this.parecerGerenteContasForm.get("codCrm").setValidators([Validators.required]);
   }

   atualizarParecer() {
      this.alertas.showLoading('Atualizando Parecer de Gerente de Contas');

      if(this.parecerGerenteContasForm.get('parecer').value == 'Favoravel')
         this.parecerGerenteContasForm.get('motivo').setValue("");

      if(this.parecerGerenteContasForm.get('natureza').value != 'Trabalho')
         this.parecerGerenteContasForm.get("codCrm").setValue(null);

      this.gerenteService
         .atualizarParecer(
            this.idParecer,
            this.parecerGerenteContasForm.get('parecer').value,
            this.parecerGerenteContasForm.get('motivo').value,
            this.parecerGerenteContasForm.get('natureza').value,
            this.parecerGerenteContasForm.get('observacao').value,
            this.parecerGerenteContasForm.get('empresa').value,
            this.parecerGerenteContasForm.get('preVenda').value,
            this.edital.id,
            this.parecerGerenteContasForm.get('codCrm').value,
            this.parecerGerenteContasForm.get('anexo1').value,
            this.parecerGerenteContasForm.get('anexo2').value
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

   processar() {
      if(this.parecerGerenteContasForm.get('parecer').value == "Não favoravel" && this.parecerGerenteContasForm.get('motivo').value == ""){
         this.alertas.erro('O Motivo deve ser preenchido!');
         return;
      }

      if(this.parecerGerenteContasForm.get('natureza').value == "Trabalho" && this.parecerGerenteContasForm.get('codCrm').value == ""){
         this.alertas.erro('O Código CRM deve ser preenchido!');
         return;
      }

      if (this.atualizar) {
         this.atualizarParecer();
      } else {
         this.cadastrarParecer();
      }
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
            `data:${this.arquivo1.tipo};base64,${this.arquivo1.base64}`
         );
         btLink.setAttribute('download', this.arquivo1.nome);
      } else if (index == 2) {
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

         this.parecerGerenteContasForm.get('anexo1').setValue(this.arquivo1);
      }

      if (index == 2) {
         this.arquivo2 = response.arquivo;

         if (this.atualizar) this.arquivo2.id = this.idAnexo2;

         this.parecerGerenteContasForm.get('anexo2').setValue(this.arquivo2);
      }
   }

   excluirAnexo(index: number): void {
      if (index == 1) {
         this.idAnexo1 = this.arquivo1.id;
         this.arquivo1 = undefined;
         this.parecerGerenteContasForm.get('anexo1').setValue(null);
      } else if (index == 2) {
         this.idAnexo2 = this.arquivo2.id;
         this.arquivo2 = undefined;
         this.parecerGerenteContasForm.get('anexo2').setValue(null);
      }
   }
}
