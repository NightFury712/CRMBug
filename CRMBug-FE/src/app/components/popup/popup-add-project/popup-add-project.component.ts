import { ValidateService } from './../../../service/validation/validate.service';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ProjectService } from 'src/app/service/project/project.service';

@Component({
  selector: 'app-popup-add-project',
  templateUrl: './popup-add-project.component.html',
  styleUrls: ['./popup-add-project.component.scss']
})
export class PopupAddProjectComponent implements OnInit {

  //#region Properties
  typeControl = TypeControl;

  data: any = {
    ProjectName: '',
    ProjectCode: ''
  }
  //#endregion
  constructor(
    public dialogRef: MatDialogRef<PopupAddProjectComponent>,
    private validateSV: ValidateService,
    private projectSV: ProjectService
  ) { }

  ngOnInit(): void {
  }
  
  saveData() {
    
    let isValid = true;
    isValid = this.validateSV.validateRequired(this.data.ProjectName);
    isValid = this.validateSV.validateRequired(this.data.ProjectCode);
    if(isValid) {
      this.projectSV.saveData(this.data).subscribe((res) => {
        console.log(res);
        this.dialogRef.close();
      });
    } else {
      alert("Field not valid");
    }
  }
  /**
   * Thực hiện lưu và thêm
   * Author: HHDANG 14.4.2022
   */
  saveAndAddData() {
    
  }
  /**
   * Đóng popup
   */
   close() {
    this.dialogRef.close();
  }
}
