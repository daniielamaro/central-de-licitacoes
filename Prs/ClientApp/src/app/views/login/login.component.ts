import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { Alertas } from '../../shared/class/alertas';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  solicitaForm: FormGroup;
  lembrarSenha: boolean = false;
  solicitarAcesso: boolean = false;

  constructor(private fb: FormBuilder, private loginServiceAuth: LoginService, private router: Router, private alerta: Alertas) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      user: this.fb.control('', [Validators.required]),
      pass: this.fb.control('', [Validators.required])
    });

    this.solicitaForm = this.fb.group({
      nome: this.fb.control('', [Validators.required]),
      email: this.fb.control('', [Validators.required]),
      motivo: this.fb.control('', [Validators.required])
    });
  }

  login(){
    this.alerta.showLoading("Verificando usuario...");

    this.loginServiceAuth.login(this.loginForm.get("user").value, this.loginForm.get("pass").value)
      .subscribe(user => {

        this.alerta.fecharModal();

        if(this.lembrarSenha){
          localStorage.removeItem("user");
          sessionStorage.removeItem("user");
          localStorage.setItem("user", JSON.stringify(user));
        }else{
          localStorage.removeItem("user");
          sessionStorage.removeItem("user");
          sessionStorage.setItem("user", JSON.stringify(user));
        }

        this.router.navigate(['']);

      }, erro => { this.alerta.erro(erro.error) });

  }

  solicitar(){
    this.alerta.showLoading("Enviando solicitação...");

    this.loginServiceAuth.solicitar(this.solicitaForm.get("nome").value, this.solicitaForm.get("email").value, this.solicitaForm.get("motivo").value)
      .subscribe(() => {

        this.solicitaForm.get("nome").setValue("");
        this.solicitaForm.get("email").setValue("");
        this.solicitaForm.get("motivo").setValue("");
        this.solicitarAcesso = false;

        this.alerta.fecharModal();

        this.alerta.sucesso("Solicitação enviada com sucesso! Aguarde a chegada do email confirmando o seu cadastro.")

      }, erro => { this.alerta.erro(erro.error) });
  }

}
