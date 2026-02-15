import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticuloCard } from './articulo-card';

describe('ArticuloCard', () => {
  let component: ArticuloCard;
  let fixture: ComponentFixture<ArticuloCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArticuloCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArticuloCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
