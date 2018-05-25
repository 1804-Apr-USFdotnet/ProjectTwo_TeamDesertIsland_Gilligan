import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddGenreComponent } from '../addgenre/addgenre.component';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';

const appRoutes: Routes = [
  { path: 'genre', component: AddGenreComponent },
  { path: '', component: AddGenreComponent }
];


@NgModule({
  declarations: [
    AppComponent, AddGenreComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes, {enableTracing: true}),
    BrowserModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
