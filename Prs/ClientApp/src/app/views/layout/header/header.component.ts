import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { Router } from '@angular/router';
import { domainToUnicode } from 'url';
import { UrlService } from '../../../shared/class/url-service';

@Component({
   selector: 'app-header',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
   nomeUser: string = '';
   user: User;
   mostrarMenu: boolean = false;

  constructor(private router: Router, private urlService: UrlService) {
    this.user = this.urlService.getUser();

      // document.querySelector("body").addEventListener('mouseover', (event) => {
      //    if(event["toElement"].id == 'botaoMenuUsuario'){
      //       document.querySelector('.menuUsuario').classList.toggle('isOpen')
      //    }
      // })

   }

   ngOnInit(): void {
     this.nomeUser = this.user.nome;
   }

   menuLogout() {
      this.mostrarMenu = !this.mostrarMenu;
   }

   logout() {
      localStorage.removeItem('user');
      sessionStorage.removeItem('user');

      this.router.navigate(['/login']);
   }
}
