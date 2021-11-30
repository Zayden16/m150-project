import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

export abstract class AbstractRestService<T> {
  protected constructor(protected httpClient: HttpClient, protected endpoint: string) {
  }

  GetAll(): Observable<T[]> {
    return this.httpClient.get(this.endpoint) as Observable<T[]>;
  }

  GetOne(id: number): Observable<T> {
    return this.httpClient.get(this.endpoint + id) as Observable<T>;
  }

  Create(item: T): Observable<T> {
    return this.httpClient.post(this.endpoint, item) as Observable<T>;
  }

  Update(item: T): Observable<T> {
    return this.httpClient.put(this.endpoint, item) as Observable<T>;
  }

  Delete(id: number): Observable<T> {
    return this.httpClient.delete(this.endpoint + id) as Observable<T>;
  }
}
