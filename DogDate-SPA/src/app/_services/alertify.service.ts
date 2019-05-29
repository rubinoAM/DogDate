import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

confirm(msg: string, okCB: () => any) {
  alertify.confirm(msg, (e) => {
    if (e) {
      okCB();
    } else {}
  });
}

success(msg: string) {
  alertify.success(msg);
}

error(msg: string) {
  alertify.error(msg);
}

warning(msg: string) {
  alertify.warning(msg);
}

message(msg: string) {
  alertify.message(msg);
}

}
