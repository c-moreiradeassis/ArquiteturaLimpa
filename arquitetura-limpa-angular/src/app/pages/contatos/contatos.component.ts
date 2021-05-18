import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Contatos } from '../../_models/contatos'
import { ContatosService } from '../../_services/contatos.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contatos',
  templateUrl: './contatos.component.html',
})
export class ContatosComponent implements OnInit {
  contato = {} as Contatos;
  listaContatos: Contatos[] = [];
  operacao = 'post';
  modalRef: BsModalRef;

  formulario = this.formBuilder.group({
    nome: ['', Validators.required],
    cpf: ['', Validators.required],
    telefone: ['', Validators.required],
    email: ['', Validators.required],
  });

  constructor(
    private contatosService: ContatosService,
    private formBuilder: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getContatos();
  }

  abrirModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
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

  editarForm(contatoEditar: Contatos, template: TemplateRef<any>) {
    this.contato = contatoEditar;
    this.formulario.patchValue(contatoEditar);
    this.operacao = 'put';
    this.abrirModal(template);
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
    console.log(this.contato);
    this.contatosService.postContatos(this.contato).subscribe(
      () => {
        this.toastr.success('Contato cadastrado com sucesso.');
        this.modalRef.hide();
      },
      (error) => {
        this.toastr.error(error);
      }
    );
  }

  putContatos() {
    this.contato = Object.assign({ id: this.contato.id }, this.formulario.value);

    this.contatosService.putContatos(this.contato).subscribe(
      () => {
        this.toastr.success('Contato atualizado com sucesso.');
        this.modalRef.hide();
      },
      (error) => {
        this.toastr.error(error);
      }
    );
  }
}