import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HistoricoService } from './historico.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {

  editalId: string;
  historicos: any;

  constructor(
    private router: Router,
    private historicoService: HistoricoService) { }

  ngOnInit(): void {
    if ('edital-id' in sessionStorage) {
      this.editalId = sessionStorage.getItem('edital-id');
      sessionStorage.removeItem('edital-id');
    } else {
        this.router.navigate(['']);
        return;
    }

    this.obterHistoricoByEditalId(this.editalId);
  }

  obterHistoricoByEditalId(id: string){
    this.historicoService.GetHistoricoByEditalId(id)
      .subscribe(resp => {
        this.historicos = resp;
      })
  }
}
