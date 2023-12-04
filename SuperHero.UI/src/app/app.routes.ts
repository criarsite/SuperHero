import { Routes } from '@angular/router';
import { HeroComponent } from './components/hero/hero.component';

export const routes: Routes = [
    { path: 'hero/:id', component: HeroComponent },
];
