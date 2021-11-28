import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

export abstract class AbstractrestService<T>{
  protected constructor(protected http: HttpClient, protected endpoint: string) {}

  GetAll():Observable<T[]> {
    return this.http.get(this.endpoint) as Observable<T[]>;
  }

  GetOne(id: number): Observable<T> {
    return this.http.get(this.endpoint + id) as Observable<T>;
  }

  Create(id: number, item: T): Observable<T> {
    return this.http.post(this.endpoint + id, item) as Observable<T>;
  }

  Update(id: number, item: T): Observable<T> {
    return this.http.put(this.endpoint + id, item) as Observable<T>;
  }

  Delete(id: number): Observable<T> {
    return this.http.delete(this.endpoint + id) as Observable<T>;
  }
}
