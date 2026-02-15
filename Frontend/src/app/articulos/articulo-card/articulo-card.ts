import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Articulo } from '../articulo.service';

@Component({
  selector: 'app-articulo-card',
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './articulo-card.html',
  styleUrl: './articulo-card.css',
})
export class ArticuloCard {
  @Input() articulo!: Articulo;

  @Output() editar = new EventEmitter<Articulo>();
  @Output() eliminar = new EventEmitter<Articulo>();

  editarArticulo(){
    this.editar.emit(this.articulo);
  }

  eliminarArticulo(){
    this.eliminar.emit(this.articulo);
  }
}
