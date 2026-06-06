import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'https://api.example.com/books'; // Mock API endpoint

  constructor(private http: HttpClient) {}

  getBooks(): Observable<any[]> {
    // Trainee Note: Using HttpClient to make GET requests as required by assignment guidelines.
    // Also providing a local fallback stream using RxJS 'of' so it runs seamlessly even if API is offline.
    return this.http.get<any[]>(this.apiUrl).pipe(
      catchError(() => {
        return of(this.getMockBooks());
      })
    );
  }

  private getMockBooks(): any[] {
    return [
      {
        id: 1,
        title: 'clean code: a handbook of agile software craftsmanship',
        description: 'even bad code can function. but if code isnt clean, it can bring a development organization to its knees.',
        author: 'Robert C. Martin',
        price: 1500,
        publishedDate: '2008-08-11',
        discount: 10
      },
      {
        id: 2,
        title: 'the pragmatic programmer: your journey to mastery',
        description: 'one of the most significant books in software development, covering coding guidelines, design, and career.',
        author: 'Andy Hunt & Dave Thomas',
        price: 2200,
        publishedDate: '1999-10-30',
        discount: 15
      },
      {
        id: 3,
        title: 'design patterns: elements of reusable object-oriented software',
        description: 'this classic text provides solutions to common software design problems in object-oriented programming.',
        author: 'Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides',
        price: 3800,
        publishedDate: '1994-11-10',
        discount: 20
      },
      {
        id: 4,
        title: 'you dont know js yet: get started',
        description: 'the first book in the series, introducing the core concepts of javascript programming language.',
        author: 'Kyle Simpson',
        price: 950,
        publishedDate: '2020-01-25',
        discount: 5
      }
    ];
  }
}
