import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddGenreComponent } from '../addgenre/addgenre.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

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
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
