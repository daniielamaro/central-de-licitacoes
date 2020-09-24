import { Component, OnInit } from '@angular/core';
import { PreVendaService } from './pre-venda.service';
import { Alertas } from '../../../../shared/class/alertas';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
   selector: 'app-pre-venda',
   templateUrl: './pre-venda.component.html',
   styleUrls: ['./pre-venda.component.css'],
})
export class PreVendaComponent implements OnInit {
   public preVendaForm: FormGroup;
   public preVendaId: number;
   public preVendas: any;
   public dadosForm: any;
   public verifyUsuario: any;
   public verifyResultado: boolean;

   constructor(
      private fb: FormBuilder,
      private preVendaService: PreVendaService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.preVendaForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         ativo: this.fb.control(''),
      });

      this.obterPreVenda();
      this.obterDadosForm();
   }

   obterPreVenda() {
      this.preVendaService.obterPreVendas().subscribe((res) => {
         this.preVendas = res;
      });
   }

   obterDadosForm() {
      this.preVendaService.obterDadosPreVenda().subscribe((res) => {
         this.dadosForm = res;
      });
   }

   cadastrarPreVenda() {
      this.alertas.showLoading('Cadastrando Pré Venda');
      this.preVendaService
         .verifyPreVenda(this.preVendaForm.get('nome').value)
         .subscribe((res) => {
            this.verifyUsuario = res;
            if (this.verifyUsuario == false) {
               this.verifyResultado = false;
            } else {
               this.verifyResultado = true;
            }
         });

      setTimeout(() => {
         if (this.verifyResultado) {
            this.alertas.fecharModal();
            this.alertas.warning('Usuario já esta cadastrado em Pré Venda.');
         } else {
            this.preVendaService
               .cadastrarPreVenda(this.preVendaForm.get('nome').value)
               .subscribe(
                  () => {
                     this.alertas.fecharModal();
                     location.reload();
                  },
                  (error) => {
                     this.alertas.erro(error.message);
                  }
               );
         }
      }, 1000);
   }

   alterarPreVenda() {
      var ativo: boolean;
      if (this.preVendaForm.get('ativo').value == 'true') {
         ativo = true;
      } else {
         ativo = false;
      }

      this.alertas.showLoading('Alterando Pré Venda');
      this.preVendaService
         .alterarPreVenda(
            this.preVendaId,
            this.preVendaForm.get('nome').value,
            ativo
         )
         .subscribe(
            () => {
               this.alertas.fecharModal();
               location.reload();
            },
            (error) => {
               this.alertas.erro(error.message);
            }
         );
   }

   limpar() {
      this.preVendaId = null;
      this.preVendaForm.get('nome').setValue('');
   }

   isCherries(x) {
      return x.id == 140;
   }

   selecionarPreVenda(preVenda: any) {
      this.preVendaId = null;
      this.preVendaForm.get('nome').setValue('');
      this.preVendaForm.get('ativo').setValue('');

      this.dadosForm.forEach((element) => {
         if (preVenda.usuario != null)
            if (element.id == preVenda.usuario.id) {
               this.preVendaId = preVenda.id;
               this.preVendaForm.get('nome').setValue(preVenda.usuario.id);
               this.preVendaForm.get('ativo').setValue(preVenda.ativo);
            }
      });

      if (!this.preVendaId) {
         this.alertas.erro("Esse registro de Pré Venda não pode ser alterado, pois o usuário foi desativado ou não existe na base de dados.");
      }
   }
}
