import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  // Trainee Study Note: Interceptors act as middleware for HTTP traffic.
  // We clone the request because HTTP requests are immutable in Angular.
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const authToken = 'Bearer WiproTraineeToken2026';
    
    const authReq = req.clone({
      headers: req.headers.set('Authorization', authToken)
    });
    
    // Pass the modified request forward down the chain
    return next.handle(authReq);
  }
}
