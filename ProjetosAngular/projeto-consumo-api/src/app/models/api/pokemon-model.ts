export class Pokemon {
    base_experience?: number;
    height?: number;
    id?: number;
    name?: string;
    order?: number;
    sprites?: Sprite = new Sprite({});
    weight?: number;

    constructor(obj: Partial<Pokemon>) {
      Object.assign(this, obj);
    }
}

export class Sprite {
  back_default?: string;
  back_female?: null;
  back_shiny?: string;
  back_shiny_female?: null;
  front_default?: string;
  front_female?: string;
  front_shiny?: string;
  front_shiny_female?: string;

  constructor(obj: Partial<Sprite>) {
    Object.assign(this, obj);
  }
}
