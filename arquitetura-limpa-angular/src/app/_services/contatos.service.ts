import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ContatosService {
  baseURL = 'localhost:5000/contatos';

  constructor(private http: HttpClient) {}

  getContatos() {
    return this.http.get(`${this.baseURL}`);
  }
}
