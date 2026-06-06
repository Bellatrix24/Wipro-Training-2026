# BookStore Pro Dashboard Case Study

An advanced Angular dashboard application demonstrating multi-pattern data stream consumption, custom pipe calculations, parent-child component communication, and security interceptor integration.

Repository Link: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)

---

## Technical Details

### Stream Execution Patterns & Memory Management
To avoid memory leaks from hanging data streams, the component demonstrates two distinct subscribe patterns:
1. **Manual Unpack & Cleanup**: The component explicitly subscribes to the `getBooks()` method, unpacks the response to a local array, tracks the active `Subscription` instance, and cleans it up via `.unsubscribe()` inside the `ngOnDestroy()` lifecycle method.
2. **Direct Async Pipe Binding**: The component binds the raw observable stream `booksAsync$` directly to the template via Angular's `async` pipe. The async pipe handles subscription management, view updates, and automatic unsubscription when the component is removed from the DOM, ensuring complete protection from memory leaks.

### Request Interceptor Security Mechanics
Outgoing HTTP calls are intercepted by the `AuthInterceptor`. Because Angular HTTP request objects are immutable, the interceptor creates a cloned copy of the request, appends a dummy security header (`Authorization: Bearer WiproTraineeToken2026`), and forwards the modified request down the pipeline.

### Data Filter Selection
1. **UpperCasePipe**: Applied to title blocks to present clean, readable header typography.
2. **CurrencyPipe**: Bound explicitly to Indian Rupees (`INR` with standard currency symbols) to present local monetary values.
3. **DatePipe**: Formats database timestamp representations into clean, readable date strings.
4. **SlicePipe**: Constrains verbose description text to the first 50 characters to maintain card/table grid alignment consistency.
5. **DiscountPipe (Custom)**: Mathematically computes price reductions inline based on raw price and discount percentage attributes before printing the values.

---

## Setup Guidance Checklist

Execute the following commands in sequence to boot up the application:

```bash
# Install package dependencies
npm install

# Build and start the development server
ng serve
```

Access the dashboard in your web browser by navigating to: `http://localhost:4200/`
