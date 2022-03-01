import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PontoListComponent } from './ponto-list.component';

describe('PontoListComponent', () => {
  let component: PontoListComponent;
  let fixture: ComponentFixture<PontoListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PontoListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PontoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
