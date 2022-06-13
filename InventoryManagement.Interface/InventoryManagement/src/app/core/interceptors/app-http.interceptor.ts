import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {

  constructor(private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    return next.handle(request).pipe(
      tap(
        data=>{
          console.log("tapppppppppppppppppp")
        }
      ),
      catchError(
       error=>{

         if(error){
         

           if(error.status===400){
             

             this.router.navigateByUrl("/404");
           }
           if(error.status===500){

             console.log("Server Error")
           }
         }
         return throwError(error)
       }
      )
    );
  }
}
