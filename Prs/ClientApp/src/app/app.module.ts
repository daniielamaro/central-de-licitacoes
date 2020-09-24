import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';

import { registerLocaleData } from '@angular/common';
import { LOCALE_ID } from '@angular/core';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { Alertas } from '../app/shared/class/alertas';
import { UrlService } from '../app/shared/class/url-service';
import { UploadComponent } from './shared/upload/upload.component';
import { LoginService } from '../app/views/login/login.service';
import { LoginComponent } from '../app/views/login/login.component';
import { LayoutComponent } from '../app/views/layout/layout.component';
import { HomeComponent } from '../app/views/layout/home/home.component';
import { HomeService } from '../app/views/layout/home/home.service';
import { TableComponent } from '../app/views/layout/home/table/table.component';
import { PainelComponent } from '../app/views/layout/painel/painel.component';
import { HeaderComponent } from '../app/views/layout/header/header.component';
import { MenuComponent } from '../app/views/layout/menu/menu.component';
import { NotificacaoComponent } from '../app/views/layout/header/notificacao/notificacao.component';
import { NotificacaoService } from '../app/views/layout/header/notificacao/notificacao.service';
import { DissidiosComponent } from '../app/views/layout/dissidios/dissidios.component';
import { DissidiosService } from '../app/views/layout/dissidios/dissidios.service';
import { RelatorioComponent } from '../app/views/layout/relatorio/relatorio.component';
import { AlterarEditalComponent } from '../app/views/layout/alterar/alterar-edital/alterar-edital.component';
import { AlterarParecerDiretorComponent } from '../app/views/layout/alterar/alterar-parecer-diretor/alterar-parecer-diretor.component';
import { AlterarParecerGerenteComponent } from '../app/views/layout/alterar/alterar-parecer-gerente/alterar-parecer-gerente.component';
import { AlterarParecerLicitacaoComponent } from '../app/views/layout/alterar/alterar-parecer-licitacao/alterar-parecer-licitacao.component';
import { AlterarService } from '../app/views/layout/alterar/alterar.service';
import { CarteiraContaComponent } from '../app/views/layout/carteira-conta/carteira-conta.component';
import { CarteiraContaService } from '../app/views/layout/carteira-conta/carteira-conta.service';
import { RelatorioService } from '../app/views/layout/relatorio/relatorio.service';
import { EditalComponent } from '../app/views/layout/edital/edital.component';
import { EditalService } from '../app/views/layout/edital/edital.service';
import { SlaService } from '../app/views/layout/sla/sla.service';
import { SlaComponent } from '../app/views/layout/sla/sla.component';
import { BuService } from '../app/views/layout/cadastro/bu/bu.service';
import { BuComponent } from '../app/views/layout/cadastro/bu/bu.component';
import { CategoriaService } from '../app/views/layout/cadastro/categoria/categoria.service';
import { CategoriaComponent } from '../app/views/layout/cadastro/categoria/categoria.component';
import { ClienteService } from '../app/views/layout/cadastro/cliente/cliente.service';
import { ClienteComponent } from '../app/views/layout/cadastro/cliente/cliente.component';
import { ConcorrenteService } from '../app/views/layout/cadastro/concorrente/concorrente.service';
import { ConcorrenteComponent } from '../app/views/layout/cadastro/concorrente/concorrente.component';
import { ModalidadeComponent } from '../app/views/layout/cadastro/modalidade/modalidade.component';
import { ModalidadeService } from '../app/views/layout/cadastro/modalidade/modalidade.service';
import { MotivoComumComponent } from '../app/views/layout/cadastro/motivo-comum/motivo-comum.component';
import { MotivoComumService } from '../app/views/layout/cadastro/motivo-comum/motivo-comum.service';
import { MotivoPerdaComponent } from '../app/views/layout/cadastro/motivo-perda/motivo-perda.component';
import { MotivoPerdaService } from '../app/views/layout/cadastro/motivo-perda/motivo-perda.service';
import { PortalComponent } from '../app/views/layout/cadastro/portal/portal.component';
import { PortalService } from '../app/views/layout/cadastro/portal/portal.service';
import { PreVendaComponent } from '../app/views/layout/cadastro/pre-venda/pre-venda.component';
import { PreVendaService } from '../app/views/layout/cadastro/pre-venda/pre-venda.service';
import { UsuarioComponent } from '../app/views/layout/cadastro/usuario/usuario.component';
import { UsuarioService } from '../app/views/layout/cadastro/usuario/usuario.service';
import { ComentarioEditalComponent } from '../app/views/layout/comentario-edital/comentario-edital.component';
import { ComentarioEditalService } from '../app/views/layout/comentario-edital/comentario-edital.service';
import { ConsultarHistoricoComponent } from '../app/views/layout/consultar-historico/consultar-historico.component';
import { ConsultarHistoricoService } from '../app/views/layout/consultar-historico/consultar-historico.service';
import { HistoricoComponent } from '../app/views/layout/historico/historico.component';
import { HistoricoService } from '../app/views/layout/historico/historico.service';
import { IndicadoresComponent } from '../app/views/layout/indicadores/indicadores.component';
import { IndicadoresService } from '../app/views/layout/indicadores/indicadores.service';
import { DiretorComponent } from '../app/views/layout/parecer/diretor/diretor.component';
import { DiretorService } from '../app/views/layout/parecer/diretor/diretor.service';
import { GerenteComponent } from '../app/views/layout/parecer/gerente/gerente.component';
import { GerenteService } from '../app/views/layout/parecer/gerente/gerente.service';
import { LicitacaoComponent } from '../app/views/layout/parecer/licitacao/licitacao.component';
import { LicitacaoService } from '../app/views/layout/parecer/licitacao/licitacao.service';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { NgxPopper } from 'angular-popper';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    LoginComponent,
    UploadComponent,
    HomeComponent,
    TableComponent,
    PainelComponent,
    HeaderComponent,
    MenuComponent,
    NotificacaoComponent,
    DissidiosComponent,
    RelatorioComponent,
    SlaComponent,
    AlterarEditalComponent,
    AlterarParecerDiretorComponent,
    AlterarParecerGerenteComponent,
    AlterarParecerLicitacaoComponent,
    CarteiraContaComponent,
    EditalComponent,
    BuComponent,
    CategoriaComponent,
    ClienteComponent,
    ConcorrenteComponent,
    ModalidadeComponent,
    MotivoComumComponent,
    MotivoPerdaComponent,
    PortalComponent,
    PreVendaComponent,
    UsuarioComponent,
    ComentarioEditalComponent,
    ConsultarHistoricoComponent,
    HistoricoComponent,
    IndicadoresComponent,
    DiretorComponent,
    GerenteComponent,
    LicitacaoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CurrencyMaskModule,
    NgxExtendedPdfViewerModule,
    NgbPaginationModule,
    NgbAlertModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: LayoutComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomeComponent },
      { path: 'sla', component: SlaComponent },
      { path: 'edital', component: EditalComponent },
      { path: 'parecer-gerente', component: GerenteComponent },
      { path: 'alterar-edital', component: AlterarEditalComponent },
      { path: 'alterar-parecer-gerente', component: AlterarParecerGerenteComponent },
      { path: 'alterar-parecer-diretor', component: AlterarParecerDiretorComponent },
      { path: 'alterar-parecer-licitacao', component: AlterarParecerLicitacaoComponent },
      { path: 'indicadores', component: IndicadoresComponent },
      { path: 'parecer-diretor', component: DiretorComponent },
      { path: 'parecer-licitacao', component: LicitacaoComponent },
      { path: 'dissidios', component: DissidiosComponent },
      { path: 'usuario', component: UsuarioComponent },
      { path: 'cliente', component: ClienteComponent },
      { path: 'relatorio', component: RelatorioComponent },
      { path: 'carteira', component: CarteiraContaComponent },
      { path: 'consultar-historico', component: ConsultarHistoricoComponent },
      { path: 'historico', component: HistoricoComponent },
      { path: 'motivo-perda', component: MotivoPerdaComponent },
      { path: 'motivo-comum', component: MotivoComumComponent },
      { path: 'modalidade', component: ModalidadeComponent },
      { path: 'pre-venda', component: PreVendaComponent },
      { path: 'bu', component: BuComponent },
      { path: 'categoria', component: CategoriaComponent },
      { path: 'concorrente', component: ConcorrenteComponent },
      { path: 'portal', component: PortalComponent },
      { path: 'comentario-edital', component: ComentarioEditalComponent },
      { path: '404', component: LayoutComponent },
      { path: '**', component: LayoutComponent }
    ]),
    NgxPopper
  ],
  providers: [
    LoginService,
    Alertas,
    UrlService,
    HomeService,
    NotificacaoService,
    DissidiosService,
    RelatorioService,
    SlaService,
    AlterarService,
    CarteiraContaService,
    EditalService,
    BuService,
    CategoriaService,
    ClienteService,
    ConcorrenteService,
    ModalidadeService,
    MotivoComumService,
    MotivoPerdaService,
    PortalService,
    PreVendaService,
    UsuarioService,
    ComentarioEditalService,
    ConsultarHistoricoService,
    HistoricoService,
    IndicadoresService,
    DiretorService,
    GerenteService,
    LicitacaoService,
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
