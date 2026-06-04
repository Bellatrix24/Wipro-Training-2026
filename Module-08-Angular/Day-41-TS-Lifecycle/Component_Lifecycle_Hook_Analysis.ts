import { Component, OnInit } from '@angular/core';

/*
============================================================================
THE CORE LIFECYCLE EXECUTION LOOP
============================================================================

When Angular boots up, components follow a strict chronological sequence:

[Application Starts] 
         │
         ▼
[Component Instance Created] 
         │
         ▼
[Constructor Executes] 
  - (Perfect for dependency injection, but properties/bindings are not ready yet!)
         │
         ▼
[ngOnInit Executes] 
  - (Study Note: Runs right after the constructor finishes, making it the perfect spot to pull our startup data!)
         │
         ▼
[Template Rendered] 
  - (HTML and bindings are fully loaded into the browser DOM.)

*/

@Component({
  selector: 'app-employee-list',
  // Simple HTML template to show employee listings
  template: `
    <div class="list-container">
      <h3>TechNova Team List</h3>
      <ul>
        <li *ngFor="let name of employeeNames">{{ name }}</li>
      </ul>
    </div>
  `
})
export class EmployeeListComponent implements OnInit {
  employeeNames: string[] = [];

  constructor() {
    // Intern study note: This executes first during JS class instantiation.
    // Avoid calling database APIs inside the constructor. Keep it empty or limited to DI references!
  }

  // Explicit implementation of the OnInit interface hook
  ngOnInit() {
    // Study Note: Fires right after data initialization! Perfect for API queries.
    console.log("Employee List Component Loaded"); 
    
    // Simulate populating data from a service
    this.employeeNames = ['Amit Kumar', 'Sarah Connor', 'John Doe'];
  }
}

/*
============================================================================
PARENT-CHILD USER-DEFINED TAG VIEW
============================================================================

To display our component, we use its unique selector ('app-employee-list') 
as a custom HTML tag. We embed it inside parent templates (like app.component.html):

<!-- File: app.component.html -->
<div class="main-layout">
  <header>
    <h1>Wipro Enterprise Portal</h1>
  </header>
  
  <main>
    <!-- We embed our component safely as a user-defined HTML tag. 
         Angular reads this selector and injects the EmployeeListComponent here! -->
    <app-employee-list></app-employee-list>
  </main>
</div>

*/
