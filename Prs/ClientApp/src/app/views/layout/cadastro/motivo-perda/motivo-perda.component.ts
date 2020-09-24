import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alertas } from '../../../../shared/class/alertas';
import { MotivoPerdaService } from './motivo-perda.service';

@Component({
   selector: 'app-motivo-perda',
   templateUrl: './motivo-perda.component.html',
   styleUrls: ['./motivo-perda.component.css'],
})
export class MotivoPerdaComponent implements OnInit {
   public motivoPerdaForm: FormGroup;
   public motivoPerdaId: number;
   public motivosPerda: any;

   constructor(
      private fb: FormBuilder,
      private motivoPerdaService: MotivoPerdaService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.motivoPerdaForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         ativo: this.fb.control('')
      });

      this.obterMotivoPerda();
   }

   obterMotivoPerda(){
      this.motivoPerdaService
         .obterMotivosPerda()
         .subscribe((res) => {
            this.motivosPerda = res;
         });
   }

   cadastrarMotivoPerda(){
      this.alertas.showLoading('Cadastrando Motivo da Perda');
      this.motivoPerdaService
         .cadastrarMotivoPerda(
            this.motivoPerdaForm.get('nome').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarMotivoPerda(){
      var ativo: boolean;
      if(this.motivoPerdaForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Motivo da Perda');
      this.motivoPerdaService
         .alterarMotivoPerda(
            this.motivoPerdaId,
            this.motivoPerdaForm.get('nome').value,
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
      this.motivoPerdaId = null;
      this.motivoPerdaForm.get('nome').setValue('');
   }

   selecionarMotivoPerda(motivo: any){
      this.motivoPerdaId = motivo.id
      this.motivoPerdaForm.get('nome').setValue(motivo.nome),
      this.motivoPerdaForm.get('ativo').setValue(motivo.ativo)
   }
}
