import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { CartItem } from '../models/cart';
import { Product } from '../models/product';
import { CartService } from '../services/cart-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public products: Product[];

    constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string, private cartService: CartService) {
        http.get<Product[]>(baseUrl + 'products').subscribe(result => {
            this.products = result;
        }, error => console.error(error));
    }

    public addItemToCart(event, item: Product) {
        this.cartService.addItemToCart(item)
    }
}
