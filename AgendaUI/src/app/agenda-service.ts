import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AgendaService {

  //https://labs.play-with-docker.com
  //docker pull renatogroffe/agenda-alpine
  //docker run --name dockeragenda -p 60000:80 -d renatogroffe/agenda-alpine
  private _restApiUrl = 'http://ip172-18-0-15-bcilalgabk8g00dajl9g-60000.direct.labs.play-with-docker.com/api/';

  constructor(private http: HttpClient) { }

  public getTurmas(): Observable<any> {
    return this.http.get(this._restApiUrl + 'turmas');
  }

  public addTurmas(turma): Observable<any> {
    return this.http.post(this._restApiUrl + 'turmas', turma);
  }

  public deleteTurmas(turma): Observable<any> {
    return this.http.delete(this._restApiUrl + 'turmas/', turma.id);
  }

  public getCursos(): Observable<any> {
    return this.http.get(this._restApiUrl + 'cursos');
  }

  public getProfessores(): Observable<any> {
    return this.http.get(this._restApiUrl + 'professores');
  }
}
