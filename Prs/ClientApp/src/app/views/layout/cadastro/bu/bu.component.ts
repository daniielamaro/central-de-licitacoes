import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alertas } from '../../../../shared/class/alertas';
import { BuService } from './bu.service';

@Component({
  selector: 'app-bu',
  templateUrl: './bu.component.html',
  styleUrls: ['./bu.component.css']
})
export class BuComponent implements OnInit {
   public buForm: FormGroup;
   public buId: number;
   public bus: any;

   constructor(
      private fb: FormBuilder,
      private buService: BuService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.buForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         ativo: this.fb.control('')
      });

      this.obterBu();
   }

   obterBu(){
      this.buService
         .obterBus()
         .subscribe((res) => {
            this.bus = res;
         });
   }

   cadastrarBu(){
      this.alertas.showLoading('Cadastrando Bu');
      this.buService
         .cadastrarBu(
            this.buForm.get('nome').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarBu(){
      var ativo: boolean;
      if(this.buForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Bu');
      this.buService
         .alterarBu(
            this.buId,
            this.buForm.get('nome').value,
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
      this.buId = null;
      this.buForm.get('nome').setValue('');
   }

   selecionarBu(bu: any){
      this.buId = bu.id
      this.buForm.get('nome').setValue(bu.nome),
      this.buForm.get('ativo').setValue(bu.ativo)
   }

}
