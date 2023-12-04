import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SuperHero } from './models/superHero';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
})
export class AppComponent implements OnInit {
  title = 'SuperHero.UI';
  urlAPI = 'http://localhost:5047';

  // LISTAR
  heroes$?: Observable<SuperHero[]>;

  //Buscar por nome
  heroi$?: Observable<SuperHero>;
  entrada: string = '';

  //Adicionar
  name: string = '';
  firstN: string = '';
  lastN: string = '';
  place: string = '';

  //Atualizar
  heroId$?: any;

  //carregar

  //Deletar

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getHeroes();
  }
  // LISTAR
  getHeroes(): void {
    this.heroes$ = this.http.get<SuperHero[]>(`${this.urlAPI}/api`);
  }

  //Buscar por nome
  getHero() {
    if (!this.entrada) return;
    this.heroi$ = this.http.get<SuperHero>(
      `${this.urlAPI}/GetByName/${this.entrada}`
    );
  }

  addHero() {
    // Verifique se todos os campos estão preenchidos
    if (!this.name || !this.firstN || !this.lastN || !this.place) {
      console.log('Todos os campos são necessários.');
      return;
    }

    const heroAdd: SuperHero = {
      name: this.name,
      firstName: this.firstN,
      lastName: this.lastN,
      place: this.place,
    };

    this.http
      .post<void>(`${this.urlAPI}/api`, heroAdd)
      .subscribe((_) => this.getHeroes());
  }

  //Atualizar

  updateHero(heroId: number) {
    // Verifique se todos os campos estão preenchidos
    if (!this.name || !this.firstN || !this.lastN || !this.place) {
      console.log('Todos os campos são necessários.');
      return;
    }

    const heroUpdate: SuperHero = {
      name: this.name,
      firstName: this.firstN,
      lastName: this.lastN,
      place: this.place,
    };

    this.http
      .put<void>(`${this.urlAPI}/api/${heroId}`, heroUpdate)
      .subscribe((_) => this.getHeroes());
  }

  //Deletar
  deleteHero(heroId: any) {
    this.http
      .delete<void>(`${this.urlAPI}/api/${heroId}`)
      .subscribe((_) => this.getHeroes());
  }

  // carregar
  loadHero(heroId: number) {
    this.http.get<SuperHero>(`${this.urlAPI}/api/${heroId}`).subscribe(
      (hero) => {
        this.name = hero.name;
        this.firstN = hero.firstName;
        this.lastN = hero.lastName;
        this.place = hero.place;
      },
      (error) => {
        console.error('Ocorreu um erro ao carregar o herói:', error);
      }
    );
  }
}
