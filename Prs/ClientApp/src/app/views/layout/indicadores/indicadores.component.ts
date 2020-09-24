import { Component, OnInit } from '@angular/core';
import { IndicadoresService } from './indicadores.service';

@Component({
  selector: 'app-indicadores',
  templateUrl: './indicadores.component.html',
  styleUrls: ['./indicadores.component.css']
})
export class IndicadoresComponent implements OnInit {

  autenticado: boolean = false;

  constructor(private indicadoresService: IndicadoresService) { }

  ngOnInit(): void {
    this.indicadoresService.autenticateTokenUser()
      .subscribe(resp => {
        this.autenticado = Boolean(resp);
      })
  }

}
