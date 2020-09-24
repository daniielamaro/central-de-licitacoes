import Swal from 'sweetalert2';
import { Injectable } from '@angular/core';

@Injectable()
export class Alertas {
  
    constructor(){ }

    erro(message: string): any {
        return Swal.fire('Erro', message, 'error');
    }

    sucesso(message: string): any {
        return this.show(message, 'success', 'Sucesso');
    }
    
    warning(message: string): any {
        return this.show(message, 'warning', 'Cuidado!');
    }
    
    warningAlert(message: string): any {
        return Swal.fire({
                title: 'Atenção!',
                text: message,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim',
                cancelButtonText: 'Não'
            });
    }
    
    
    showLoading(title: string) {
        return Swal.fire({
            title: title,
            allowEscapeKey: false,
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading();
            }
        })
    };
    
    fecharModal(){
        if(Swal.isVisible()) {
            Swal.close();
        }
    }
    
    private show(message: string, type: any, title: string): any {
        return Swal.fire({
            icon: type,
            title: title,
            text: message
        });
    }
}
