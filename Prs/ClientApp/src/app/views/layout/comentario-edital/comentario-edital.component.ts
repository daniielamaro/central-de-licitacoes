import { Component, OnInit } from '@angular/core';
import { ComentarioEditalService } from '../comentario-edital/comentario-edital.service';
import { Router } from '@angular/router';
import { Alertas } from '../../../shared/class/alertas';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UrlService } from '../../../shared/class/url-service';

@Component({
   selector: 'app-comentario-edital',
   templateUrl: './comentario-edital.component.html',
   styleUrls: ['./comentario-edital.component.css'],
})
export class ComentarioEditalComponent implements OnInit {
   public comentarioForm: FormGroup;
   public comentarioId;
   public id;
   public dadosComentarios: any;
   public user: any

   constructor(
      private fb: FormBuilder,
      private router: Router,
      private comentarioEditalService: ComentarioEditalService,
      private urlService: UrlService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.user = this.urlService.getUser();

      this.comentarioForm = this.fb.group({
         mensagem: this.fb.control('', [Validators.required]),
         ativo: this.fb.control('')
      });

      if ('listar-comentario' in sessionStorage) {
         this.id = sessionStorage.getItem('listar-comentario');
         sessionStorage.removeItem('listar-comentario');
      } else {
         this.router.navigate(['']);
         return;
      }

      this.obterComentarios(this.id);
   }

   obterComentarios(id) {
      this.comentarioEditalService.obterComentarios(id).subscribe(res => {
         this.dadosComentarios = res
      });
   }

   cadastrarComentario(){
      this.alertas.showLoading('Inserindo Comentario');
      this.comentarioEditalService
         .cadastrarComentario(
            this.comentarioForm.get('mensagem').value,
            this.user.id,
            this.id
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarComentario(){
      var ativo: boolean;
      if(this.comentarioForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Comentario');
      this.comentarioEditalService
         .alterarComentario(
            this.comentarioId,
            this.comentarioForm.get('mensagem').value,
            this.user.id,
            this.id,
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
      this.comentarioId = null;
      this.comentarioForm.get('mensagem').setValue('');
   }

   selecionarComentario(comentario: any){
      this.comentarioId = comentario.id
      this.comentarioForm.get('mensagem').setValue(comentario.mensagem),
      this.comentarioForm.get('ativo').setValue(comentario.ativo)
   }
}
