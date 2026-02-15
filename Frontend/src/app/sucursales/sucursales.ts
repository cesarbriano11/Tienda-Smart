import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatAnchor, MatButtonModule } from "@angular/material/button";
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { SucursalService, Sucursal } from './sucursal.service';
import { SucursalDialog } from './sucursal-dialog/sucursal-dialog';

@Component({
  selector: 'app-sucursales',
  standalone:true,
  imports: [MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatDialogModule

  ],
  templateUrl: './sucursales.html',
  styleUrl: './sucursales.css',
})
export class Sucursales implements OnInit {
  sucursales: Sucursal[] = [];
  columnas: string[] = ['acciones', 'idSucursal', 'nombreSucursal', 'direccion'];

  constructor(private sucursalesService: SucursalService, 
    private detector:ChangeDetectorRef,
    private dialog: MatDialog, 
    private sucursalService: SucursalService
  ){}

  ngOnInit(): void{
    this.obtenerSucursales();
  }

  obtenerSucursales(){
    this.sucursalesService.consultaSucursales().subscribe({
      next: (data)=>{
        this.sucursales =data;
        this.detector.detectChanges();
      },
      error: (error) =>{
        console.error('Error al obtener sucursales',error)
      }
    });
  }

  abrirDialogInsertarSucursal(){
    const dialogref = this.dialog.open(SucursalDialog,{
      width:'500px'
    });

    dialogref.afterClosed().subscribe(result =>{
      if(result){
          this.sucursalService.insertarSucursal(result).subscribe({
            next: () => {
              this.obtenerSucursales();
            },
            error:(error)=>{
              console.error("error al crear sucursal", error);
            }
          });
      }
    })
  }

  abrirDialogActualizarSucursal(sucursal: Sucursal){
    console.log('se hizo click', sucursal);
    const dialogref = this.dialog.open(SucursalDialog,{
      width:'500px',
      data: sucursal
    });

    dialogref.afterClosed().subscribe(result =>{
      if(result){
          this.sucursalService.actualizarSucursal(result.idSucursal, result).subscribe({
            next: () => {
              this.obtenerSucursales();
            },
            error:(error)=>{
              console.error("error al crear sucursal", error);
            }
          });
      }
    })
  }

  eliminarSucursal(Sucursal: Sucursal){
    const confirmacion = confirm(`eliminar sucursal: "${Sucursal.nombreSucursal}"?`);

    if (confirmacion){
      this.sucursalService.eliminarSucursal(Sucursal.idSucursal).subscribe({
        next: () => {
          this.obtenerSucursales();
        },
        error: (error) => {
          console.error(error)
        }
      })
    }
  }


}
