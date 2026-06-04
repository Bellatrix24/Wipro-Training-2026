import { Injectable, Component, OnInit } from '@angular/core';

// ============================================================================
// EMPLOYEE INTERFACE DEFINITION
// ============================================================================

export interface Employee {
  employeeId: number;
  employeeName: string;
  department: string;
  designation: string;
}

// ============================================================================
// STUDY BLOCK 1: DATA PROVIDER SERVICE
// ============================================================================

// The @Injectable decorator tells Angular that this service can be injected as a dependency
// into other classes (like our dashboard component below).
@Injectable({
  providedIn: 'root' // This makes the service available globally across the whole workspace
})
export class EmployeeService {
  // This service array acts as our temporary dummy database until we wire up our real Web API endpoints later.
  private mockEmployees: Employee[] = [
    { employeeId: 101, employeeName: 'Aarav Sharma', department: 'Cloud Operations', designation: 'Project Engineer' },
    { employeeId: 102, employeeName: 'Priya Nair', department: 'Security Compliance', designation: 'Senior Security Analyst' },
    { employeeId: 103, employeeName: 'Rohan Verma', department: 'Product Development', designation: 'Graduate Engineer Trainee' }
  ];

  constructor() {
    // Intern study note: Services are singletons! This only instantiates once.
  }

  // Returns the array of mock employee records to whoever calls it
  getEmployees(): Employee[] {
    return this.mockEmployees;
  }
}

// ============================================================================
// STUDY BLOCK 2: DASHBOARD UI COMPONENT
// ============================================================================

@Component({
  selector: 'app-employee-dashboard',
  // Below is our template markup. It showcases how components consume and render service data.
  template: `
    <div class="dashboard-container">
      <h2>TechNova Employee Directory</h2>
      
      <div *ngIf="employees.length > 0; else noData" class="employee-grid">
        <div *ngFor="let employee of employees" class="employee-card">
          <!-- CONVERSATIONAL HTML REMINDERS:
               Standard interpolation template slots (like {{ employee.employeeName }}) 
               map TypeScript class properties cleanly onto our browser DOM elements. -->
          <h4>{{ employee.employeeName }} (ID: {{ employee.employeeId }})</h4>
          <p><strong>Dept:</strong> {{ employee.department }}</p>
          <p><strong>Designation:</strong> {{ employee.designation }}</p>
        </div>
      </div>

      <ng-template #noData>
        <p>No records found. Directory empty.</p>
      </ng-template>
    </div>
  `,
  styles: [`
    .dashboard-container { padding: 20px; font-family: sans-serif; }
    .employee-grid { display: flex; gap: 15px; flex-wrap: wrap; }
    .employee-card { 
      border: 1px solid #005a9c; 
      border-radius: 6px; 
      padding: 15px; 
      background-color: #f3f9fc;
      width: 250px;
    }
    h2 { color: #005a9c; }
    h4 { margin: 0 0 10px 0; color: #333; }
    p { margin: 5px 0; font-size: 14px; color: #555; }
  `]
})
export class EmployeeDashboardComponent implements OnInit {
  employees: Employee[] = [];

  // Decoupled architecture: We inject our EmployeeService through the constructor.
  // The component doesn't care how the service gets the data (mock array or HTTP Web API call).
  constructor(private employeeService: EmployeeService) {}

  // ngOnInit is a component lifecycle hook that runs automatically when the component loads.
  ngOnInit(): void {
    // We pull the array from our service during component lifecycle initialization!
    this.employees = this.employeeService.getEmployees();
  }
}
