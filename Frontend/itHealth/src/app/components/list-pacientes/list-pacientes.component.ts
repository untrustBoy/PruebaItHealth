import { Component, OnInit } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Paciente } from '../../interface/paciente';
import { PacienteService } from '../../services/paciente.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-list-pacientes',
  standalone: true,
  imports: [RouterOutlet, CommonModule, ListPacientesComponent, RouterModule],
  templateUrl: './list-pacientes.component.html',
  styleUrl: './list-pacientes.component.css'
})
export class ListPacientesComponent implements OnInit {
  listPacientes:Paciente[] = [];

  constructor(private _PacienteService :PacienteService){

  }

  ngOnInit(): void{
    this.getPacientes();
  }

  getPacientes(){
    this._PacienteService .getPacientes().subscribe((data:Paciente[])=>{
      console.log(data)
      this.listPacientes = data
    })
  }

}
