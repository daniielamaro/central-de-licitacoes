import {Component, EventEmitter, OnInit, Output, Input} from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  @Output() evento = new EventEmitter();
  @Input() tituloBt: string;
  @Input() idBt: string;

  constructor() { }

  ngOnInit() {
  }

  exec(event): void {
    let btn = $('#upload-button'+this.idBt).parent().parent();
    let loadSVG = btn.children("a").children(".load");
    let loadBar = btn.children("div").children("span");
    let checkSVG = btn.children("a").children(".check");

    btn.children("a").children("span").fadeOut(200, () => {
      this.previewFile(event, (ress) => {
        let arq = {
          nome: event[0].name,
          tipo: event[0].type,
          base64: ress
        };

        btn.children("a").animate({
          width: 56
        }, 100, () => {
          loadSVG.fadeIn(300);
          btn.animate({
            width: 320
          }, 200, () => {
            btn.children("div").fadeIn(200, () => {
              loadBar.animate({
                width: "100%"
              }, 2000, () => {
                loadSVG.fadeOut(200, () => {
                  checkSVG.fadeIn(200);
                  this.evento.emit({ arquivo: arq });
                });
              });
            });
          });
        });
      });
    });
  }

  previewFile(event, callback) {
    let file = event[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onloadend = function () {
      callback((<string>reader.result).split(',')[1]);
    };
  }

}
