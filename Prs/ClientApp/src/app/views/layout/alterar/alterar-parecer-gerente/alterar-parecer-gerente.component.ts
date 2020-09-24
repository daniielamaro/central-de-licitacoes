import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlterarService } from '../alterar.service';
import { Alertas } from 'src/app/shared/class/alertas';
import Swal from 'sweetalert2';

@Component({
   selector: 'app-alterar-parecer-gerente',
   template: '',
})
export class AlterarParecerGerenteComponent implements OnInit {
   constructor(
      private router: Router,
      private alterarservice: AlterarService,
      private alertas: Alertas
   ) {}

   ngOnInit() {
      Swal.fire({
         title: 'Digite o ID do edital',
         input: 'number',
         inputAttributes: {
            autocapitalize: 'off',
         },
         showCancelButton: true,
         confirmButtonText: 'Procurar',
         showLoaderOnConfirm: true,
         preConfirm: (id) => {
            return this.alterarservice
               .verificarEdital(id)
               .then((response) => {
                  return response.json().then((e) => {
                     if (!e) {
                        throw new Error(
                           'Não encontrei o edital com o ID: ' + id
                        );
                     }

                     return this.alterarservice
                        .verificarParecerGerente(id)
                        .then((response) => {
                           return response.json().then((p) => {
                              if (!p) {
                                 throw new Error(
                                    'Não encontrei o parecer para o edital com o ID: ' +
                                       id
                                 );
                              }

                              return id;
                           });
                        });
                  });
               })
               .catch((error) => {
                  Swal.showValidationMessage(error);
               });
         },
         allowOutsideClick: () => false,
      }).then((result) => {
         if (result.value) {
            sessionStorage.setItem('atualizar-parecer', result.value);
            this.router.navigate(['/parecer-gerente']);
         }

         if (result.dismiss) {
            this.router.navigate(['/']);
         }
      });
   }
}
