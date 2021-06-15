import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartService } from '../services/cart-service';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

    constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string, private cartService: CartService) {
    }
    public increaseAmount(productId: number) {
        this.cartService.increaseItemAmount(productId)
    }

    public reduceItemAmount(productId: number) {
        this.cartService.reduceItemAmount(productId)
    }

    public getTotalPrice() {
        if (!this.anyItemInTheCart())
            return 0;

        var sum = this.cartService.cart.items.map(p => p.finalPrice).reduce((a, b) => a + b)

        return sum.toFixed()
    }

    public anyItemInTheCart() {
        return this.cartService && this.cartService.cart && this.cartService.cart.items && this.cartService.cart.items.length > 0
    }
}
