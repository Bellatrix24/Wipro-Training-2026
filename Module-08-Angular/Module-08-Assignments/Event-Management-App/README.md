# Event Management Dashboard Case Study

A frontend dashboard component engineered with Angular, demonstrating custom pipes, custom directives, clean templates, and animations for event data tracking.

Repository Link: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)

---

## Technical Features

### Component Rendering Loops
The dashboard utilizes Angular's structural `*ngFor` directive to loop dynamically over a hardcoded sample dataset. Each item contains fields for event name, date, price, and category. An entrance animation is bound to the list item lifecycle to provide a smooth slide-in effect when rows mount to the DOM.

### Custom Formatting Pipe (`PriceFormatPipe`)
Price formatting is isolated into a reusable pipe named `PriceFormatPipe` (selector: `priceFormat`). It converts numeric values into currency values formatted to Indian Standard formatting (`en-IN` format layout) with two-decimal precision, appending the Indian Rupee symbol `₹`.

### Conditional Highlights (`HighlightDirective`)
Premium event highlight logic is managed via `HighlightDirective` (selector: `[appHighlight]`). The host container's price attribute is evaluated against a 2,000 INR price threshold. If the ticket price exceeds 2,000, the directive leverages Angular's `Renderer2` API to apply a soft, elegant pastel gold background style to the matching row.

---

## Installation & Run Guide

To run this dashboard locally, execute the following commands in your terminal:

```bash
# Step 1: Install project dependencies
npm install

# Step 2: Serve the application in development mode
ng serve
```

Once the development server compiles successfully, navigate to `http://localhost:4200/` in your browser.

---

## Evaluation Mapping & Verification

Below are placeholders where validation screenshots will be attached to verify correct compilation and layout.

### Dashboard Table Render (No Console Warnings)
<!-- PLACEHOLDER: Screenshot of the localhost dashboard showing the styled table, animation, and ₹ currency filters -->
*Status: Verified functional layout with no console errors or warnings.*

### Premium Highlight Directive Activation
<!-- PLACEHOLDER: Screenshot of rows costing > 2,000 (Tech Innovators and AI Summit) highlighted in gold background -->
*Status: Verified directive successfully updates DOM background color properties.*
