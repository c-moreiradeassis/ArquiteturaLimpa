import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contatos } from '../_models/contatos';

@Injectable({
  providedIn: 'root',
})
export class ContatosService {
  baseURL = 'http://localhost:5000/Contatos';

  constructor(private http: HttpClient) {}

  getContatos(): Observable<Contatos[]> {
    return this.http.get<Contatos[]>(`${this.baseURL}`);
  }

  deleteContatos(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  postContatos(contato: Contatos) {
    return this.http.post(`${this.baseURL}`, contato);
  }

  putContatos(contato: Contatos) {
    return this.http.put(`${this.baseURL}/${contato.id}`, contato);
  }
}
