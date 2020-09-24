import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user';
import { HomeService } from './home/home.service';
import { UrlService } from 'src/app/shared/class/url-service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(public router: Router, private urlService: UrlService) {
    if ('user' in localStorage || 'user' in sessionStorage)
        this.router.navigate(['/home']);
    else{
        this.router.navigate(['/login']);
        return;
    }
  }

  ngOnInit(): void {}

}
