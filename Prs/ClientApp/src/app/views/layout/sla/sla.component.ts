import { Component, OnInit } from '@angular/core';
import { SlaService } from './sla.service'

@Component({
  selector: 'app-sla',
  templateUrl: './sla.component.html',
  styleUrls: ['./sla.component.css']
})
export class SlaComponent implements OnInit {

  constructor(private slaService: SlaService) { }

  dataAtual: Date = new Date();

  tmc: string = "";
  tmpg: string = "";
  tmpd: string = "";
  tmcOk: boolean = false;
  tmpgOk: boolean = false;
  tmpdOk: boolean = false;
  tempoTmc: any;
  tempoTmpg: any;
  tempoTmpd: any;
  slaGerentes: any;
  slaDiretores: any;

  ngOnInit(): void {
    this.getTMC();
    this.getTMPG();
    this.getTMPD();
    this.getSlaGerentes();
    this.getSlaDiretores();
  }

  getTMC(){
    this.slaService.getTMC()
      .subscribe(resp => {

        this.tempoTmc = resp;
        this.tmcOk = this.tempoTmc.ok;

        if(this.tempoTmc.dias > 0)
          this.tmc += this.tempoTmc.dias > 1 ? this.tempoTmc.dias + " dias" : this.tempoTmc.dias + " dia";

        else if(this.tempoTmc.horas > 0)
          this.tmc += this.tempoTmc.horas > 1 ? this.tempoTmc.horas + " horas" : this.tempoTmc.horas + " hora";

        else if(this.tempoTmc.minutos > 0)
          this.tmc += this.tempoTmc.minutos > 1 ? this.tempoTmc.minutos + " minutos" : this.tempoTmc.minutos + " minutos";

      });
  }

  getTMPG(){
    this.slaService.getTMPG()
      .subscribe(resp => {

        this.tempoTmpg = resp;
        this.tmpgOk = this.tempoTmpg.ok;

        if(this.tempoTmpg.dias > 0)
          this.tmpg += this.tempoTmpg.dias > 1 ? this.tempoTmpg.dias + " dias" : this.tempoTmpg.dias + " dia";

        else if(this.tempoTmpg.horas > 0)
          this.tmpg += this.tempoTmpg.horas > 1 ? this.tempoTmpg.horas + " horas" : this.tempoTmpg.horas + " hora";

        else if(this.tempoTmpg.minutos > 0)
          this.tmpg += this.tempoTmpg.minutos > 1 ? this.tempoTmpg.minutos + " minutos" : this.tempoTmpg.minutos + " minutos";

      });
  }

  getTMPD(){
    this.slaService.getTMPD()
      .subscribe(resp => {

        this.tempoTmpd = resp;
        this.tmpdOk = this.tempoTmpd.ok;

        if(this.tempoTmpd.dias > 0)
          this.tmpd += this.tempoTmpd.dias > 1 ? this.tempoTmpd.dias + " dias" : this.tempoTmpd.dias + " dia";

        else if(this.tempoTmpd.horas > 0)
          this.tmpd += this.tempoTmpd.horas > 1 ? this.tempoTmpd.horas + " horas" : this.tempoTmpd.horas + " hora";

        else if(this.tempoTmpd.minutos > 0)
          this.tmpd += this.tempoTmpd.minutos > 1 ? this.tempoTmpd.minutos + " minutos" : this.tempoTmpd.minutos + " minutos";

      });
  }

  getSlaGerentes(){
    this.slaService.getSlaGerentes()
      .subscribe(resp => {
        this.slaGerentes = resp;
      });
  }

  getSlaDiretores(){
    this.slaService.getSlaDiretores()
      .subscribe(resp => {
        this.slaDiretores = resp;
      });
  }
}
