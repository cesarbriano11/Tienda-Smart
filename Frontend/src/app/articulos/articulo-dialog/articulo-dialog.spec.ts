import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticuloDialog } from './articulo-dialog';

describe('ArticuloDialog', () => {
  let component: ArticuloDialog;
  let fixture: ComponentFixture<ArticuloDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArticuloDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArticuloDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
