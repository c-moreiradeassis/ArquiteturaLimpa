import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Contatos } from '../_models/contatos';
import { ContatosService } from '../_services/contatos.service';

@Component({
  selector: 'app-contatos',
  templateUrl: './contatos.component.html',
  styleUrls: ['./contatos.component.css'],
})
export class ContatosComponent implements OnInit {
  contato = {} as Contatos;
  listaContatos: Contatos[] = [];
  operacao = 'post';

  formulario = this.formBuilder.group({
    id: [''],
    nome: ['', Validators.required],
    cpf: ['', Validators.required],
    telefone: ['', Validators.required],
    email: ['', Validators.required],
  });

  constructor(
    private contatosService: ContatosService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.getContatos();
  }

  apresentarModal(template: any){
    template.show();
  }

  deleteContatos(id: number) {
    this.contatosService.deleteContatos(id).subscribe(
      (resp) => {
        console.log(resp);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  editarForm(contatoEditar: Contatos) {
    this.formulario.patchValue(contatoEditar);
    this.operacao = 'put';
  }

  getContatos() {
    this.contatosService.getContatos().subscribe(
      (resp: Contatos[]) => {
        this.listaContatos = resp;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  incluirAtualizarContato() {
    if (this.operacao == 'post') {
      this.postContatos();
    } else {
      this.putContatos();

      this.operacao = 'post';
    }
  }

  postContatos() {
    this.contato = Object.assign({}, this.formulario.value);

    this.contatosService.postContatos(this.contato).subscribe(
      (resp) => {
        console.log(resp);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  putContatos() {
    this.contato = Object.assign({ id: this.contato.id }, this.formulario.value);

    this.contatosService.putContatos(this.contato).subscribe(
      (resp) => {
        console.log(resp);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
