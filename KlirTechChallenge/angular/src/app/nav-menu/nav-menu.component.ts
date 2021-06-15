import { Component } from '@angular/core';
import { CartService } from '../services/cart-service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private cartService: CartService) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getTotalItems(): number {
    if (this.cartService && this.cartService.cart && this.cartService.cart.items)
      return this.cartService.cart.items.length;

    return 0;
  }
}
