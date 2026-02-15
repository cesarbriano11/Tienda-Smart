import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-articulo-dialog',
  imports: [
    MatButtonModule,
    ReactiveFormsModule,
    MatTableModule,
    MatIconModule,
    MatFormFieldModule,
    MatDialogModule,
    MatFormField,
    MatLabel,
    MatInputModule,
  ],
  templateUrl: './articulo-dialog.html',
  styleUrl: './articulo-dialog.css',
})
export class ArticuloDialog {
  formArticulo : FormGroup;

  constructor(
    private formBuilder : FormBuilder,
    private dialogref: MatDialogRef<ArticuloDialog>,
    @Inject(MAT_DIALOG_DATA) public data:any
  ){
    this.formArticulo = this.formBuilder.group({
      idArticulo: [null],
      nombreArticulo:['', Validators.required],
      codigo: ['', Validators.required],
      descripcion: ['', Validators.required],
      precio: ['', Validators.required],
      urlImagen: ['', Validators.required],
      stock: ['', Validators.required],
      idSucursal:[data?.idSucursal]
    });

  if(data?.formArticulo){
      this.formArticulo.patchValue(data.formArticulo);
    }
  }

  InsertarArticulo(){
    if(this.formArticulo.valid){
      this.dialogref.close(this.formArticulo.value);
    }
  }

}
