import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'discount'
})
export class DiscountPipe implements PipeTransform {
  // Trainee Study Note: Discount calculation is: Price - (Price * Discount / 100)
  transform(price: number, discountPercentage: number = 0): number {
    if (!price || price <= 0) return 0;
    if (discountPercentage <= 0) return price;
    
    // Formula: Final price is the base price minus the discount value
    const finalPrice = price - (price * (discountPercentage / 100));
    return parseFloat(finalPrice.toFixed(2));
  }
}
