import { TestBed } from '@angular/core/testing';

import { WebserviceService } from './webservice.service';

describe('WebserviceService', () => {
  let service: WebserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WebserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
