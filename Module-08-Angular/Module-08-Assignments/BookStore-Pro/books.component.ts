import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { DataService } from './data.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: [], // Keeping component lightweight
  styles: [`
    .bookstore-container {
      font-family: 'Outfit', 'Inter', sans-serif;
      max-width: 1000px;
      margin: 2rem auto;
      padding: 1.5rem;
      background: #ffffff;
      border-radius: 12px;
      box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
    }
    .bookstore-title {
      font-size: 2rem;
      font-weight: 700;
      color: #1e293b;
      margin-bottom: 0.5rem;
      border-left: 5px solid #2563eb;
      padding-left: 10px;
    }
    .bookstore-subtitle {
      color: #64748b;
      font-size: 0.95rem;
      margin-bottom: 2.0rem;
    }
    .grid-container {
      display: grid;
      grid-template-columns: 1fr;
      gap: 1.5rem;
    }
    @media (min-width: 768px) {
      .grid-container {
        grid-template-columns: 1.5fr 1fr;
      }
    }
    .books-section {
      background: #f8fafc;
      padding: 1.5rem;
      border-radius: 8px;
      border: 1px solid #e2e8f0;
    }
    .stream-title {
      font-size: 1.1rem;
      font-weight: 600;
      color: #334155;
      margin-top: 0;
      margin-bottom: 1rem;
      padding-bottom: 6px;
      border-bottom: 2px solid #cbd5e1;
    }
    .book-list-table {
      width: 100%;
      border-collapse: collapse;
      margin-top: 0.5rem;
    }
    .book-list-table th {
      background: #e2e8f0;
      color: #334155;
      text-align: left;
      padding: 10px;
      font-size: 0.8rem;
      text-transform: uppercase;
      letter-spacing: 0.5px;
    }
    .book-list-table td {
      padding: 12px 10px;
      border-bottom: 1px solid #cbd5e1;
      font-size: 0.875rem;
      color: #475569;
    }
    .btn-select {
      background: #2563eb;
      color: white;
      border: none;
      padding: 6px 12px;
      border-radius: 4px;
      cursor: pointer;
      font-size: 0.8rem;
      transition: background 0.2s ease;
    }
    .btn-select:hover {
      background: #1d4ed8;
    }
    .async-badge {
      display: inline-block;
      padding: 3px 6px;
      background: #dcfce7;
      color: #15803d;
      border-radius: 4px;
      font-size: 0.75rem;
      font-weight: 600;
    }
  `]
})
export class BooksComponent implements OnInit, OnDestroy {
  // Method 1: Manual Subscription Loop
  booksManual: any[] = [];
  private bookSubscription!: Subscription;

  // Method 2: Async Pipe stream property
  booksAsync$!: Observable<any[]>;

  // Tracker for the currently selected book to pass down to child element
  currentBook: any = null;

  constructor(private dataService: DataService) {
    // Study Note: Injecting the shared DataService to load our catalogs
  }

  ngOnInit(): void {
    // Execution Pattern 1: Explicit subscription with manual unpack and lifecycle tracking
    this.bookSubscription = this.dataService.getBooks().subscribe({
      next: (data) => {
        this.booksManual = data;
      },
      error: (err) => console.error('Error fetching books in manual subscription', err)
    });

    // Execution Pattern 2: Binding the observable directly for standard async-pipe unpacking
    this.booksAsync$ = this.dataService.getBooks();
  }

  selectBook(book: any): void {
    this.currentBook = book;
  }

  ngOnDestroy(): void {
    // Study Note: Remember to unsubscribe in ngOnDestroy to avoid hanging data streams and memory leaks
    if (this.bookSubscription) {
      this.bookSubscription.unsubscribe();
    }
  }
}

// Child Component defined in the same file to keep submission self-contained and neat
@Component({
  selector: 'app-book-detail',
  template: `
    <div class="book-detail-card" *ngIf="selectedBook">
      <h3>Book Details View</h3>
      <p><strong>Title:</strong> {{ selectedBook.title | uppercase }}</p>
      <p><strong>Author:</strong> {{ selectedBook.author }}</p>
      <p><strong>Description:</strong> {{ selectedBook.description }}</p>
      <p><strong>Original Price:</strong> {{ selectedBook.price | currency:'INR':'symbol' }}</p>
      <p><strong>Discount Applied:</strong> {{ selectedBook.discount }}%</p>
      <p><strong>Discounted Price:</strong> {{ selectedBook.price | discount:selectedBook.discount | currency:'INR':'symbol' }}</p>
    </div>
  `,
  styles: [`
    .book-detail-card {
      padding: 1.5rem;
      border: 1px solid #e2e8f0;
      background-color: #fafaf9;
      border-radius: 8px;
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.05);
    }
    .book-detail-card h3 {
      margin-top: 0;
      color: #1e293b;
      border-bottom: 2px solid #2563eb;
      padding-bottom: 5px;
      font-size: 1.2rem;
    }
    .book-detail-card p {
      font-size: 0.9rem;
      margin: 8px 0;
      color: #44403c;
    }
  `]
})
export class BookDetailComponent {
  @Input() selectedBook: any = null;
}
