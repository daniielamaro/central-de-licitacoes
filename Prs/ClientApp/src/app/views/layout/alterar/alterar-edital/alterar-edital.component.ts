import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { AlterarService } from '../alterar.service';
import { Router } from '@angular/router';
import { Alertas } from '../../../../shared/class/alertas';


@Component({
  selector: 'app-alterar-edital',
  template: ''
})
export class AlterarEditalComponent implements OnInit {

  constructor(private router: Router, private alterarservice: AlterarService, private alertas: Alertas) { }

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
        return this.alterarservice.verificarEdital(id)
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
        this.router.navigate(['/edital']);
      }

      if(result.dismiss){
        this.router.navigate(['/']);
      }
    })
  }

}
