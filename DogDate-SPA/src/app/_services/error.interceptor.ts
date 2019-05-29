import { Injectable } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpHandler, HttpEvent,
    HttpErrorResponse,
    HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(err => {
                if (err instanceof HttpErrorResponse) {
                    const applErr = err.headers.get('Application-Error');
                    if (applErr) {
                        console.log(applErr);
                        return throwError(applErr);
                    }
                    const serverErr = err.error;
                    let modalStateErrs = '';
                    if (serverErr && typeof serverErr === 'object') {
                        for (const key in serverErr) {
                            if (serverErr[key]) {
                                modalStateErrs += serverErr[key] + '\n';
                            }
                        }
                    }
                    return throwError(modalStateErrs || serverErr || 'Server Error');
                }
            })
        );
    }
}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};
