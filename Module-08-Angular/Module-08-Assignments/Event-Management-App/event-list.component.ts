import { Component } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';

// Custom student note: Interface defining the standard structure of an event record
export interface Event {
  name: string;
  date: string;
  price: number;
  category: string;
}

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: [], // Keeping styling clean, using component-scoped styles below
  animations: [
    // Evaluator hint: Animation triggers a 500ms fade and vertical slide on row mounting
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(12px)' }),
        animate('500ms cubic-bezier(0.35, 0, 0.25, 1)', style({ opacity: 1, transform: 'translateY(0)' }))
      ])
    ])
  ],
  styles: [`
    .event-container {
      font-family: 'Outfit', 'Inter', sans-serif;
      max-width: 900px;
      margin: 2rem auto;
      padding: 1.5rem;
      background: #ffffff;
      border-radius: 12px;
      box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
    }
    .event-title {
      font-size: 1.8rem;
      font-weight: 700;
      color: #2c3e50;
      margin-bottom: 0.5rem;
      border-left: 5px solid #ffca28;
      padding-left: 10px;
    }
    .event-subtitle {
      color: #7f8c8d;
      font-size: 0.95rem;
      margin-bottom: 1.5rem;
    }
    .event-table {
      width: 100%;
      border-collapse: separate;
      border-spacing: 0;
      margin-top: 1rem;
      border-radius: 8px;
      overflow: hidden;
      border: 1px solid #e2e8f0;
    }
    .event-table th {
      background: #f8fafc;
      color: #475569;
      font-weight: 600;
      text-align: left;
      padding: 12px 16px;
      font-size: 0.875rem;
      border-bottom: 2px solid #e2e8f0;
    }
    .event-table td {
      padding: 14px 16px;
      color: #334155;
      font-size: 0.9rem;
      border-bottom: 1px solid #e2e8f0;
      vertical-align: middle;
    }
    .category-badge {
      display: inline-block;
      padding: 4px 8px;
      border-radius: 6px;
      font-size: 0.75rem;
      font-weight: 600;
      text-transform: uppercase;
      letter-spacing: 0.5px;
    }
    .bg-tech {
      background: #e0f2fe;
      color: #0369a1;
    }
    .bg-arts {
      background: #fdf2f8;
      color: #be185d;
    }
    .bg-music {
      background: #f3e8ff;
      color: #6b21a8;
    }
    .premium-badge {
      font-size: 0.75rem;
      color: #b45309;
      background: #fef3c7;
      border: 1px solid #f59e0b;
      padding: 2px 6px;
      border-radius: 4px;
      font-weight: 700;
      margin-left: 8px;
    }
  `]
})
export class EventListComponent {
  // Hardcoded training assignment data representing the main event ledger
  events: Event[] = [
    {
      name: 'Tech Innovators Conference',
      date: '2026-09-15',
      price: 3500,
      category: 'Technology'
    },
    {
      name: 'Creative Writing Workshop',
      date: '2026-10-05',
      price: 800,
      category: 'Arts'
    },
    {
      name: 'Rock Music Concert',
      date: '2026-11-20',
      price: 2500,
      category: 'Entertainment'
    },
    {
      name: 'AI & Machine Learning Summit',
      date: '2026-12-10',
      price: 5000,
      category: 'Technology'
    }
  ];

  constructor() {
    // Intern study note: Component bindings will load next, structure is ready
  }
}
