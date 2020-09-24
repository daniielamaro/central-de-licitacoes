import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alertas } from '../../../../shared/class/alertas';
import { ModalidadeService } from './modalidade.service';

@Component({
   selector: 'app-modalidade',
   templateUrl: './modalidade.component.html',
   styleUrls: ['./modalidade.component.css'],
})
export class ModalidadeComponent implements OnInit {
   public modalidadeForm: FormGroup;
   public modalidadeId: number;
   public modalidades: any;

   constructor(
      private fb: FormBuilder,
      private modalidadeService: ModalidadeService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.modalidadeForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         ativo: this.fb.control('')
      });

      this.obterModalidade();
   }

   obterModalidade(){
      this.modalidadeService
         .obterModalidades()
         .subscribe((res) => {
            this.modalidades = res;
         });
   }

   cadastrarModalidade(){
      this.alertas.showLoading('Cadastrando Modalidade');
      this.modalidadeService
         .cadastrarModalidade(
            this.modalidadeForm.get('nome').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarModalidade(){
      var ativo: boolean;
      if(this.modalidadeForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Modalidade');
      this.modalidadeService
         .alterarModalidade(
            this.modalidadeId,
            this.modalidadeForm.get('nome').value,
            ativo
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   limpar(){
      this.modalidadeId = null;
      this.modalidadeForm.get('nome').setValue('');
   }

   selecionarModalidade(modalidade: any){
      this.modalidadeId = modalidade.id
      this.modalidadeForm.get('nome').setValue(modalidade.nome),
      this.modalidadeForm.get('ativo').setValue(modalidade.ativo)
   }
}
