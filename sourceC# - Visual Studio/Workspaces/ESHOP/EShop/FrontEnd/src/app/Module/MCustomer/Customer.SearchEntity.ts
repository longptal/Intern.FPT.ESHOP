import { FilterEntity } from "../FilterEntity";

export class CustomerSearchEntity extends FilterEntity {
  Username: string = null;
  Display: string = null;
  Picture: string = null;
  FacebookId: string = null;
  FacebookEmail: string = null;
  GoogleId: string = null;
  GoogleEmail: string = null;
  CustomerGroupId: number = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.Username = Entity == null ? null : Entity.Username;
    this.Display = Entity == null ? null : Entity.Display;
    this.Picture = Entity == null ? null : Entity.Picture;
    this.FacebookId = Entity == null ? null : Entity.FacebookId;
    this.FacebookEmail = Entity == null ? null : Entity.FacebookEmail;
    this.GoogleId = Entity == null ? null : Entity.GoogleId;
    this.GoogleEmail = Entity == null ? null : Entity.GoogleEmail
    this.CustomerGroupId = Entity == null ? null : Entity.CustomerGroupId;
  }
}
