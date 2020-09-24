import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { EditalService } from './edital.service';
import { Arquivo } from '../../../shared/upload/arquivo';
import { Alertas } from '../../../shared/class/alertas';
import { User } from '../user';

@Component({
   selector: 'app-edital',
   templateUrl: './edital.component.html',
   styleUrls: ['./edital.component.css'],
})
export class EditalComponent implements OnInit {
   public atualizar: boolean = false;
   private editalId: string;
   public restaurar: boolean = false;

   public cadastrarEditalForm: FormGroup;
   public clientes: any;
   public modalidades: any;
   public regioes: any;
   public estados: any;
   public portais: any;
   public gerentes: any;
   public diretores: any;
   public categorias: any;
   public isVistoria: boolean;
   public exibirUpload: boolean = false;
   public edital: any;
   private idArquivo: number;
   public arquivo: Arquivo = new Arquivo();

   public dataAbertura: Date
   public dataVistoria: Date
   public dataAtual: Date

   user: User = new User();

   constructor(
      private router: Router,
      private editalService: EditalService,
      private alertas: Alertas
   ) {}

   ngOnInit() {
      if("user" in localStorage){
         this.user = JSON.parse(localStorage.getItem("user"));
      }

      else if("user" in sessionStorage){
         this.user = JSON.parse(sessionStorage.getItem("user"));
      }

      this.getDadosFormulario();

      this.cadastrarEditalForm = new FormGroup({
         numEdital: new FormControl('', Validators.required),
         cliente: new FormControl('', Validators.required),
         dataAberturaEdital: new FormControl('', Validators.required),
         horaAberturaEdital: new FormControl('', Validators.required),
         modalidade: new FormControl('', Validators.required),
         regiao: new FormControl('', Validators.required),
         estado: new FormControl('', Validators.required),
         portal: new FormControl('', Validators.required),
         uasg: new FormControl('', Validators.required),
         gerenteDeContas: new FormControl('', Validators.required),
         consorcio: new FormControl('', Validators.required),
         diretorComercial: new FormControl('', Validators.required),
         valorEstimado: new FormControl(''),
         agendarVistoria: new FormControl('', Validators.required),
         dataVistoria: new FormControl(''),
         objetosDescricao: new FormControl(''),
         objetosResumo: new FormControl(''),
         observacao: new FormControl(''),
         arquivo: new FormControl('', Validators.required),
         categorizacao: new FormControl('', Validators.required),
      });

      if ('edital-id' in sessionStorage) {
         this.atualizar = true;
         this.editalId = sessionStorage.getItem('edital-id');
         sessionStorage.removeItem('edital-id');
      }

      if('restaurar' in sessionStorage){
         this.restaurar = true;
         this.editalId = sessionStorage.getItem('restaurar');
         sessionStorage.removeItem('restaurar');
      }

      if (this.atualizar) this.obterEdital(this.editalId);

      if (this.restaurar) this.obterEdital(this.editalId);
   }

   validarData() {
      this.dataAbertura = new Date(
         this.cadastrarEditalForm.get("dataAberturaEdital").value
      );
      this.dataVistoria = new Date(
         this.cadastrarEditalForm.get("dataVistoria").value
      );
      this.dataAbertura.setDate(this.dataAbertura.getDate() + 1);
      this.dataVistoria.setDate(this.dataVistoria.getDate() + 1);
   }

   suspenderEdital(){
      this.alertas.warningAlert("Deseja suspender esse edital?")
         .then((result) => {
            if (result.value) {
               this.editalService.suspenderEdital(Number(this.editalId))
                  .subscribe(() => {
                     this.router.navigate([""]);
                  })
            }
         })
   }

   persistir() {
      this.validarData();
      this.dataAtual = new Date();

      // if (this.dataAbertura < this.dataAtual) {
      //    this.alertas.erro('A Data Abertura Edital não pode ser menor que a Data Atual!');
      //    return;
      // }

      if(this.cadastrarEditalForm.get("agendarVistoria").value != "Não" && !this.cadastrarEditalForm.get('dataVistoria').value){
         this.alertas.erro('A Data de Vistoria deve ser preenchida!');
         return;
      }

      // if ( this.cadastrarEditalForm.get("agendarVistoria").value != "Não" && this.dataVistoria < this.dataAtual) {
      //    this.alertas.erro('A Data de Vistoria não pode ser menor que a Data Atual!');
      //    return;
      // }

      if (this.atualizar) {
         this.atualizarEdital();
      } else if(!this.atualizar && !this.restaurar) {
         this.cadastrarEdital();
      }else{
         this.restaurarEdital();
      }
   }

   cadastrarEdital() {
      this.alertas.showLoading("Cadastrando novo edital...");
       this.editalService.cadastrarEdital(
         this.cadastrarEditalForm.get("numEdital").value,
         this.cadastrarEditalForm.get("cliente").value,
         this.cadastrarEditalForm.get("estado").value,
         this.cadastrarEditalForm.get("modalidade").value,
         this.cadastrarEditalForm.get("dataAberturaEdital").value,
         this.cadastrarEditalForm.get("horaAberturaEdital").value,
         this.cadastrarEditalForm.get("uasg").value,
         this.cadastrarEditalForm.get("categorizacao").value,
         this.cadastrarEditalForm.get("consorcio").value,
         this.cadastrarEditalForm.get("valorEstimado").value,
         this.cadastrarEditalForm.get("agendarVistoria").value,
         this.cadastrarEditalForm.get("dataVistoria").value,
         this.cadastrarEditalForm.get("objetosDescricao").value,
         this.cadastrarEditalForm.get("objetosResumo").value,
         this.cadastrarEditalForm.get("observacao").value,
         this.cadastrarEditalForm.get("regiao").value,
         this.cadastrarEditalForm.get("gerenteDeContas").value,
         this.cadastrarEditalForm.get("diretorComercial").value,
         this.cadastrarEditalForm.get("portal").value,
         this.cadastrarEditalForm.get("arquivo").value
       )
       .subscribe(() => {
         this.alertas.fecharModal();
         this.router.navigate([""]);
       });
   }

   atualizarEdital() {
      this.alertas.showLoading("Atualizando edital...");
      this.editalService
         .atualizarEdital(
            this.editalId,
            this.cadastrarEditalForm.get('numEdital').value,
            this.cadastrarEditalForm.get('cliente').value,
            this.cadastrarEditalForm.get('estado').value,
            this.cadastrarEditalForm.get('modalidade').value,
            this.cadastrarEditalForm.get('dataAberturaEdital').value,
            this.cadastrarEditalForm.get('horaAberturaEdital').value,
            this.cadastrarEditalForm.get('uasg').value,
            this.cadastrarEditalForm.get('categorizacao').value,
            this.cadastrarEditalForm.get('consorcio').value,
            this.cadastrarEditalForm.get('valorEstimado').value,
            this.cadastrarEditalForm.get('agendarVistoria').value,
            this.cadastrarEditalForm.get('dataVistoria').value,
            this.cadastrarEditalForm.get('objetosDescricao').value,
            this.cadastrarEditalForm.get('objetosResumo').value,
            this.cadastrarEditalForm.get('observacao').value,
            this.cadastrarEditalForm.get('regiao').value,
            this.cadastrarEditalForm.get('gerenteDeContas').value,
            this.cadastrarEditalForm.get('diretorComercial').value,
            this.cadastrarEditalForm.get('portal').value,
            this.cadastrarEditalForm.get('arquivo').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            this.router.navigate(['']);
         });
   }

   restaurarEdital() {
      this.alertas.showLoading("Restaurando edital...");
      this.editalService
         .restaurarEdital(
            this.editalId,
            this.cadastrarEditalForm.get('numEdital').value,
            this.cadastrarEditalForm.get('cliente').value,
            this.cadastrarEditalForm.get('estado').value,
            this.cadastrarEditalForm.get('modalidade').value,
            this.cadastrarEditalForm.get('dataAberturaEdital').value,
            this.cadastrarEditalForm.get('horaAberturaEdital').value,
            this.cadastrarEditalForm.get('uasg').value,
            this.cadastrarEditalForm.get('categorizacao').value,
            this.cadastrarEditalForm.get('consorcio').value,
            this.cadastrarEditalForm.get('valorEstimado').value,
            this.cadastrarEditalForm.get('agendarVistoria').value,
            this.cadastrarEditalForm.get('dataVistoria').value,
            this.cadastrarEditalForm.get('objetosDescricao').value,
            this.cadastrarEditalForm.get('objetosResumo').value,
            this.cadastrarEditalForm.get('observacao').value,
            this.cadastrarEditalForm.get('regiao').value,
            this.cadastrarEditalForm.get('gerenteDeContas').value,
            this.cadastrarEditalForm.get('diretorComercial').value,
            this.cadastrarEditalForm.get('portal').value,
            this.cadastrarEditalForm.get('arquivo').value
         )
         .subscribe(() => {
            this.alertas.fecharModal();
            this.router.navigate(['']);
         });
   }

   restaurarEditalByAtualizacao(){
      this.validarData();
      this.dataAtual = new Date();

      if (this.dataAbertura < this.dataAtual) {
         this.alertas.erro('A Data Abertura Edital não pode ser menor que a Data Atual!');
         return;
      }

      if(this.cadastrarEditalForm.get("agendarVistoria").value != "Não" && !this.cadastrarEditalForm.get('dataVistoria').value){
         this.alertas.erro('A Data de Vistoria deve ser preenchida!');
         return;
      }

      if ( this.cadastrarEditalForm.get("agendarVistoria").value != "Não" && this.dataVistoria < this.dataAtual) {
         this.alertas.erro('A Data de Vistoria não pode ser menor que a Data Atual!');
         return;
      }

      this.alertas.warningAlert("Deseja restaurar esse edital?")
         .then((result) => {
            if (result.value) {
               this.restaurarEdital();
            }
         })
   }

   registerNewElement(link: string) {}

   obterEdital(id: string) {
      this.alertas.showLoading('Carregando Edital...');

      this.editalService.obterEdital(id).subscribe((resp) => {
         this.edital = resp;

         this.cadastrarEditalForm
            .get('numEdital')
            .setValue(this.edital.numEdital);
         this.cadastrarEditalForm
            .get('cliente')
            .setValue(this.edital.cliente.id);
         this.cadastrarEditalForm.get('estado').setValue(this.edital.estado.id);
         this.cadastrarEditalForm
            .get('modalidade')
            .setValue(this.edital.modalidade.id);

         let dataHoraAbertura = new Date(this.edital.dataHoraDeAbertura);

         let dia =
            dataHoraAbertura.getDate() < 10
               ? '0' + dataHoraAbertura.getDate()
               : dataHoraAbertura.getDate();
         let mes =
            dataHoraAbertura.getMonth() + 1 < 10
               ? '0' + (dataHoraAbertura.getMonth() + 1)
               : dataHoraAbertura.getMonth() + 1;
         let ano = dataHoraAbertura.getFullYear();
         let hora =
            dataHoraAbertura.getHours() < 10
               ? '0' + dataHoraAbertura.getHours()
               : dataHoraAbertura.getHours();
         let minuto =
            dataHoraAbertura.getMinutes() < 10
               ? '0' + dataHoraAbertura.getMinutes()
               : dataHoraAbertura.getMinutes();

         let dataAbertura = ano + '-' + mes + '-' + dia;
         let horaAbertura = hora + ':' + minuto;

         let dataVistoriaPre = new Date(this.edital.dataVistoria);

         let diaVistoria =
            dataVistoriaPre.getDate() < 10
               ? '0' + dataVistoriaPre.getDate()
               : dataVistoriaPre.getDate();
         let mesVistoria =
            dataVistoriaPre.getMonth() + 1 < 10
               ? '0' + (dataVistoriaPre.getMonth() + 1)
               : dataVistoriaPre.getMonth() + 1;
         let anoVistoria = dataVistoriaPre.getFullYear();

         let dataVistoria = anoVistoria + '-' + mesVistoria + '-' + diaVistoria;

         this.cadastrarEditalForm.get('dataVistoria').setValue(dataVistoria);

         this.cadastrarEditalForm
            .get('dataAberturaEdital')
            .setValue(dataAbertura);
         this.cadastrarEditalForm
            .get('horaAberturaEdital')
            .setValue(horaAbertura);
         this.cadastrarEditalForm.get('uasg').setValue(this.edital.uasg);
         this.cadastrarEditalForm
            .get('categorizacao')
            .setValue(this.edital.categoria.id);
         this.cadastrarEditalForm
            .get('consorcio')
            .setValue(this.edital.consorcio);
         this.cadastrarEditalForm
            .get('valorEstimado')
            .setValue(this.edital.valorEstimado);
         this.cadastrarEditalForm
            .get('agendarVistoria')
            .setValue(this.edital.agendarVistoria);
         this.cadastrarEditalForm
            .get('objetosDescricao')
            .setValue(this.edital.objetosDescricao);
         this.cadastrarEditalForm
            .get('objetosResumo')
            .setValue(this.edital.objetosResumo);
         this.cadastrarEditalForm
            .get('observacao')
            .setValue(this.edital.observacoes);
         this.cadastrarEditalForm.get('regiao').setValue(this.edital.regiao.id);
         this.cadastrarEditalForm
            .get('gerenteDeContas')
            .setValue(this.edital.gerente.id);
         this.cadastrarEditalForm
            .get('diretorComercial')
            .setValue(this.edital.diretor.id);
         this.cadastrarEditalForm.get('portal').setValue(this.edital.portal.id);

         if(this.edital.anexo){
            this.arquivo = this.edital.anexo;
            this.cadastrarEditalForm.get('arquivo').setValue(this.arquivo);
            let btLink = document.getElementById('download-anexo');
            btLink.setAttribute(
               'href',
               `data:${this.arquivo.tipo};base64,${this.arquivo.base64}`
            );
            this.exibirUpload = true;
         }
         
         this.alertas.fecharModal();
      });
   }

   upload(response) {
      this.arquivo = response.arquivo;

      if (this.atualizar) this.arquivo.id = this.idArquivo;

      this.cadastrarEditalForm.get('arquivo').setValue(this.arquivo);
      this.exibirUpload = true;
      let btLink = document.getElementById('download-anexo');
      btLink.setAttribute(
         'href',
         `data:${this.arquivo.tipo};base64,${this.arquivo.base64}`
      );
   }

   downloadAnexo() {
      let btLink = document.getElementById('download-anexo');
      btLink.click();
   }

   excluirEdital() {
      this.idArquivo = this.arquivo.id;
      this.arquivo = new Arquivo();
      this.cadastrarEditalForm.get('arquivo').setValue('');
      this.exibirUpload = false;
      let btLink = document.getElementById('download-anexo');
      btLink.setAttribute('href', '');
   }

   private getDadosFormulario() {
      this.editalService.getDadosCadastrarEdital().subscribe((resp) => {
         this.clientes = resp['clientes'];
         this.modalidades = resp['modalidades'];
         this.regioes = resp['regioes'];
         this.estados = resp['estados'];
         this.portais = resp['portais'];
         this.gerentes = resp['gerentes'];
         this.diretores = resp['diretores'];
         this.categorias = resp['categorias'];
      });
   }
}
