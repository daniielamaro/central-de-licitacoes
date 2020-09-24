import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { Alertas } from '../../../shared/class/alertas';
import { ConsultarHistoricoService } from './consultar-historico.service';

@Component({
  selector: 'app-consultar-historico',
  template: ''
})

export class ConsultarHistoricoComponent implements OnInit {

  constructor(private router: Router, private consultarService: ConsultarHistoricoService, private alertas: Alertas) { }

  ngOnInit() {
    Swal.fire({
      title: 'Digite o ID do edital',
      input: 'number',
      inputAttributes: {
        autocapitalize: 'off'
      },
      showCancelButton: true,
      confirmButtonText: 'Procurar',
      showLoaderOnConfirm: true,
      preConfirm: (id) => {
        return this.consultarService.verificarEdital(id)
          .then(response => {

          return response.json().then(e => {
            if(!e){
              throw new Error("Não encontrei o edital com o ID: " + id);
            }

            return id;
          })
        })
        .catch(error => {
          Swal.showValidationMessage(
            error
          )
        })
      },
      allowOutsideClick: () => false
    }).then((result) => {
      if (result.value) {
        sessionStorage.setItem('edital-id', result.value);
        this.router.navigate(['/historico']);
      }

      if(result.dismiss){
        this.router.navigate(['/']);
      }
    })
  }

}
