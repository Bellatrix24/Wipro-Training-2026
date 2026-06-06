import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priceFormat'
})
export class PriceFormatPipe implements PipeTransform {
  /**
   * Formats raw numbers into Rupees currency layout with double decimals.
   * Trainee Comment: Using Intl.NumberFormat here as it's cleaner and more robust
   * than regex replace logic for handling Indian locale grouping (e.g., 3,00,000 instead of 300,000).
   */
  transform(value: number | string): string {
    if (value === null || value === undefined) {
      return '₹0.00';
    }

    const numericValue = typeof value === 'string' ? parseFloat(value) : value;

    if (isNaN(numericValue)) {
      return '₹0.00';
    }

    // Formats numbers to Indian standard currency formatting pattern
    const formattedNumber = new Intl.NumberFormat('en-IN', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(numericValue);

    return `₹${formattedNumber}`;
  }
}
