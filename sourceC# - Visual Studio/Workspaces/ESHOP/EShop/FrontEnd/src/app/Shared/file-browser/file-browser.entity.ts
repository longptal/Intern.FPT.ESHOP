export class FileBrowserEntity {
  Name: string;
  IsDirectory: boolean;
  Extension: string;
  Size: number;
  LastModified: string;
  Src: string;
  IsSelected: boolean = false;
  IsEdit: boolean = false;

  public constructor() {
  }
}
