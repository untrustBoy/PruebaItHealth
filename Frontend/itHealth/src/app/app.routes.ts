import { Routes } from '@angular/router';
import { ListPacientesComponent } from './components/list-pacientes/list-pacientes.component';
import { AddPacienteComponent } from './components/add-paciente/add-paciente.component';

export const routes: Routes = [
    {path: "", component: ListPacientesComponent},
    {path: "add", component: AddPacienteComponent}

];
