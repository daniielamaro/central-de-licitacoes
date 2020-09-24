import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Alertas } from '../../../../shared/class/alertas';
import { CategoriaService } from './categoria.service';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {
   public categoriaForm: FormGroup;
   public categoriaId: number;
   public categorias: any;
   public dadosForm: any;

   constructor(
      private fb: FormBuilder,
      private categoriaService: CategoriaService,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
      this.categoriaForm = this.fb.group({
         nome: this.fb.control('', [Validators.required]),
         bu: this.fb.control(''),
         ativo: this.fb.control('')
      });

      this.obterCategorias();
      this.obterDadosForm();
   }

   obterCategorias(){
      this.categoriaService
         .obterCategorias()
         .subscribe((res) => {
            this.categorias = res;
            console.log(this.categorias)
         });
   }

   obterDadosForm(){
      this.categoriaService
         .obterDadosForm()
         .subscribe((res) => {
            this.dadosForm = res;
         });
   }

   cadastrarCategoria(){
      this.alertas.showLoading('Cadastrando Categoria');
      this.categoriaService
         .cadastrarCategoria(
            this.categoriaForm.get('nome').value,
            this.categoriaForm.get('bu').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            location.reload();
         }, (error) => {
            this.alertas.erro(error.message);
         })
   }

   alterarCategoria(){
      var ativo: boolean;
      if(this.categoriaForm.get('ativo').value == 'true'){
         ativo = true;
      }else{
         ativo = false;
      }

      this.alertas.showLoading('Alterando Categoria');
      this.categoriaService
         .alterarCategoria(
            this.categoriaId,
            this.categoriaForm.get('nome').value,
            this.categoriaForm.get('bu').value,
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
      this.categoriaId = null;
      this.categoriaForm.get('nome').setValue('');
      this.categoriaForm.get('bu').setValue('');
   }

   selecionarCategoria(categoria: any){
      this.categoriaId = categoria.id
      this.categoriaForm.get('nome').setValue(categoria.nome)
      if(categoria.bu){
         this.categoriaForm.get('bu').setValue(categoria.bu.id)
      }else{
         this.categoriaForm.get('bu').setValue("")
      }
      this.categoriaForm.get('ativo').setValue(categoria.ativo)
   }
}
