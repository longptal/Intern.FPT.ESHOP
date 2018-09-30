import {IEntity} from '../../../Module/IEntity.Entity';

export class DirectoryEntity extends IEntity {
  Path: string = null;
  SourcePath: string = null;
  DestinationPath: string = null;

  public constructor() {
    super();
  }
}
