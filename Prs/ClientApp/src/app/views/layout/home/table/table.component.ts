import { Component, OnInit, Input } from '@angular/core';
import { HomeService } from '../home.service';
import { Router } from '@angular/router';
import { Alertas } from 'src/app/shared/class/alertas';
import { User } from '../../user';

@Component({
   selector: 'app-table',
   templateUrl: './table.component.html',
   styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit {
   constructor(private homeService: HomeService, private router: Router, private alertas: Alertas) {}

   @Input() editais: any;
   @Input() tipo: string;
   @Input() titulo: string;
   @Input() etapa: string;

   public nomeColuna: string = ''

   dataAtual: Date = new Date();
   public comentario: any;

   tabelaExpandida: boolean = false;

   private user: User = new User;

   ngOnInit(): void {
      this.user = this.homeService.getUser();
   }


   obterUltimocomentario(id){
      this.homeService.obterComentarios(id).subscribe(res => {
         this.comentario = res;
      })
   }

   obterComentarios(id){
      sessionStorage.setItem('listar-comentario', id)
      this.router.navigate(['/comentario-edital'])
   }

   changeIconExpand(){
      this.tabelaExpandida = !this.tabelaExpandida;
   }

   emitirParecerGerente(parecer: any){
      if(this.user.id != parecer.gerente.id && this.user.role.nome == "gerente"){
         this.alertas.erro("Você não é o gerente indicado neste edital!");
      }else{
         sessionStorage.setItem('cadastrar-parecer', parecer.id)
         this.router.navigate(['/parecer-gerente'])
      }
   }

   emitirParecerDiretor(parecer: any){
      if(this.user.id == parecer.diretor.id || this.user.role.nome == "licitacao" || this.user.role.nome == "administrador"){
         sessionStorage.setItem('cadastrar-parecer', parecer.id)
         this.router.navigate(['/parecer-diretor'])
      }else{
         this.alertas.erro("Você não é o diretor indicado neste edital!");
      }
   }

   emitirParecerLicitacao(parecer: any){
      sessionStorage.setItem('cadastrar-parecer', parecer.id)
      this.router.navigate(['/parecer-licitacao'])
   }

   emitirParecerLicitacaoFinalizar(parecer: any){
      sessionStorage.setItem('finalizar-parecer', parecer.id)
      this.router.navigate(['/parecer-licitacao'])
   }

   alterarEdital(parecer: any){
      if(this.user.role.nome == "licitacao" || this.user.role.nome == "administrador"){
         sessionStorage.setItem('restaurar', parecer.id);
         this.router.navigate(['/edital']);
      }else{
         this.alertas.erro("Somente a equipe de licitação pode restaurar um edital!");
      }
   }

   comentarioEdital(){
      this.router.navigate(['/comentario-edital'])
   }

   ordenarCrescente(valor){
         this.nomeColuna = valor;
         this.editais = this.editais
         .sort(function(a,b){
            switch(valor){
               case 'id': return  a.id > b.id ? 1 : a.id < b.id ? -1 : 0;
               case 'cliente': return  a.cliente.nome > b.cliente.nome ? 1 : a.cliente.nome < b.cliente.nome ? -1 : 0;
               case "dataAbertura":
                  let asplit = a.dataHoraDeAbertura.substring(0, 10).split('-');
                  let bsplit = b.dataHoraDeAbertura.substring(0, 10).split('-');
                  let anew = Date.parse(asplit[0]+"/"+asplit[1]+"/"+asplit[2]);
                  let bnew = Date.parse(bsplit[0]+"/"+bsplit[1]+"/"+bsplit[2]);
                  return anew - bnew;
               case "categoria": return a.categoria.nome > b.categoria.nome ? 1 : a.categoria.nome < b.categoria.nome ? -1 : 0;
               case "regiao": return a.regiao.nome > b.regiao.nome ? 1 : a.regiao.nome < b.regiao.nome ? -1 : 0;
               case "modalidade":
                  if(a.modalidade != null)
                     return a.modalidade.nome > b.modalidade.nome ? 1 : a.modalidade.nome < b.modalidade.nome ? -1 : 0;
                  else
                     return;
               case "portal": return a.portal.nome > b.portal.nome ? 1 : a.portal.nome < b.portal.nome ? -1 : 0;
               case "diretor": return a.diretor.nome > b.diretor.nome ? 1 : a.diretor.nome < b.diretor.nome ? -1 : 0;
               case "gerente": return a.gerente.nome > b.gerente.nome ? 1 : a.gerente.nome < b.gerente.nome ? -1 : 0;
               case "empresa":
                  if(a.empresa != null)
                     return a.empresa.nome > b.empresa.nome ? 1 : a.empresa.nome < b.empresa.nome ? -1 : 0;
                  else
                     return
               case "nossoValor":
                  if(a.nossoValor != null && b.nossoValor != null){
                     if((a.nossoValor.replace(',', ".").replace('.', ',') == null) && (b.nossoValor.replace(',', ".").replace('.', ',') == null)){
                        return 0 - 0;
                     }else if(a.nossoValor.replace(',', ".").replace('.', ',') == null){
                        return 0 - b.nossoValor.replace(',', ".").replace('.', ',');
                     }else if(b.nossoValor.replace(',', ".").replace('.', ',') == null){
                        return a.nossoValor.replace(',', ".").replace('.', ',') - 0;
                     }else{
                        return a.nossoValor.replace(',', ".").replace('.', ',').replace(',', ".").replace('.', ',') - b.nossoValor.replace(',', ".").replace('.', ',').replace(',', ".").replace('.', ',');
                     }
                  }else{
                     return;
                  }
            }
         })
   }

   ordenarDeCrescente(valor){
         this.nomeColuna = '';
         this.editais = this.editais
         .sort(function(a,b){
            switch(valor){
               case 'id': return  a.id < b.id ? 1 : a.id > b.id ? -1 : 0;
               case 'cliente': return  a.cliente.nome < b.cliente.nome ? 1 : a.cliente.nome > b.cliente.nome ? -1 : 0;
               case "dataAbertura":
                  let asplit = a.dataHoraDeAbertura.substring(0, 10).split('-');
                  let bsplit = b.dataHoraDeAbertura.substring(0, 10).split('-');
                  let anew = Date.parse(asplit[0]+"/"+asplit[1]+"/"+asplit[2]);
                  let bnew = Date.parse(bsplit[0]+"/"+bsplit[1]+"/"+bsplit[2]);
                  return bnew - anew;
               case "categoria": return a.categoria.nome < b.categoria.nome ? 1 : a.categoria.nome > b.categoria.nome ? -1 : 0;
               case "regiao": return a.regiao.nome < b.regiao.nome ? 1 : a.regiao.nome > b.regiao.nome ? -1 : 0;
               case "modalidade":
               if(a.modalidade != null)
                  return a.modalidade.nome < b.modalidade.nome ? 1 : a.modalidade.nome > b.modalidade.nome ? -1 : 0;
               else
                  return;
               case "portal": return a.portal.nome < b.portal.nome ? 1 : a.portal.nome > b.portal.nome ? -1 : 0;
               case "diretor": return a.diretor.nome < b.diretor.nome ? 1 : a.diretor.nome > b.diretor.nome ? -1 : 0;
               case "gerente": return a.gerente.nome < b.gerente.nome ? 1 : a.gerente.nome > b.gerente.nome ? -1 : 0;
               case "empresa":
                  if(a.empresa != null)
                     return a.empresa.nome < b.empresa.nome ? 1 : a.empresa.nome > b.empresa.nome ? -1 : 0;
                  else
                     return;
               case "nossoValor":
                  if(a.nossoValor != null && b.nossoValor != null){
                     if((a.nossoValor.replace(',', ".").replace('.', ',') == null) && (b.nossoValor.replace(',', ".").replace('.', ',') == null)){
                        return 0 - 0;
                     }else if(a.nossoValor.replace(',', ".").replace('.', ',') == null){
                        return 0 - b.nossoValor.replace(',', ".").replace('.', ',');
                     }else if(b.nossoValor.replace(',', ".").replace('.', ',') == null){
                        return a.nossoValor.replace(',', ".").replace('.', ',') - 0;
                     }else{
                        return a.nossoValor.replace(',', ".").replace('.', ',') - b.nossoValor.replace(',', ".").replace('.', ',');
                     }
                  }else{
                     return;
                  }
            }
         })
   }
}
