import { Injectable } from '@angular/core';
import { UrlService }  from '../../../shared/class/url-service';

@Injectable()
export class ComentarioEditalService {

   constructor(private urlService: UrlService) { }

   obterComentarios(id: string){
      return this.urlService.sendRequestPost(`Comentario/GetById?id=${id}`);
   }

   cadastrarComentario(
      mensagem: string,
      usuario: number,
      editalId: string
   ) {
      return this.urlService.sendRequestPost(`Comentario/Create`, JSON.stringify({
         mensagem,
         usuario,
         editalId: Number(editalId)
      }));
   }

   alterarComentario(
      id: number,
      mensagem: string,
      usuario: number,
      editalId: number,
      ativo: boolean,
   ) {
      return this.urlService.sendRequestPut(`Comentario/Update`, JSON.stringify({
         id,
         mensagem,
         usuario,
         editalId: Number(editalId),
         ativo
      }));
   }


   getUser(){
      return this.urlService.getUser();
   }
}
