import { Directive, ElementRef, Renderer2, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective implements OnInit {
  // Binds the price input directly to the selector name for clean syntax in the template
  @Input('appHighlight') price: number = 0;

  constructor(private el: ElementRef, private renderer: Renderer2) {
    // Trainee note: Utilizing dependency injection to fetch ElementRef and Renderer2
    // to prevent direct browser DOM access which could break SSR or test environments.
  }

  ngOnInit(): void {
    // If the ticket costs more than 2000, this directive hooks into the host element to turn it gold.
    // Standard limit is 2000 as per case study specifications.
    if (this.price > 2000) {
      // Apply a premium pastel gold background color to make it visually stand out nicely
      this.renderer.setStyle(this.el.nativeElement, 'background-color', '#fff9e6');
      
      // Let's add a subtle transition effect for smoother presentation when elements appear
      this.renderer.setStyle(this.el.nativeElement, 'transition', 'background-color 0.3s ease');
    }
  }
}
