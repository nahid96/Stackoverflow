import { Injectable } from '@angular/core';
import {Home} from './home.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  formData: Home;
  list: Home[];
  readonly rootURL = 'http://localhost:12163/api';

  constructor(private http: HttpClient) { }

  refreshList(){
    this.http.get(this.rootURL + '/GetQuestions')
      .toPromise().then(res => this.list = res as Home[]);
  }
}
