import { DataService } from './../data/data.service';
import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(
    private toast: ToastrService,
    private dataSV: DataService
  ) { 

  }

  loading() {
    this.dataSV.loading.next(true);
  }

  unLoad() {
    this.dataSV.loading.next(false);
  }

  showSuccess(message: string) {
    this.unLoad();
    this.toast.success(message);
  }
  
  showInfo(message: string) {
    this.unLoad();
    this.toast.info(message);
  }

  showWarning(message: string) {
    this.unLoad();
    this.toast.warning(message);
  }

  showError(message: string) {
    this.unLoad();
    this.toast.error(message);
  }
}
