import { User } from '../../views/layout/user';
import { Router } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';

@Injectable()
export class UrlService {

     private user: User;
    private header: any;
    private baseUrl: string;

  constructor(private router: Router, @Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
      this.baseUrl = baseUrl;

      if ('user' in localStorage)
         this.user = JSON.parse(localStorage.getItem('user'));
      else if ('user' in sessionStorage)
         this.user = JSON.parse(sessionStorage.getItem('user'));
      else{
         this.router.navigate(['/login']);
         return;
      }
   }

  getHeaders() {
    if (!this.user) {
      if ('user' in localStorage)
        this.user = JSON.parse(localStorage.getItem('user'));
      else if ('user' in sessionStorage)
        this.user = JSON.parse(sessionStorage.getItem('user'));
      else {
        this.router.navigate(['/login']);
        return;
      }
    }

      this.header = {
         headers: new HttpHeaders()
            .set('Authorization', `Bearer ${this.user.token}`)
            .set('Content-Type', 'application/json')
      };

      return this.header;
   }

   getUser(){
      return this.user;
   }

   sendRequestPostWithoutHeaders(url: string, body: string = ""){
      return this.http.post(this.baseUrl+url, body);
   }

   sendRequestPost(url: string, body: string = ""){
     return this.http.post(this.baseUrl+url, body, this.getHeaders());
   }

   sendRequestPut(url: string, body: string = ""){
     return this.http.put(this.baseUrl+url, body, this.getHeaders());
   }

   sendRequestDelete(url: string){
     return this.http.delete(this.baseUrl+url, this.getHeaders());
   }

   sendRequestFetchPost(url: string, body: string = ""){
     return fetch(this.baseUrl+url, {
         method: 'POST',
         body: body,
         headers: {
           "Content-Type": this.getHeaders()["headers"].get("Content-Type"),
           "Authorization": this.getHeaders()["headers"].get("Authorization")
         }
       });
   }
}
