import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/finally';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import {FilterEntity} from '../Module/FilterEntity';
import {IEntity} from '../Module/IEntity.Entity';

@Injectable()
export class HttpService<Entity> {
  public PendingRequests: number = 0;
  public ShowLoading: boolean = false;
  public url: string = '';

  constructor(public http: HttpClient) {
  }

  Gets(SearchEntity?: FilterEntity, IsShowLoading?: boolean): Observable<Entity[]> {
    SearchEntity = SearchEntity === undefined ? new FilterEntity() : SearchEntity;
    return this.intercept(this.http.get<Entity[]>(this.url, {
      observe: 'response',
      headers: this.GetHeaders(),
      params: SearchEntity.ToParams()
    }), IsShowLoading).map(r => r.body);
  }

  Count(SearchEntity?: FilterEntity, IsShowLoading?: boolean): Observable<number> {
    SearchEntity = SearchEntity === undefined ? new FilterEntity() : SearchEntity;
    return this.intercept(this.http.get<number>(this.url + '/Count', {
      observe: 'response',
      headers: this.GetHeaders(),
      params: SearchEntity.ToParams()
    }), IsShowLoading).map(r => r.body);
  }

  GetId(Id: number, IsShowLoading?: boolean): Observable<Entity> {
    return this.intercept(this.http.get<Entity>(`${this.url}/${Id}`, {
      observe: 'response',
      headers: this.GetHeaders()
    }), IsShowLoading).map(r => r.body);
  }


  Create(body: IEntity, IsShowLoading?: boolean): Observable<Entity> {
    return this.intercept(this.http.post<Entity>(this.url, JSON.stringify(body), {
      observe: 'response',
      headers: this.GetHeaders()
    }), IsShowLoading).map(r => r.body);
  }

  Update(body: IEntity, IsShowLoading?: boolean): Observable<Entity> {
    return this.intercept(this.http.put<Entity>(`${this.url}/${body.Id}`, JSON.stringify(body), {
      observe: 'response',
      headers: this.GetHeaders()
    }), IsShowLoading).map(r => r.body);
  }

  Delete(Id: number, IsShowLoading?: boolean): Observable<boolean> {
    return this.intercept(this.http.delete(`${this.url}/${Id}`, {
      observe: 'response',
      headers: this.GetHeaders()
    }), IsShowLoading).map(r => r.body);
  }

  public intercept(observable: Observable<HttpResponse<any>>, isShowLoading?: boolean): Observable<HttpResponse<any>> {
    if (isShowLoading == null) {
      console.warn('isShowLoading not setted!');
      isShowLoading = true;
    }
    if (isShowLoading) this.turnOnModal();
    return observable
      .do((res: HttpResponse<any>) => {
        console.log('Response: ' + res);
      }, (err: any) => {
        if (isShowLoading) this.turnOffModal();
        console.log('Caught error: ' + err);
      })
      .finally(() => {
        if (isShowLoading) this.turnOffModal();
      });
  }

  public GetHeaders(): HttpHeaders {
    let headers = new HttpHeaders({'content-type': 'application/json; charset=utf-8'});
    return headers;
  }

  private turnOnModal() {
    this.PendingRequests++;
    if (!this.ShowLoading) {
      this.ShowLoading = true;
      document.body.classList.add('m-page--loading-non-block');
      console.log('Turned on modal');
    }
    this.ShowLoading = true;
  }

  private turnOffModal() {
    this.PendingRequests--;
    if (this.PendingRequests <= 0) {
      if (this.ShowLoading) {
        this.PendingRequests = 0;
        document.body.classList.remove('m-page--loading-non-block');
      }
      this.ShowLoading = false;
    }
    console.log('Turned off modal');
  }
}
