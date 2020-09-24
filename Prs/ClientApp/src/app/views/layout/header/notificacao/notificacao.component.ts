import { Component, OnInit, Input } from '@angular/core';
import { NotificacaoService } from './notificacao.service';
import { UrlService } from 'src/app/shared/class/url-service';
import { User } from '../../user';
import { Router } from '@angular/router';
import { Alertas } from 'src/app/shared/class/alertas';

@Component({
   selector: 'app-notificacao',
   templateUrl: './notificacao.component.html',
   styleUrls: ['./notificacao.component.css'],
})
export class NotificacaoComponent implements OnInit {

   public exibir: boolean = false
   public quantNotif: Number;
   public pendencias: any;
   public pendenciaDiretor: number;
   public pendenciaGerente: number;
   @Input() user: User = new User();

   constructor(
      private notificacaoService: NotificacaoService,
      private router: Router,
      private alertas: Alertas
   ) {}

   ngOnInit(): void {
     this.getDados();
   }

   getDados() {
      this.notificacaoService.getNotificacao(this.user.id).subscribe((resp) => {
         this.pendencias = resp;
         this.pendenciaGerente = this.pendencias.pendingGerente;
         this.pendenciaDiretor = this.pendencias.pendingDiretor;

         this.quantNotif =
            this.pendencias.pendingGerente.length +
            this.pendencias.pendingDiretor.length;
      }, error => {
         if(error.status == 401 || error.status == 403){
            localStorage.removeItem('user');
            sessionStorage.removeItem('user')
            this.router.navigate(['/login']);
            return;
         }

         this.alertas.erro(error.message);
         return;
      });
   }

   emitirParecerGerente(id: string){
      sessionStorage.setItem('cadastrar-parecer', id)

      if(this.router.url == "/parecer-gerente")
         location.reload();
      else
         this.router.navigate(['/parecer-gerente'])
   }
}
