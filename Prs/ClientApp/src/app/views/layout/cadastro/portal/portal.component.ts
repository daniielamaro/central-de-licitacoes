import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alertas } from '../../../../shared/class/alertas';
import { PortalService } from './portal.service';

@Component({
  selector: 'app-portal',
  templateUrl: './portal.component.html',
  styleUrls: ['./portal.component.css']
})
export class PortalComponent implements OnInit {
   public portalForm: FormGroup;
   public portalId: number;
   public portais: any;

   constructor(
      private fb: FormBuilder,
      private portalService: PortalService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.portalForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         ativo: this.fb.control('')
      });

      this.obterPortais();
   }

   obterPortais(){
      this.portalService
         .obterPortais()
         .subscribe((res) => {
            this.portais = res;
         });
   }

   cadastrarPortal(){
      this.alertas.showLoading('Cadastrando Portal');
      this.portalService
         .cadastrarPortal(
            this.portalForm.get('nome').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarPortal(){
      var ativo: boolean;
      if(this.portalForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Portal');
      this.portalService
         .alterarPortal(
            this.portalId,
            this.portalForm.get('nome').value,
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
      this.portalId = null;
      this.portalForm.get('nome').setValue('');
   }

   selecionarPortal(portal: any){
      this.portalId = portal.id
      this.portalForm.get('nome').setValue(portal.nome),
      this.portalForm.get('ativo').setValue(portal.ativo)
   }
}
