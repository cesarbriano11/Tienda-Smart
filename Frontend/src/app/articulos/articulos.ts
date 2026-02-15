import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { MatFormField, MatFormFieldModule, MatLabel } from "@angular/material/form-field";
import { MatCardModule } from "@angular/material/card";
import { Sucursal, SucursalService } from '../sucursales/sucursal.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Articulo, ArticuloService } from './articulo.service';
import { MatButtonModule } from '@angular/material/button';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ArticuloCard } from "./articulo-card/articulo-card";
import { CommonModule } from '@angular/common';
import { ArticuloDialog } from './articulo-dialog/articulo-dialog';

@Component({
  selector: 'app-articulos',
  imports: [MatButtonModule,
    CommonModule,
    ReactiveFormsModule,
    MatTableModule,
    MatIconModule,
    MatFormFieldModule,
    MatDialogModule,
    MatFormField,
    MatSelectModule,
    MatLabel,
    MatInputModule, ArticuloCard],
  templateUrl: './articulos.html',
  styleUrl: './articulos.css',
})
export class Articulos {
  @Input() mostrarBotonAgregat: boolean = true;
  sucursales: Sucursal[] = [];
  articulos: Articulo[] = [];
  idSucursalSeleccionada!: number;

  constructor(
    private sucursalService: SucursalService,
    private articuloService: ArticuloService,
    private dialog: MatDialog,
    private changeDetectorRef: ChangeDetectorRef
  ){}

  ngOnInit(){
    this.sucursalService.consultaSucursales().subscribe(data => this.sucursales = data);

  }

  cargaArticulos(idSucursal?: number){

    if(idSucursal !== undefined){
      this.idSucursalSeleccionada = idSucursal;
    }
    
    if(!this.idSucursalSeleccionada) return;
    this.articuloService.consultaArticulosPorSucursal(this.idSucursalSeleccionada)
    .subscribe(data=> {this.articulos = data.map(
      a => ({... a}));
      this.changeDetectorRef.detectChanges();
    });
  }

  trackById(index: number, articulo: Articulo):number {
  return articulo.idArticulo;


}

  abrirDialogInsertarArticulos(){
      const dialogref = this.dialog.open(ArticuloDialog,{
        width:'500px',
        data:{idSucursal: this.idSucursalSeleccionada}
      });

      dialogref.afterClosed().subscribe(result =>{
        if(result){
          console.log('Datos del diálogo', result);
          this.articuloService.insertarArticulo(result).subscribe({
            next: () =>{
              this.cargaArticulos();
            },
            error:(error)=>{
              console.error('Ocurrio un error',error);
            }
          })
        }
      })
  }

  abrirdialogEditarArticulo(articulo: Articulo){
      const dialogref = this.dialog.open(ArticuloDialog,{
        width:'500px',
        data:{formArticulo: {...articulo}, idSucursal: this.idSucursalSeleccionada}
      });

      dialogref.afterClosed().subscribe(result =>{
        if(result){
           console.log('Datos para actualizar', result); 
          this.articuloService.actualizaArticulo(result).subscribe({
            next: () =>{
              this.cargaArticulos();
            },
            error:(error)=>{
              console.error('Ocurrio un error',error);
            }
          })
        }
      })
  }

  eliminarArticulo(articulo: Articulo) {
  if (!confirm(`¿Seguro que quieres eliminar el artículo ${articulo.nombreArticulo}?`)) return;

  this.articuloService.eliminarArticulo(articulo.idArticulo).subscribe(() => {
    this.cargaArticulos(); 
  });
}
  
}
