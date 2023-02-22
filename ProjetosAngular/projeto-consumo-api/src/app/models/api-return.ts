export class ApiReturn {
  count?: number;
  next?: string;
  previous?: string;
  results?: Results[];

  constructor(obj: Partial<ApiReturn>) {
    Object.assign(this, obj);
  }
}

export class Results {
  name?: string;
  url?: string;

  constructor(obj: Partial<ApiReturn>) {
    Object.assign(this, obj);
  }
}
