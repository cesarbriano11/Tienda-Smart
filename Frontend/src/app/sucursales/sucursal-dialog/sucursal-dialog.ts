import { Component } from '@angular/core';
import { MatAnchor, MatButtonModule } from "@angular/material/button";
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule, MatDialogRef,MAT_DIALOG_DATA,} from '@angular/material/dialog';
import { MatFormField, MatLabel } from "@angular/material/form-field";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-sucursal-dialog',
  imports: [MatButtonModule,
    ReactiveFormsModule,
    MatTableModule,
    MatIconModule,
    MatFormFieldModule,
    MatDialogModule,
    MatFormField,
    MatLabel,
    MatInputModule,
  ],
  templateUrl: './sucursal-dialog.html',
  styleUrl: './sucursal-dialog.css',
})
export class SucursalDialog {
  formSucursal: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private dialogref: MatDialogRef<SucursalDialog>,
    @Inject(MAT_DIALOG_DATA) public data:any
  ) {
    this.formSucursal = this.formBuilder.group({
      idSucursal:[null],
      nombreSucursal: ['', Validators.required],
      direccion: ['', Validators.required]
    });

    if(data){
      this.formSucursal.patchValue(data);
    }
  }

  InsertarSucursal(){
    if(this.formSucursal.valid){
      this.dialogref.close(this.formSucursal.value);
    }
  }
}
