import { AgendaService } from './agenda-service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  novaTurma: any = {};

  cursos: any[];
  professores: any[];
  turmas: any[];

  constructor(private _agendaService: AgendaService) {
    this.findCursos();
    this.findTurmas();
    this.findProfessores();
  }
  saveTurma(form): void {
    console.log(form.value);

    this._agendaService.addTurmas(this.novaTurma).subscribe(
      resp => {
        console.log('Turma adicionada com sucesso!');
        this.findTurmas();
        this.novaTurma = [];
      });
  }

  findTurmas() {
    this._agendaService.getTurmas().subscribe(
      response => { this.turmas = response }
    );
  }

  findCursos() {
    this._agendaService.getCursos().subscribe(
      response => { this.cursos = response }
    );
  }

  findProfessores() {
    this._agendaService.getProfessores().subscribe(
      response => { this.professores = response }
    );
  }

  removerTurma(turma) {
    console.log(turma);
    // this._agendaService.deleteTurmas().subscribe(
    //   response => { this.professores = response }
    // );
  }
}
