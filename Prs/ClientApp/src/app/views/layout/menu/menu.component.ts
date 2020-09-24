import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor() { }

  public iconi: string;
  public ativarScroll: boolean = false
  public iconSetaAlt:string;
  public iconSetaCad:string;
  public trocIconAlt: boolean = false;
  public trocIconCad: boolean = false;
  user: User = new User();

  public imgBotao: Array<any> = [
    "fa fa-bars fa-2x",
    "fa fa-times fa-2x"
  ];
  public imgSeta: Array<any> = [
    "fa fa-chevron-down fa-2x iconi",
    "fa fa-chevron-up fa-2x iconi"
  ];
  public alterar: boolean = false;

  ngOnInit(): void {
    this.iconi = this.imgBotao[0];
    this.iconSetaAlt = this.imgSeta[0];
    this.iconSetaCad = this.imgSeta[0];

    if("user" in localStorage){
      this.user = JSON.parse(localStorage.getItem("user"));
    }

    else if("user" in sessionStorage){
      this.user = JSON.parse(sessionStorage.getItem("user"));
    }
  }


  alterarMenu(){
    if(!this.alterar){
      this.alterar = true;
      this.iconi = this.imgBotao[1];  
    }else{
      document.querySelector('#alterar').classList.remove('show');
      document.querySelector('#cadastro').classList.remove('show');
      this.alterar = false;
      this.trocIconAlt = false;
      this.iconi = this.imgBotao[0];
      this.trocIconAlt = false;
      this.iconSetaAlt = this.imgSeta[0];
      this.trocIconCad = false;
      this.iconSetaCad = this.imgSeta[0];
    }
  }

  abrirDropdown(menu){
    if(menu == 0){
      if(!this.trocIconAlt){
        this.trocIconAlt = true;
        this.iconSetaAlt = this.imgSeta[1];
      }else{
        this.trocIconAlt = false;
        this.iconSetaAlt = this.imgSeta[0];
      }
    }else{
      if(!this.trocIconCad){
        this.trocIconCad = true;
        this.iconSetaCad = this.imgSeta[1];
      }else{
        this.trocIconCad = false;
        this.iconSetaCad = this.imgSeta[0];
      }
    }
  }

  navegar(){
    if(this.alterar){
      this.alterarMenu()
    }
  }
}
