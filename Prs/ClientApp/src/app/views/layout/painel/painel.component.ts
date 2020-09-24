import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-painel',
  templateUrl: './painel.component.html',
  styleUrls: ['./painel.component.css']
})
export class PainelComponent implements OnInit {

  constructor() { }

  @Input() titulo: string;
  @Input() tipo: string;
  @Input() conteudo : string;
  @Input() sla: boolean = false;

  ngOnInit(): void {
  }

}
