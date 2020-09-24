import { Component, OnInit, AfterContentInit } from '@angular/core';
import { HomeService } from './home.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UrlService } from 'src/app/shared/class/url-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

   constructor(private homeService: HomeService, private fb: FormBuilder, private urlService: UrlService) { }

   public user: any;
   public exibirEtapa1: boolean = true
   public exibirEtapa2: boolean = true
   public exibirEtapa3: boolean = true
   public exibirEtapa4: boolean = true
   public exibirSuspenso: boolean = true

   public totalEditalGanhos: string;
   public totalEdital: string;
   public totalEditalGo: string;
   public totalEditalNoGo: string;
   public totalEditalSuspenso: string;

   public filtroForm: FormGroup;
   public dadosForm: any;
   public seta: Array<any> = [
      "../../../../assets/iconis/baixo03.png",
      "../../../../assets/iconis/cima01.png"
   ];
   public toogleSeta;
   public editaisAguardandoGerente: any;
   public editaisAguardandoDiretor: any;
   public editaisAguardandoLicitacao: any;
   public editaisAcompanhar: any;
   public editaisSuspenso: any;

   dataAtual: Date = new Date();

  ngOnInit(): void {
    this.user = this.urlService.getUser();

      this.filtroForm = this.fb.group({
         id: this.fb.control(""),
         numEdital: this.fb.control(''),
         cliente: this.fb.control(""),
         dataAberturaEditalInicio: this.fb.control(''),
         dataAberturaEditalFinal: this.fb.control(''),
         modalidade: this.fb.control(""),
         regiao: this.fb.control(""),
         estado: this.fb.control(""),
         uasg: this.fb.control(''),
         consorcio: this.fb.control(''),
         portal: this.fb.control(""),
         gerenteDeContas: this.fb.control(""),
         diretorComercial: this.fb.control(""),
         valorEstimadoInicio: this.fb.control(""),
         valorEstimadoFinal: this.fb.control(""),
         categoria: this.fb.control(""),
         bu: this.fb.control("")
      })

      this.getDadosForm();

      this.getTotalEdital();
      this.getTotalEditalGanhos();
      this.getTotalEditalGo();
      this.getTotalEditalNoGo();
      this.getTotalEditalSuspenso();
      this.obterTabelaGerente();
      this.obterTabelaDiretor();
      this.obterTabelaLicitacao();
      this.obterTabelaAcompanhar();
      this.obterTabelaSuspenso();

      this.toogleSeta = this.seta[0];
   }

   obterTabelaGerente(){
      this.homeService.getWaitingGerente(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe((resp) => {
         this.editaisAguardandoGerente = resp;
      });
   }

   obterTabelaDiretor(){
      this.homeService.getWaitingDiretor(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe((resp) => {
         this.editaisAguardandoDiretor = resp;
      });
   }

   obterTabelaLicitacao(){
      this.homeService.getWaitingLicitacao(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe((resp) => {
         this.editaisAguardandoLicitacao = resp;
      });
   }

   obterTabelaAcompanhar(){
      this.homeService.getAguardandoFinalizacao(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe((resp) => {
         this.editaisAcompanhar = resp;
      });
   }

   obterTabelaSuspenso(){
      this.homeService.getSuspenso(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe((resp) => {
         this.editaisSuspenso = resp;
      });
   }

   toogleCard(){
      if(this.toogleSeta == this.seta[0]){
         this.toogleSeta = this.seta[1];
      }else{
         this.toogleSeta = this.seta[0];
      }
   }

   getDadosForm(){
      this.homeService.getDadoForm().subscribe(res => {
         this.dadosForm = res;
      })
   }

   getTotalEditalGanhos(){
      this.homeService.getTotalEditalGanhos(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      ).subscribe(resp => {
            this.totalEditalGanhos = String(resp);
         });
   }

   getTotalEdital(){
      this.homeService.getTotalEdital(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      )
         .subscribe(resp => {
            this.totalEdital = String(resp);
         });
   }

   getTotalEditalGo(){
      this.homeService.getTotalEditalGo(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      )
         .subscribe(resp => {
            this.totalEditalGo = String(resp);
         });
   }

   getTotalEditalNoGo(){
      this.homeService.getTotalEditalNoGo(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      )
         .subscribe(resp => {
            this.totalEditalNoGo = String(resp);
         });
   }

   getTotalEditalSuspenso(){
      this.homeService.getTotalEditalSuspenso(
         this.filtroForm.get("id").value,
         this.filtroForm.get("numEdital").value,
         this.filtroForm.get("cliente").value,
         this.filtroForm.get("dataAberturaEditalInicio").value,
         this.filtroForm.get("dataAberturaEditalFinal").value,
         this.filtroForm.get("modalidade").value,
         this.filtroForm.get("regiao").value,
         this.filtroForm.get("estado").value,
         this.filtroForm.get("categoria").value,
         this.filtroForm.get("uasg").value,
         this.filtroForm.get("consorcio").value,
         this.filtroForm.get("portal").value,
         this.filtroForm.get("gerenteDeContas").value,
         this.filtroForm.get("diretorComercial").value,
         this.filtroForm.get("valorEstimadoInicio").value,
         this.filtroForm.get("valorEstimadoFinal").value,
         this.filtroForm.get("bu").value
      )
         .subscribe(resp => {
            this.totalEditalSuspenso = String(resp);
         });
   }

   exibirEtapa(event){
      let etapa = event.target.value
      if(etapa == 1){
         this.exibirEtapa1 = !this.exibirEtapa1
      }
      if(etapa == 2){
         this.exibirEtapa2 = !this.exibirEtapa2
      }
      if(etapa == 3){
         this.exibirEtapa3 = !this.exibirEtapa3
      }
      if(etapa == 4){
         this.exibirEtapa4 = !this.exibirEtapa4
      }
      if(etapa == 'suspenso'){
         this.exibirSuspenso = !this.exibirSuspenso
      }
   }

   filtrar(){
      this.obterTabelaGerente();
      this.obterTabelaDiretor();
      this.obterTabelaLicitacao();
      this.obterTabelaAcompanhar();
      this.obterTabelaSuspenso();
      this.getTotalEditalGanhos();
      this.getTotalEdital();
      this.getTotalEditalGo();
      this.getTotalEditalNoGo();
      this.getTotalEditalSuspenso();
   }

   limparFiltros(){
      this.filtroForm.get("id").setValue('');
      this.filtroForm.get("numEdital").setValue('');
      this.filtroForm.get("cliente").setValue('');
      this.filtroForm.get("dataAberturaEditalInicio").setValue('');
      this.filtroForm.get("dataAberturaEditalFinal").setValue('');
      this.filtroForm.get("modalidade").setValue('');
      this.filtroForm.get("regiao").setValue('');
      this.filtroForm.get("estado").setValue('');
      this.filtroForm.get("categoria").setValue('');
      this.filtroForm.get("uasg").setValue('');
      this.filtroForm.get("consorcio").setValue('');
      this.filtroForm.get("portal").setValue('');
      this.filtroForm.get("gerenteDeContas").setValue('');
      this.filtroForm.get("diretorComercial").setValue('');
      this.filtroForm.get("valorEstimadoInicio").setValue('');
      this.filtroForm.get("valorEstimadoFinal").setValue('');
      this.filtroForm.get("bu").setValue('');

      this.obterTabelaGerente();
      this.obterTabelaDiretor();
      this.obterTabelaLicitacao();
      this.obterTabelaAcompanhar();
      this.obterTabelaSuspenso();
      this.getTotalEditalGanhos();
      this.getTotalEdital();
      this.getTotalEditalGo();
      this.getTotalEditalNoGo();
      this.getTotalEditalSuspenso();
   }
}
