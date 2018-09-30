import { URLSearchParams } from '@angular/http';
import { HttpParams } from '@angular/common/http';

export class FilterEntity {
    Skip: number;
    Take: number;
    OrderBy: string;
    Type: string;

    constructor(FilterEntity: any = null) {
        if (FilterEntity == null) {
            this.Skip = 0;
            this.Take = 10;
            this.OrderBy = 'Id';
            this.Type = 'None';
        } else {
            this.Skip = FilterEntity.Skip;
            this.Take = FilterEntity.Take;
            this.OrderBy = FilterEntity.OrderBy;
            this.Type = FilterEntity.Type;
        }
    }

    ToParams(): HttpParams {
        let params = new HttpParams();
        for (let key in this) {
            if (this.hasOwnProperty(key) && this[key.toString()] != null) {
                params = params.set(key, this[key.toString()]);
            }
        }
        return params;
    }
}

