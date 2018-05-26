import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddGenreComponent } from '../addgenre/addgenre.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddAlbumComponent } from '../addalbum/addalbum.component';
import { AddArtistComponent } from '../addartist/addartist.component';

const appRoutes: Routes = [
  { path: 'genre', component: AddGenreComponent },
  { path: '', component: AddGenreComponent },
  { path: 'album', component: AddAlbumComponent },
  { path: 'artist', component: AddArtistComponent }
];


@NgModule({
  declarations: [
    AppComponent, AddGenreComponent, AddAlbumComponent, AddArtistComponent
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
