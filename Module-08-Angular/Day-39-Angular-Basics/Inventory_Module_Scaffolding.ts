import { NgModule, Component } from '@angular/core';

// ============================================================================
// FEATURE COMPONENT DEFINITION
// ============================================================================

@Component({
  selector: 'app-product-list',
  // This inline HTML template demonstrates how we bind data to our view.
  // We use double curly braces {{ }} (interpolation) to pull data directly from our TypeScript class.
  template: `
    <div class="product-box">
      <h3>TechNova Inventory List</h3>
      <ul>
        <!-- This interpolation syntax pulls data straight from our TypeScript class to show it on the page -->
        <li>Primary Item: {{ products[0] }}</li>
        <li>Secondary Item: {{ products[1] }}</li>
        <li>Accessory Item: {{ products[2] }}</li>
      </ul>
      <p>Total items tracked: {{ products.length }}</p>
    </div>
  `,
  styles: [`
    .product-box {
      border: 1px solid #ddd;
      padding: 15px;
      border-radius: 8px;
      background-color: #f9f9f9;
    }
    h3 { color: #004b87; }
  `]
})
export class ProductListComponent {
  // Simple mock array of items for today's lab practice
  products: string[] = ['Laptop', 'Mouse', 'Keyboard'];

  constructor() {
    // Intern study note: This runs when our component is loaded in memory!
  }
}

// ============================================================================
// FEATURE MODULE SCAFFOLDING
// ============================================================================

@NgModule({
  // The declarations array registers our custom ProductListComponent to this module.
  // This encapsulates the component, keeping our root app module files clean and uncluttered!
  declarations: [
    ProductListComponent
  ],
  // Exporting this component allows other modules (like AppModule) to import this module 
  // and render the <app-product-list> tag in their own templates.
  exports: [
    ProductListComponent
  ]
})
export class InventoryModule {
  constructor() {
    // Intern study note: Keeping our feature boundary neat and clean!
  }
}
