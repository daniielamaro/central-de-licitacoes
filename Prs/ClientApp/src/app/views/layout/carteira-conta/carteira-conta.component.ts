import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarteiraContaService } from './carteira-conta.service';
import { Router } from '@angular/router';
import { Alertas } from '../../../shared/class/alertas';
import Swal from 'sweetalert2';

@Component({
   selector: 'app-carteira-conta',
   templateUrl: './carteira-conta.component.html',
   styleUrls: ['./carteira-conta.component.css'],
})

export class CarteiraContaComponent implements OnInit {
   public dados: any;
   public dadosDb: any;
   public dadosForm: any;
   public dadosFiltrados = new Array();
   public idGerente: string

   public carteiraForm: FormGroup;

   constructor(
      private carteiraService: CarteiraContaService,
      private router: Router,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.carteiraForm = new FormGroup({
         gerente: new FormControl('0', Validators.required),
         cliente: new FormControl('', Validators.required),
      });

      this.obterDadosTabela();
      this.obterDadosForm();
   }

   obterDadosTabela() {
      this.carteiraService.listarCarteira().subscribe((res) => {
         this.dadosDb = res;
         this.atualizarTabelas(this.dadosDb);
         this.carteiraForm.get('gerente').setValue('0');
         this.carteiraForm.get('cliente').setValue('');
      });
   }

   atualizarTabelas(dados: any) {
      this.dados = dados;
      this.idGerente = '';
   }

   obterDadosForm() {
      this.carteiraService.obterDadosForm().subscribe((res) => {
         this.dadosForm = res;
      });
   }

   registrar() {
      this.carteiraService
         .insertCarteira(
            this.carteiraForm.get('gerente').value,
            this.carteiraForm.get('cliente').value
         )
         .subscribe(() => {
            this.obterDadosTabela();
         });
   }

   deletar(id: string) {
      this.carteiraService.deleteCarteira(id).subscribe((res) => {
         this.obterDadosTabela();
      });
   }

   cadastrar(rota: string): void {
      this.router.navigate([rota]);
   }

   limparFiltros() {
      this.dados = this.dadosDb;
      this.dadosFiltrados = new Array();

      this.carteiraForm.get('gerente').setValue('0');
      this.carteiraForm.get('cliente').setValue('');
   }

   filtrar() {
      let gerente = this.carteiraForm.get('gerente').value;
      let cliente = this.carteiraForm.get('cliente').value;

      this.limparFiltros();

      if (gerente != '0' && cliente != '') {
         for (let i = 0; i < this.dados.length; i++) {
            if (this.dados[i].gerente.id == gerente) {
               for (let j = 0; j < this.dados[i].carteiras.length; j++) {
                  if (this.dados[i].carteiras[j].cliente.id == cliente) {
                     let gerenteObj = this.dados[i].gerente;
                     let carteiraObj = this.dados[i].carteiras[j];
                     let arraytemp = new Array();
                     arraytemp.push(gerenteObj);
                     arraytemp.push([carteiraObj]);
                     this.dadosFiltrados.push(arraytemp);
                  }
               }
            }
         }
         this.atualizarTabelas(this.dadosFiltrados);
         return;
      }

      if (gerente != '0') {
         for (let i = 0; i < this.dados.length; i++) {
            if (this.dados[i].gerente.id == gerente) {
               this.dadosFiltrados.push(this.dados[i]);
            }
         }
         this.atualizarTabelas(this.dadosFiltrados);
         return;
      }

      if (cliente != '') {
         for (let i = 0; i < this.dados.length; i++) {
            for (let j = 0; j < this.dados[i].carteiras.length; j++)
               if (this.dados[i].carteiras[j].cliente.id == cliente) {
                  this.dadosFiltrados.push(this.dados[i]);
               }
         }
         this.atualizarTabelas(this.dadosFiltrados);
         return;
      }
   }

   pegarId(valor){
      this.idGerente = valor;
   }

   excluirGerente(){
      Swal.fire({
         title: '<strong>Confirmação</strong>',
         icon: 'question',
         html:
           'Deseja deletar toda a carteira de contas ou apenas transferir para "Sem Gerente Definido" ?',
         showCloseButton: true,
         showCancelButton: true,
         focusConfirm: false,
         confirmButtonColor: '#fd7e14',
         cancelButtonColor: '#17a2b8',
         cancelButtonText:'Transferir',
         confirmButtonText: 'Deletar'
      }).then((result) => {
         if (result.value) {
            this.carteiraService.deleteGrenteCarteira(this.idGerente).subscribe((res) => {
               this.alertas.sucesso("Gerente deletado!")
               this.obterDadosTabela();
           })
         } else if (
           result.dismiss === Swal.DismissReason.cancel
         ) {
            console.log('aquifora')
            this.carteiraService.deleteGrenteComCarteira(this.idGerente).subscribe((res) => {
               console.log('aquidentro')
               this.alertas.sucesso("Carteira tranferida!")
               this.obterDadosTabela();
           })
         }
       })
   }
}
