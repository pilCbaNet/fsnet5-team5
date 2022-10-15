import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UltimosmovimientosComponent } from './ultimosmovimientos.component';

describe('UltimosmovimientosComponent', () => {
  let component: UltimosmovimientosComponent;
  let fixture: ComponentFixture<UltimosmovimientosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UltimosmovimientosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UltimosmovimientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
