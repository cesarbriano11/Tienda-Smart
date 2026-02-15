import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SucursalDialog } from './sucursal-dialog';

describe('SucursalDialog', () => {
  let component: SucursalDialog;
  let fixture: ComponentFixture<SucursalDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SucursalDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SucursalDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
