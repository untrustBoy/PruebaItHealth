import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Paciente } from '../interface/paciente';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'any'
})
export class PacienteService {

  private apiUrl: string; 

  constructor(private http: HttpClient) {
    this.apiUrl = "https://localhost:7288/api/Pacientes"
  }

  getPacientes(): Observable<Paciente[]>{
    // const options = {
    //   headers: new HttpHeaders().set('Access-Control-Allow-Origin:', '*')
    // };
    return this.http.get<Paciente[]>(`${this.apiUrl}`);
  }
}
