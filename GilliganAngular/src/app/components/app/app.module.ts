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
import { AddSongComponent } from '../addsong/addsong.component';

const appRoutes: Routes = [
  { path: 'genre', component: AddGenreComponent },
  { path: 'album', component: AddAlbumComponent },
  { path: 'artist', component: AddArtistComponent },
  { path: 'song', component: AddSongComponent }
];


@NgModule({
  declarations: [
    AppComponent, AddGenreComponent, AddAlbumComponent, AddArtistComponent, AddSongComponent
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
