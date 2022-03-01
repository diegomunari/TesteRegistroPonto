import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PontoFormComponent } from './ponto-form.component';

describe('PontoFormComponent', () => {
  let component: PontoFormComponent;
  let fixture: ComponentFixture<PontoFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PontoFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PontoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
